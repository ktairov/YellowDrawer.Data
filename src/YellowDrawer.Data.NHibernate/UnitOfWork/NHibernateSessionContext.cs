using NHibernate;
using NHibernate.Context;
using System;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public static class NHibernateSessionContext
    {
        public static ISessionFactory Factory { get; set; }
        public static IUnitOfWorkContext UnitOfWorkContext { get; set; }

        public static bool HasCurrentSession
        {
            get { return CurrentSessionContext.HasBind(Factory); }
        }

        public static ISession CurrentOrNewSession
        {
            get
            {
                if (!UnitOfWorkContext.InUnitOfWork)
                    throw new Exception();
                if (HasCurrentSession)
                    return CurrentSession;

                var session = Factory.OpenSession();
                CurrentSessionContext.Bind(session);
                if (UnitOfWorkContext.IsolationLevel.HasValue)
                    session.BeginTransaction(UnitOfWorkContext.IsolationLevel.Value);
                else
                    session.BeginTransaction();
                return session;
            }
        }

        public static ISession CurrentSession
        {
            get
            {
                if (!UnitOfWorkContext.InUnitOfWork)
                    throw new Exception();
                return Factory.GetCurrentSession();
            }
        }

        public static void RemoveCurrentSession()
        {
            CurrentSessionContext.Unbind(Factory);
        }
    }
}