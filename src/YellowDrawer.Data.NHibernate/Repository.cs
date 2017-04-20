using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using YellowDrawer.Data.Common;

namespace YellowDrawer.Data.NH
{
    public class Repository : IRepository
    {
        private readonly ISession _sessionProvider;

        public Repository(ISession sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public ISession Session
        {
            get { return _sessionProvider; }
        }

        public void Add<T>(T item) where T : class, IIdentifiable
        {
            Session.Save(item);
        }

        public void DeleteItem<T>(T item) where T : class, IIdentifiable
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(item);
                transaction.Commit();
            }
        }

        public void Delete<T>(object id) where T : class, IIdentifiable
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(Session.Load<T>(id));
                transaction.Commit();
            }
        }

        public T Find<T>(object id) where T : class, IIdentifiable
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class, IIdentifiable
        {
            return Session.Query<T>().NotDeleted().Where(predicate);
        }

        void IRepository.Update<T>(T item)
        {
            Session.Get<T>(item, LockMode.Upgrade);
        }
    }
}
