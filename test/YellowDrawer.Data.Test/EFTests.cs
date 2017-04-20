using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using YellowDrawer.Data.Common;
using YellowDrawer.Data.EF;
using YellowDrawer.Data.Simple;

namespace YellowDrawer.Data.Test
{
    [TestClass]
    public class EFTests
    {
        private IRepository entityFramworkRepository;

        [TestInitialize, TestCategory("Unit")]
        public void Initialize()
        {
            entityFramworkRepository = new Repository(new EFContext());
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessCreateItem()
        {
            entityFramworkRepository.Add(new ExampleTabel() { Name = "SipleTest" });
            var item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == "SipleTest").FirstOrDefault();
            Assert.IsNotNull(item);
            entityFramworkRepository.DeleteItem(item);
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessDeleteItem()
        {
            entityFramworkRepository.Add(new ExampleTabel() { Name = "SipleTest" });
            var item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == "SipleTest").FirstOrDefault();
            entityFramworkRepository.DeleteItem(item);
            entityFramworkRepository.Update(item);
            var deletedItem = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == "SipleTest").FirstOrDefault();
            Assert.IsNull(deletedItem);
        }

        [TestMethod, TestCategory("Unit")]
        public void FindNullItem()
        {
            var item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == "SipleTestFindNull").FirstOrDefault();
            Assert.IsNull(item);
        }
    }
}
