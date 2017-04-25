using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using YellowDrawer.Data.Common;
using YellowDrawer.Data.Common.UnitOfWork;
using YellowDrawer.Data.EF;
using YellowDrawer.Data.Simple;

namespace YellowDrawer.Data.Test
{
    [TestClass]
    public class EFTests
    {
        private IRepository entityFramworkRepository;
        private IUnitOfWorkProvider provider;
        private const string NameItem = "SipleEFTest";

        [TestInitialize, TestCategory("Unit")]
        public void Initialize()
        {
            entityFramworkRepository = new Repository(new EFContext());
            provider = new EF.UnitOfWork.UnitOfWorkProvider();
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessCreateItem()
        {
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                entityFramworkRepository.Add(new ExampleTabel() { Name = NameItem });
                unitOfWork.Success();
            }
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                var item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == NameItem).FirstOrDefault();
                Assert.IsNotNull(item);
                entityFramworkRepository.DeleteItem(item);
                unitOfWork.Success();
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void SuccessDeleteItem()
        {
            ExampleTabel item = null;
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                entityFramworkRepository.Add(new ExampleTabel() { Name = NameItem });
                item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == NameItem).FirstOrDefault();
                unitOfWork.Success();
            }
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                entityFramworkRepository.DeleteItem(item);
                unitOfWork.Success();
            }
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                var deletedItem = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == NameItem).FirstOrDefault();
                Assert.IsNull(deletedItem);
                unitOfWork.Success();
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void FindNullItem()
        {
            using (var unitOfWork = provider.BeginUnitOfWork())
            {
                var item = entityFramworkRepository.Find<ExampleTabel>(x => x.Name == "SipleTestEFFindNull").FirstOrDefault();
                Assert.IsNull(item);
                unitOfWork.Success();
            }
        }
    }
}
