using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Exceptions;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Interfaces;

namespace MerchTimeline.DataAccess.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        protected readonly TimelineDbContext Context;

        private bool _isOwnedEntity;

        public ServiceBase(TimelineDbContext context)
        {
            Context = context;
            _isOwnedEntity = typeof(IEntityWithOwner).IsAssignableFrom(typeof(T));
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).Count();      
        }

        public IQueryable<T> ForUser(long userId)
        {
            if (_isOwnedEntity)
                return Context.Set<T>().Where(arg => (arg as IEntityWithOwner).OwnerId == userId);

            throw new ArgumentException("Given entity does not have owner.");
        }

        public IQueryable<T> ForUser(AuthenticatedRequestBase request)
        {
            return ForUser(request.UserId);
        }

        public T ForUser(AuthenticatedRequestBase request, long id)
        {
            return ForUser(request).FirstOrDefault(arg => arg.Id == id);
        }

        public T CheckOwnership(AuthenticatedRequestBase request, long id)
        {
            return ForUser(request, id) ??
                   throw new UnauthorizedException($"You don't own {typeof(T).Name} with id {id}");
        }

        public T CheckOwnership(AuthenticatedRequestBase request, long id,
            Func<IQueryable<T>, IQueryable<T>> queryConfigurator)
        {
            return queryConfigurator(ForUser(request.UserId)).FirstOrDefault(arg => arg.Id == id) ??
                   throw new UnauthorizedException($"You don't own {typeof(T).Name} with id {id}");
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
