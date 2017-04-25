using Microsoft.VisualStudio.TestTools.UnitTesting;
using YellowDrawer.Data.Common;
using System.Linq;
using YellowDrawer.Data.Simple;
using YellowDrawer.Data.NH.UnitOfWork;
using YellowDrawer.Data.Common.UnitOfWork;

namespace YellowDrawer.Data.Test
{
    [TestClass]
    public class NHTests
    {
        private IRepository nHibernateRepository;
        private IUnitOfWorkProvider provider;
        private const string NameItem = "SipleNHTest";

        [TestInitialize, TestCategory("Unit")]
        public void Initialize()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            NHibernateSessionContext.Factory = cfg.Configure().BuildSessionFactory();
            NHibernateSessionContext.UnitOfWorkContext = new ThreadStaticUnitOfWorkContext();
            NHibernateSessionContext.UnitOfWorkContext.UnitOfWork = new UnitOfWork();
            nHibernateRepository = new NH.Repository();
            provider = new UnitOfWorkProvider();
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessCreateItem()
        {
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                nHibernateRepository.Add(new ExampleTabel() { Name = NameItem });
                unitOfWork.Success();
            }
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                var item = nHibernateRepository.Find<ExampleTabel>(x => x.Name == NameItem).FirstOrDefault();
                Assert.IsNotNull(item);
                nHibernateRepository.DeleteItem(item);
                unitOfWork.Success();
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void FindNullItem()
        {
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                var item = nHibernateRepository.Find<ExampleTabel>(x => x.Name == "SipleNHTestFindNull").FirstOrDefault();
                Assert.IsNull(item);
                unitOfWork.Success();
            }
        }
    }
}
