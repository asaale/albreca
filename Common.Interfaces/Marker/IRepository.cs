using System;
using System.Collections.Generic;

namespace Albreca.Common.Interfaces.Marker
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        T Find(Func<T, bool> filterCriteria);
        IEnumerable<T> FindMany(Func<T, bool> filterCriteria);
    }
}