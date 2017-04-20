using System;
using System.Linq;
using YellowDrawer.Data.Common;

namespace YellowDrawer.Data.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new NHibernate.Cfg.Configuration();
            var sessionFactory = cfg.Configure().BuildSessionFactory();
            var nHibernateRepository = new NH.Repository(sessionFactory.OpenSession());
            var entityFramworkRepository = new EF.Repository(new EFContext());
            TestRepository(nHibernateRepository, "NHibernate Repository");
            TestRepository(entityFramworkRepository, "EntityFramwork Repository");
            Console.ReadKey();
        }

        static void TestRepository(IRepository repository, string nameRepository)
        {
            Console.WriteLine("********* " + nameRepository + " ****************");
            Console.WriteLine("Add item");
            repository.Add(new ExampleTabel() { Name = "SipleTest" });
            Console.WriteLine("Find item");
            var item = repository.Find<ExampleTabel>(x => x.Name == "SipleTest").FirstOrDefault();
            if (item != null)
            {
                Console.WriteLine("Item exist");
                Console.WriteLine("Delete item");
                repository.DeleteItem<ExampleTabel>(item);
            }
            else
                Console.WriteLine("Item not exist");
        }
    }
}
