using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EY.CabinCrew.Core
{
    public interface IRepository<Entity>
        where Entity: class
    {
        Task<Entity> Get(string employeeId);
        
    }
}
