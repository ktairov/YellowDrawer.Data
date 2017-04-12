using System;
using System.Linq;
using System.Linq.Expressions;
using YellowDrawer.Data.NH.SoftDeletion;

namespace YellowDrawer.Data.NH
{
    public static class DeletableQueries
    {
        private static readonly Expression<Func<IDeletable, object>> DeletedKeyProp = d => d.DeletedKey;
        private static readonly string DeletedKeyPropName = DeletedKeyProp.GetPropertyName();

        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> query)
        {
            return typeof(IDeletable).IsAssignableFrom(typeof(T)) ? query.Where(DeletedKeyNull<T>()) : query;
        }

        public static IQueryable<T> Deleted<T>(this IQueryable<T> query)
        {
            return typeof(IDeletable).IsAssignableFrom(typeof(T)) ? query.Where(DeletedKeyNotNull<T>()) : query;
        }

        private static Expression<Func<T, bool>> DeletedKeyNull<T>()
        {
            var parameter = Expression.Parameter(typeof(T), "x"); // x
            var property = Expression.Property(parameter, DeletedKeyPropName); // x.DeletedKey
            var constant = Expression.Constant(null);
            var equal = Expression.Equal(property, constant); // x.DeletedKey == null

            return Expression.Lambda<Func<T, bool>>(equal, parameter); // x => x.DeletedKey == null
        }

        private static Expression<Func<T, bool>> DeletedKeyNotNull<T>()
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, DeletedKeyPropName);
            var constant = Expression.Constant(null);
            var equal = Expression.NotEqual(property, constant);

            return Expression.Lambda<Func<T, bool>>(equal, parameter);
        }
    }
}
