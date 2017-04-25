using System.Data;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public class UnitOfWorkContextInfo
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IsolationLevel? IsolationLevel { get; set; }
    }
}