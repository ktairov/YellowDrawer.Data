# YellowDrawer.Data

[![Build status](https://ci.appveyor.com/api/projects/status/hrvftvurr85l2lxq?svg=true)](https://ci.appveyor.com/project/AlexeyKharchenko/yellowdrawer-data) [![NuGet](https://img.shields.io/nuget/v/YellowDrawer.Data.Common.svg)](https://www.nuget.org/packages/YellowDrawer.Data.Common/) 


## Install

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [YellowDrawer EntityFramework](https://www.nuget.org/packages/YellowDrawer.Data.EF/) or [YellowDrawer NHibernate](https://www.nuget.org/packages/YellowDrawer.Data.NH/) from the package manager console:

```
PM> YellowDrawer.Data.EF
```

```
PM> YellowDrawer.Data.NH
```

The latest versions of the required frameworks are automatically installed (YellowDrawer.Data.Common and EntityFramework or NHibernate)


## Initialize EntityFramework Repository

Add connection string to config file and create DbContext and initialize Repository and UnitOfWorkProvider:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			var entityFramworkRepository = new Repository(new EFContext());
			var entityFramworkProvider = new UnitOfWorkProvider();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

## Initialize NHibernate Repository

Add `<hibernate-configuration>` to config file
Set `<property name="current_session_context_class">thread_static</property>`
Set fields to NHibernateSessionContext

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			var cfg = new NHibernate.Cfg.Configuration();
			NHibernateSessionContext.Factory = cfg.Configure().BuildSessionFactory();
			NHibernateSessionContext.UnitOfWorkContext = new ThreadStaticUnitOfWorkContext();
			NHibernateSessionContext.UnitOfWorkContext.UnitOfWork = new UnitOfWork();
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


## Actions Repository

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			void Add<T>(T item) where T : class, IIdentifiable;

			void Update<T>(T item) where T : class, IIdentifiable;

			void DeleteItem<T>(T item) where T : class, IIdentifiable;

			void Delete<T>(object id) where T : class, IIdentifiable;

			T Find<T>(object id) where T : class, IIdentifiable;

			IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class, IIdentifiable;
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

## Usege UnitOfWork

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			using (var unitOfwork = provider.BeginUnitOfWork())
			{
				//Actions Repository
				unitOfwork.Success();
			}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

