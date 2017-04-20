using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YellowDrawer.Data.Common;
using System.Linq;
using YellowDrawer.Data.Simple;

namespace YellowDrawer.Data.Test
{
    [TestClass]
    public class NHTests
    {
        private IRepository nHibernateRepository;

        [TestInitialize, TestCategory("Unit")]
        public void Initialize()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            var sessionFactory = cfg.Configure().BuildSessionFactory();
            nHibernateRepository = new NH.Repository(sessionFactory.OpenSession());
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessCreateItem()
        {
            nHibernateRepository.Add(new ExampleTabel() { Name = "SipleTest" });
            var item = nHibernateRepository.Find<ExampleTabel>(x => x.Name == "SipleTest").FirstOrDefault();
            Assert.IsNotNull(item);
            nHibernateRepository.DeleteItem(item);
        }

        [TestMethod, TestCategory("Unit")]
        public void FindNullItem()
        {
            var item = nHibernateRepository.Find<ExampleTabel>(x => x.Name == "SipleTestFindNull").FirstOrDefault();
            Assert.IsNull(item);
        }
    }
}
