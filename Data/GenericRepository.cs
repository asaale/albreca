using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Albreca.Common.Interfaces.Data;
using Albreca.Common.Interfaces.Marker;

namespace Albreca.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Db.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var enumeratedEntities = entities.ToList();
            _dbSet.AddRange(enumeratedEntities);
            _unitOfWork.Db.SaveChanges();
            return enumeratedEntities;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _unitOfWork.StartTransaction();

            foreach (var entity in entities)
            {
                _dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }

            _unitOfWork.Commit();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _unitOfWork.Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _unitOfWork.StartTransaction();

            foreach (var entity in entities)
            {
                _dbSet.Remove(entity);
            }

            _unitOfWork.Commit();
        }

        public T Find(Func<T, bool> filterCriteria)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(filterCriteria);
        }

        public IEnumerable<T> FindMany(Func<T, bool> filterCriteria)
        {
            return _dbSet.AsNoTracking().Where(filterCriteria);
        }
    }


}