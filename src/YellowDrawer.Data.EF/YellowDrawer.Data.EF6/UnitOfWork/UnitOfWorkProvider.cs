using System.Data;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.EF.UnitOfWork
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private UnitOfWork unitOfWork;
        public IUnitOfWork Current => unitOfWork;

        public IUnitOfWork BeginUnitOfWork()
        {
            return new UnitOfWork();
        }

        public IUnitOfWork BeginUnitOfWork(IsolationLevel isolationLevel)
        {
            return new UnitOfWork(isolationLevel);
        }
    }
}
