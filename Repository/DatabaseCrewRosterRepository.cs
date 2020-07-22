using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EY.CabinCrew.Core;
using EY.CabinCrew.Model.Entities;
using Microsoft.Extensions.Configuration;

namespace EY.CabinCrew.Repositories
{
   
    public class DatabaseCrewRosterRepository : IRepository<Roster>
    {
       private readonly ISqlAdapter adapter;
        private readonly IConfiguration configuration;

        public DatabaseCrewRosterRepository(ISqlAdapter adapter,IConfiguration configuration)
        {
            this.adapter = adapter;
            this.configuration = configuration;
         }
        public async Task<Roster> Get(string employeeId)
        {
            Roster roster = new Roster();
            roster.PersonalDetails = await GetPersonalDetails(employeeId);
            return roster;

        }

        private async Task<PersonalDetails> GetPersonalDetails(string employeeId)
        {

            var parameters = new { PersonalId = 10055 };
            string commandText = $"SELECT top 100 Name,rank as Contact FROM HMS.VW_PERSONALDETAILS where personal_id= {@employeeId}";
            //string sql = @"select top 1  Name,rank as Contact  from HMS.VW_PERSONALDETAILS where personal_id=@PersonalId";
            PersonalDetails result = await adapter.Get<PersonalDetails>(commandText);
            //string commandText = $"SELECT top 100 Name,rank as Contact FROM HMS.VW_PERSONALDETAILS where personal_id= {@employeeId}";
            //DataTable table = new DataTable();

            
            //using (SqlConnection connection = new SqlConnection(adapter.ConnectionString.ConnectionString))
            //{
            //    using (SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection))
            //    {
            //        adapter.Fill(table);

            //        foreach (DataRow row in table.Rows)
            //        {
            //            PersonalDetails details = new PersonalDetails();
            //            details.Name = row["Name"].ToString();
            //            details.Contact=row["Contact"].ToString();
            //            return details;
            //        }

            //    }
            //}

            return result;           
        }
    }
}
