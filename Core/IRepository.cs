using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EY.CabinCrew.Core
{
    public interface IRepository<Entity>
        where Entity: class
    {
        Task<Entity> Find(Func<Entity, bool> predicate);
        Task<List<Entity>> FindAll(Func<Entity, bool>? predicate);
    }
}
