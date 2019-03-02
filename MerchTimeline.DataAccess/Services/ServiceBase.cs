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
        private readonly TimelineDbContext _context;

        public ServiceBase(TimelineDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T FirstOrDefault()
        {
            return _context.Set<T>().First();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }

}
