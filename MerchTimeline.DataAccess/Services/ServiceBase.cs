using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MerchTimeline.Interfaces;

namespace MerchTimeline.DataAccess.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly TimelineDbContext Context;

        public ServiceBase(TimelineDbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).Count();      
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public T FirstOrDefault()
        {
            return Context.Set<T>().First();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsQueryable();
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }

}
