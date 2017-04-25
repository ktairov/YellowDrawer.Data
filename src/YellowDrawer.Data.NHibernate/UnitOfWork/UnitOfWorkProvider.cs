using System.Data;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork BeginUnitOfWork()
        {
            return NHibernateSessionContext.UnitOfWorkContext.UnitOfWork = new UnitOfWork();
        }

        public IUnitOfWork BeginUnitOfWork(IsolationLevel isolationLevel)
        {
            NHibernateSessionContext.UnitOfWorkContext.IsolationLevel = isolationLevel;
            return BeginUnitOfWork();
        }

        public IUnitOfWork Current
        {
            get { return NHibernateSessionContext.UnitOfWorkContext.UnitOfWork; }
        }
    }
}