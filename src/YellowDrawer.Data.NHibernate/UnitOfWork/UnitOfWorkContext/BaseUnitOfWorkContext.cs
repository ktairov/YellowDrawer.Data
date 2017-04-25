using System.Data;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public abstract class BaseUnitOfWorkContext : IUnitOfWorkContext
    {
        protected abstract UnitOfWorkContextInfo ContextInfo { get; }

        public bool InUnitOfWork
        {
            get { return ContextInfo.UnitOfWork != null; }
        }

        public IUnitOfWork UnitOfWork
        {
            get { return ContextInfo.UnitOfWork; }
            set { ContextInfo.UnitOfWork = value; }
        }

        public IsolationLevel? IsolationLevel
        {
            get { return ContextInfo.IsolationLevel; }
            set { ContextInfo.IsolationLevel = value; }
        }
    }
}