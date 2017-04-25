using System;

namespace YellowDrawer.Data.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Success();
    }
}