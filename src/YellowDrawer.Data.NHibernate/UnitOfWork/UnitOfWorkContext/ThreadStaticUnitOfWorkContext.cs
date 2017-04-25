using System;

namespace YellowDrawer.Data.NH.UnitOfWork
{
    public class ThreadStaticUnitOfWorkContext : BaseUnitOfWorkContext
    {
        [ThreadStatic] private static UnitOfWorkContextInfo _unitOfWorkContextInfo;

        protected override UnitOfWorkContextInfo ContextInfo
        {
            get { return _unitOfWorkContextInfo ?? (_unitOfWorkContextInfo = new UnitOfWorkContextInfo()); }
        }
    }
}