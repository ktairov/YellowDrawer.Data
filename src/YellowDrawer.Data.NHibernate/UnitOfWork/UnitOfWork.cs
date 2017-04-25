using System;
using NHibernate;
using NHibernate.Transaction;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Success()
        {
            WithCurrentSession(session => session.Transaction.Commit());
        }

        public void Dispose()
        {
            WithCurrentSession(session =>
            {
                session.Dispose();
                NHibernateSessionContext.RemoveCurrentSession();
            });
            NHibernateSessionContext.UnitOfWorkContext.UnitOfWork = null;
        }

        public void WithCurrentSession(Action<ISession> action)
        {
            if (NHibernateSessionContext.HasCurrentSession)
                action(NHibernateSessionContext.CurrentSession);
        }

        private class FailSynchronization : ISynchronization
        {
            private readonly Action _onFail;

            public FailSynchronization(Action onFail)
            {
                _onFail = onFail;
            }

            public void BeforeCompletion()
            {
            }

            public void AfterCompletion(bool success)
            {
                if (!success) _onFail();
            }
        }

        private class SuccessSynchronization : ISynchronization
        {
            private readonly Action _onSuccess;

            public SuccessSynchronization(Action onSuccess)
            {
                _onSuccess = onSuccess;
            }

            public void BeforeCompletion()
            {
            }

            public void AfterCompletion(bool success)
            {
                if (success) _onSuccess();
            }
        }
    }
}