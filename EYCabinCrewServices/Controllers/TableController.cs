using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EY.CabinCrew.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EY.CabinCrew.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ILogger<RosterController> logger;
        private readonly ConnectionStringSettings ConnectionSettings;
        public TableController(ILogger<RosterController> logger, IConfiguration configuration)
        {
            this.logger = logger;

            ConnectionSettings = new ConnectionStringSettings();
            configuration.Bind("CrewRosterConnectionStrings", ConnectionSettings);
        }

        [HttpGet]
        public async Task<DataTable> Get()
        {

            return await Task.Run(() =>
            {
                try
                {
                    string commandText = $"SELECT * FROM {ConnectionSettings.DefaultTableName}";
                    DataTable table = new DataTable();

                    using (SqlConnection connection = new SqlConnection(ConnectionSettings.ConnectionString))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection))
                        {
                            adapter.Fill(table);
                            logger.LogInformation(JsonSerializer.Serialize(table));
                            return table;
                        }
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex.ToString());
                    throw;
                }
            });
        }
    }
}