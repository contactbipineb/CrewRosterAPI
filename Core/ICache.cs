using System;

namespace EY.CabinCrew.Caching
{
    public interface ICache<TKey, TEntity>
    {
        Func<TKey, TEntity> Factory { get; }
        TEntity Get(TKey key);
        void Set(TKey key, TEntity value);
    }
}
