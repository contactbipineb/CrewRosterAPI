using System.Collections.Generic;
using System.Threading.Tasks;

namespace EY.CabinCrew.Core
{

    public interface ISqlAdapter
    {
         ConnectionStringSettings ConnectionString { get;  }
        Task<IEnumerable<TEntity>> List<TEntity>(string query, object param = null)
        where TEntity : class, new();
        Task<TEntity> Get<TEntity>(string query, object param = null)
             where TEntity : class, new();


    }
}
