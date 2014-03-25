using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using print.Models.DAL;
using System.Linq.Expressions;

namespace print.Models.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private SenderContext _senderContext;

        public List<T> LoadEntities(Expression<Func<T, bool>> query)
        {
            using (_senderContext = new SenderContext())
            {
                return _senderContext.Set<T>().Where<T>(query).AsQueryable().ToList();
            }
        }

        public T LoadEntity(Expression<Func<T, bool>> query)
        {
            List<T> results = _senderContext.Set<T>().Where<T>(query).AsQueryable().ToList();
            if (null != results && results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }
        }

        public bool AddEntity(T entity)
        {
            using (_senderContext = new SenderContext())
            {
                _senderContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
                return _senderContext.SaveChanges() > 0;
            }
        }

        public bool UpdateEntity(T entity)
        {
            using (_senderContext = new SenderContext())
            {
                _senderContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                return _senderContext.SaveChanges() > 0;
            }
        }
    }
}