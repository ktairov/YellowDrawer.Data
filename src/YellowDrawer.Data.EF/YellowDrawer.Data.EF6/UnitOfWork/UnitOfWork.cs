using System.Transactions;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            transactionScope = new TransactionScope();
        }

        public UnitOfWork(System.Data.IsolationLevel isolationLevel)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = (IsolationLevel)isolationLevel;
            transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        private TransactionScope transactionScope { get; set; }

        public void Dispose()
        {
            if (transactionScope != null)
                transactionScope.Dispose();
        }

        public void Success()
        {
            if (transactionScope != null)
                transactionScope.Complete();
        }
    }
}
