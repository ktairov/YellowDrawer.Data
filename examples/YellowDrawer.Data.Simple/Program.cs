using System;
using System.Linq;
using YellowDrawer.Data.Common;
using YellowDrawer.Data.Common.UnitOfWork;
using YellowDrawer.Data.NH.UnitOfWork;

namespace YellowDrawer.Data.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new NHibernate.Cfg.Configuration();
            NHibernateSessionContext.Factory = cfg.Configure().BuildSessionFactory();
            NHibernateSessionContext.UnitOfWorkContext = new ThreadStaticUnitOfWorkContext();
            NHibernateSessionContext.UnitOfWorkContext.UnitOfWork = new UnitOfWork();

            var nHibernateRepository = new NH.Repository();
            var nHibernateProvider = new UnitOfWorkProvider();
            TestRepository(nHibernateRepository, nHibernateProvider, "NHibernate Repository");


            var entityFramworkRepository = new EF.Repository(new EFContext());
            var entityFramworkProvider = new EF.UnitOfWork.UnitOfWorkProvider();

            TestRepository(entityFramworkRepository, entityFramworkProvider, "EntityFramwork Repository");


            Console.ReadKey();
        }

        static void TestRepository(IRepository repository, IUnitOfWorkProvider provider, string nameRepository)
        {
            Console.WriteLine("********* " + nameRepository + " ****************");
            var name = "TestRepositoryItem";

            using (var unitOfwork = provider.BeginUnitOfWork())
            {
                TestAddRepository(repository, name);
                unitOfwork.Success();
            }
            ExampleTabel item = null;
            using (var unitOfwork = provider.BeginUnitOfWork())
            {
                item = TestFindRepository(repository, name);
                unitOfwork.Success();
            }
            if (item != null)
            {
                Console.WriteLine("Item exist");
                using (var unitOfwork = provider.BeginUnitOfWork())
                {
                    TestDeleteRepository(repository, item);
                    unitOfwork.Success();
                }
            }
            else
                Console.WriteLine("Item not exist");

            using (var unitOfwork = provider.BeginUnitOfWork())
            {
                var deletedItem = TestFindRepository(repository, name);
                unitOfwork.Success();
                if (deletedItem != null)
                {
                    Console.WriteLine("Item exist");
                }
                else
                    Console.WriteLine("Item not exist");
            }
        }


        static void TestAddRepository(IRepository repository, string name)
        {
            Console.WriteLine("Add item");
            repository.Add(new ExampleTabel() { Name = name });
        }

        static ExampleTabel TestFindRepository(IRepository repository, string name)
        {
            Console.WriteLine("Find item");
            return repository.Find<ExampleTabel>(x => x.Name == name).FirstOrDefault();
        }

        static void TestDeleteRepository(IRepository repository, ExampleTabel item)
        {
            Console.WriteLine("Delete item");
            repository.DeleteItem(item);
        }
    }
}
