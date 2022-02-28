namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class ClientRepository : IRepository<Client>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> Filter(ISession session, System.Linq.Expressions.Expression<Func<Client, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Client Find(ISession session, System.Linq.Expressions.Expression<Func<Client, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Client Get(ISession session, int id) =>
                  session?.Get<Client>(id);

        public IQueryable<Client> GetAll(ISession session) =>
                  session?.Query<Client>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
