.NET SDK for YellowDrawer.Data.
===============================

<https://ci.appveyor.com/project/AlexeyKharchenko/yellowdrawer-data>

YellowDrawer.Data.Common
[![Build status](https://ci.appveyor.com/api/projects/status/hrvftvurr85l2lxq?svg=true)](https://ci.appveyor.com/project/AlexeyKharchenko/yellowdrawer-data)

YellowDrawer.Data.EF [![NuGet](https://img.shields.io/nuget/v/YellowDrawer.Data.Common.svg)](https://www.nuget.org/packages/YellowDrawer.Data.Common/)

YellowDrawer.Data.NH [![NuGet](https://img.shields.io/nuget/v/YellowDrawer.Data.NH.svg)](https://www.nuget.org/packages/YellowDrawer.Data.NH/)

 

.NET library for work with EntityFramework and NHibernate repositories

 

DIRECTORY STRUCTURE -------------------

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
YellowDrawer.Data.Common                core wrapper code
YellowDrawer.Data.GridFS
YellowDrawer.Data.Azure
YellowDrawer.Data.Simple      example project
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

 
-

USAGE
=====

Actions
-------

###  

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
void Add\<T\>(T item) where T : class, IIdentifiable;

void Update\<T\>(T item) where T : class, IIdentifiable;
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

void DeleteItem\<T\>(T item) where T : class, IIdentifiable;

void Delete\<T\>(object id) where T : class, IIdentifiable;

T Find\<T\>(object id) where T : class, IIdentifiable;

IQueryable\<T\> Find\<T\>(Expression\<Func\<T, bool\>\> predicate) where T :
class, IIdentifiable;
