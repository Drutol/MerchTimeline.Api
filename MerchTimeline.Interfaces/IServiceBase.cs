using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MerchTimeline.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

    }
}
