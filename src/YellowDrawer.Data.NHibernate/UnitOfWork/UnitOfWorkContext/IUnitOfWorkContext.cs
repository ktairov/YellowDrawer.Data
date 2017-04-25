using System.Data;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public interface IUnitOfWorkContext
    {
        bool InUnitOfWork { get; }
        IUnitOfWork UnitOfWork { get; set; }
        IsolationLevel? IsolationLevel { get; set; }
    }
}