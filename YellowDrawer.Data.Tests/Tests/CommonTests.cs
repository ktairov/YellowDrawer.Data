using YellowDrawer.Data.Common;
using YellowDrawer.Data.Simple;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YellowDrawer.Data.Tests.Tests
{
    public class CommonTests
    {
        public void SuccessAddNewItem(IRepository repository)
        {
            repository.Add(new ExampleTabel() { Name = "UnitTest" });
            var item =  repository.Find<ExampleTabel>(x => x.Name == "UnitTest").FirstOrDefault();
            Assert.IsNotNull(item);
            repository.DeleteItem(item);
        }

        public void Success(IRepository repository)
        {
            repository.Add(new ExampleTabel() { Name = "UnitTest" });
            var item = repository.Find<ExampleTabel>(x => x.Name == "UnitTest").FirstOrDefault();
            Assert.IsNotNull(item);
            repository.DeleteItem(item);
        }
    }
}
