.NET SDK for YellowDrawer.Data.
===============================

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

    void Add\<T\>(T item) where T : class, IIdentifiable;

    void Update\<T\>(T item) where T : class, IIdentifiable;

void DeleteItem\<T\>(T item) where T : class, IIdentifiable;

void Delete\<T\>(object id) where T : class, IIdentifiable;

T Find\<T\>(object id) where T : class, IIdentifiable;

IQueryable\<T\> Find\<T\>(Expression\<Func\<T, bool\>\> predicate) where T :
class, IIdentifiable;
