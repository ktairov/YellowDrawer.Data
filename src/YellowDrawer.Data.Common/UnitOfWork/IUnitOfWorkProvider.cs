using System.Data;

namespace YellowDrawer.Data.Common.UnitOfWork
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Current { get; }
        IUnitOfWork BeginUnitOfWork();
        IUnitOfWork BeginUnitOfWork(IsolationLevel isolationLevel);
    }
}