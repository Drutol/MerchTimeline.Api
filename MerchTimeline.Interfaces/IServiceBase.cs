using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests;

namespace MerchTimeline.Interfaces
{
    public interface IServiceBase<T> where T : EntityBase
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        IQueryable<T> ForUser(AuthenticatedRequestBase request);
        T ForUser(AuthenticatedRequestBase request, long id);
        T CheckOwnership(AuthenticatedRequestBase request, long id);
        T CheckOwnership(AuthenticatedRequestBase request, long id, Func<IQueryable<T>,IQueryable<T>> queryConfigurator);

        int Count();
        int Count(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

    }
}
