namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class TourRepository : IRepository<Tour>
    {
        public Tour Get(ISession session, int id) =>
            session?.Get<Tour>(id);

        public Tour Find(ISession session, Expression<Func<Tour, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Tour> GetAll(ISession session) =>
            session?.Query<Tour>();

        public IQueryable<Tour> Filter(ISession session, Expression<Func<Tour, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
