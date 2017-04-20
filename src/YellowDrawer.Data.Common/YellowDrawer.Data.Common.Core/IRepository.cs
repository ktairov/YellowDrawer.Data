using System;
using System.Linq;
using System.Linq.Expressions;

namespace YellowDrawer.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class, IIdentifiable;
        void Update<T>(T item) where T : class, IIdentifiable;
        void DeleteItem<T>(T item) where T : class, IIdentifiable;
        void Delete<T>(object id) where T : class, IIdentifiable;
        T Find<T>(object id) where T : class, IIdentifiable;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class, IIdentifiable;
    }
}