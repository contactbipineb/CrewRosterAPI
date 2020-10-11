using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EY.CabinCrew.Core;
using EY.CabinCrew.Model.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace EY.CabinCrew.Repositories
{

    public class DatabaseCrewRosterRepository : IRepository<Roster>
    {
        private readonly ISqlAdapter adapter;
        private readonly IMemoryCache cache;

        public DatabaseCrewRosterRepository(ISqlAdapter adapter, IMemoryCache cache)
        {
            this.adapter = adapter;
            this.cache = cache;
        }
        public async Task<Roster> Get(string employeeId)
        {
            if (cache.TryGetValue(employeeId, out object value))
                return value as Roster;
            Roster roster = new Roster();
            roster.PersonalDetails = await GetPersonalDetails(employeeId);
            roster.Plan = await GetPlans(employeeId);
            cache.Set(employeeId, roster, new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(1) });
            return roster;

        }

        private async Task<PersonalDetails> GetPersonalDetails(string employeeId)
        {

            var parameters = new { CrewId = employeeId };
            string commandText = "SELECT top 100 Name,rank as Contact,CrewType as Address FROM HMS.VW_PERSONALDETAILS where personal_id= @CrewId";
            //string sql = @"select top 1  Name,rank as Contact  from HMS.VW_PERSONALDETAILS where personal_id=@PersonalId";
            PersonalDetails result = await adapter.Get<PersonalDetails>(commandText, parameters);
            return result;
        }

        private async Task<List<Plan>> GetPlans(string employeeId)
        {

            var parameters = new { CrewId = employeeId };
            string commandText = "SELECT TOP 100 [PK_Plan] as Id,[Month],[WeekNumber],[DayOfWeek] as Day FROM [HMS].[VW_PLAN] where PK_Plan = @CrewId";
            //string sql = @"select top 1  Name,rank as Contact  from HMS.VW_PERSONALDETAILS where personal_id=@PersonalId";
            IEnumerable<Plan> result = await adapter.List<Plan>(commandText, parameters);
            foreach (var plan in result)
            {
                plan.FlightDetails = await GetFlightDetails(plan.Id);
            }
            return result.ToList();
        }

        private async Task<FlightDetails> GetFlightDetails(int planId)
        {

            var parameters = new { PlanId = planId };
            string commandText = "SELECT TOP 1 PK_FlightDetails as Id,[Blockhours]  as Blockhours,[FlightDepartueTime]  as FlightDepartueTime,[FlightArrivalTime]  as  FlightArrivalTime,[rest_hr]  as Rest_Hr, [trip_starttime_local]  as  FlightStartTime_Local,[trip_starttime_local_actual]  as FlightStartTime_Local_actual,[trip_crewcount]  as  CrewCount,cast([schd_dep_date] as date)  as   FlightStartDate,[flight_number]  as    SourceFlightCode, [TailNo]  as TailNo,[sub_fleet] as AcType,[SourceFlightCode]  asCode,[SourceCode]  as SourceCode,[DestinationCode]  as DestinationCode,[Port]  as Port,[dep_country]  as Source,[std_z_date]  as FlightStartDate_z,[std_ls_date]  as FlightStartDate_ls,[Z_FlightDepartueTime]  as FlightDepartueTime_z,[ls_FlightDepartueTime]  as  FlightDepartueTime_ls, [sta_z_date]  as   FlightArrDate_z, [Z_FlightArrivalTime]  as FlightArrivalTime_z, [ls_FlightArrivalTime]  as FlightArrivalTime_ls,[DepGateNumber]  as Dep_GateNumber,[ArrGateNumber]  as Arr_GateNumber FROM [HMS].[VW_FLIGHTDETAILS] where [PK_FlightDetails]= @PlanId ";
            //string sql = @"select top 1  Name,rank as Contact  from HMS.VW_PERSONALDETAILS where personal_id=@PersonalId";
            FlightDetails result = await adapter.Get<FlightDetails>(commandText, parameters);
            return result;
        }
    }
}
