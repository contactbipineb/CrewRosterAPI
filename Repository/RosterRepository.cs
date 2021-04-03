/*
using EY.CabinCrew.Core;
using EY.CabinCrew.Model.Entities;
using Microsoft.Extensions.Logging;
using LoggerFactory = EY.CabinCrew.Logging.LoggerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EY.CabinCrew.Repositories
{
    public class CrewRosterRepository : IRepository<Roster>
    {
        private static ILogger<DatabaseCrewRosterRepository> Logger = LoggerFactory.CreateLogger<DatabaseCrewRosterRepository>();

        private static Lazy<IList<ExcelRow>> rows = new Lazy<IList<ExcelRow>>(() =>
        {

            IList<ExcelRow> excelRows = ExcelAdpater.Read<ExcelRow>(@"C:\Users\bberkmance\Desktop\CrewRosterBot\Roster.csv", ",");

            return excelRows;
        }, LazyThreadSafetyMode.PublicationOnly);

        public static IList<ExcelRow> Rows => rows.Value;

        
        //public RosterRepository(ISqlAdapter adapter)
        //{
        //    Adapter = adapter;
        //}

        public ISqlAdapter Adapter { get; }

        public async Task<Roster> Get(string employeeId)
        {

            return await Task.Run(() =>
            {
                List <ExcelRow> excelRows = Rows.Where(r => r.crew_id == employeeId).ToList();
                Roster roster = new Roster();
                roster.EmpId = employeeId;
                roster.Plan = ConvertRowsToPlans(excelRows);
                PersonalDetails personalDetails = new PersonalDetails();
                List<PersonalDetails> pd = new List<PersonalDetails>();

                ExcelRow row = excelRows.FirstOrDefault();
                if (row != null)
                    roster.PersonalDetails = new PersonalDetails { Name = row.crew_name };
              
               
                return roster;
               
            });

            
        }
        
        private List<Plan> ConvertRowsToPlans(List<ExcelRow> excelRows)
        {
            List<Plan> plans = new List<Plan>();
            foreach (ExcelRow row in excelRows)
            {
                Plan plan = new Plan();
                plan.FlightDetails = new FlightDetails();
                plan.FlightDetails.Code = row.flight_number;
                plan.FlightDetails.FlightStartDate = Convert.ToDateTime(row.schd_dep_date);
                plan.FlightDetails.AcType = row.sub_fleet;
                plan.FlightDetails.Source = row.dep_country;
                plan.FlightDetails.SourceCode = row.sched_dep_iata;
                plan.FlightDetails.SourceFlightCode = row.flight_number;
                plan.FlightDetails.FlightDepartueTime = row.std_z;
                plan.FlightDetails.Destination = row.sched_arr_iata;
                plan.FlightDetails.DestinationCode = row.sched_arr_iata;
                plan.FlightDetails.DestinationFlightCode = row.flight_number;
                plan.FlightDetails.FlightEndDate = Convert.ToDateTime(row.sta_z_date);
                plan.FlightDetails.FlightArrivalTime = row.sta_z_date_time;
                plan.FlightDetails.TravelDuraion = row.block_hour_schedule;
                plan.FlightDetails.GateNumber = row.dep_gate;
                plan.FlightDetails.Blockhours = row.block_hour_schedule;
                plan.FlightDetails.TailNo = row.reg;


                //Fill the plan
                plans.Add(plan);
                                              
            }

            return plans;
        }
    }
}
*/
