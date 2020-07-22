using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using EY.CabinCrew.Core;
using Microsoft.Extensions.Configuration;

namespace EY.CabinCrew.Repositories
{
    public class SqlAdapter : ISqlAdapter
    {

        public ConnectionStringSettings ConnectionString { get; private set; }

        public SqlAdapter(IConfiguration configuration)
        {
            ConnectionStringSettings connectionsetting = new ConnectionStringSettings();
            configuration.Bind("CrewRosterConnectionStrings", connectionsetting);
            ConnectionString = connectionsetting;
        }

        public async Task<IEnumerable<TEntity>> List<TEntity>(string query, object param = null)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities;

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString))
            {
                await connection.OpenAsync();

                if (string.IsNullOrWhiteSpace(query))

                    entities = await connection.QueryAsync<TEntity>(query, param);
                else
                    return new List<TEntity>();
            }
            return entities;
        }

        public async Task<TEntity> Get<TEntity>(string query, object param = null)
            where TEntity : class, new()
        {

            TEntity entity;

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConnectionString))
            {
                await connection.OpenAsync();

                if (string.IsNullOrWhiteSpace(query))

                    entity = await connection.QuerySingleAsync<TEntity>(query, param);
                // entities = await connection.QueryAsync<TEntity>(query,param);
                else
                    return null;
            }
            return entity;
        }

    }
}
