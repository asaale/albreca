using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Albreca.Common.Interfaces.Data;

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
            DetachEntity(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var enumeratedEntities = entities.ToArray();
            _dbSet.AddRange(enumeratedEntities);
            _unitOfWork.Db.SaveChanges();
            DetachEntity(enumeratedEntities);
            return enumeratedEntities;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
            DetachEntity(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            var enumeratedEntities = entities.ToArray();

            _unitOfWork.StartTransaction();

            foreach (var entity in enumeratedEntities)
            {
                _dbSet.Attach(entity);
                _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            }

            _unitOfWork.Commit();

            DetachEntity(enumeratedEntities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _unitOfWork.Db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            var enumeratedEntity = entities.ToArray();

            _unitOfWork.StartTransaction();

            foreach (var entity in enumeratedEntity)
            {
                _dbSet.Remove(entity);
            }

            _unitOfWork.Commit();

            DetachEntity(enumeratedEntity);
        }

        public T Find(Func<T, bool> filterCriteria)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(filterCriteria);
        }

        public IEnumerable<T> FindMany(Func<T, bool> filterCriteria)
        {
            return _dbSet.AsNoTracking().Where(filterCriteria).ToList();
        }

        private void DetachEntity(params T[] entities)
        {
            for (int i = 0; i < entities.Count(); i++)
            {
                _unitOfWork.Db.Entry(entities[i]).State = EntityState.Detached;
            }
        }
    }


}