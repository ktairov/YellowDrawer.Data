using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using YellowDrawer.Data.Common;

namespace YellowDrawer.Data.EF
{
    public class Repository : IRepository
    {
        private DbContext _context { get; set; }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add<T>(T item) where T : class, IIdentifiable
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete<T>(object id) where T : class, IIdentifiable
        {
            var item = Find<T>(id);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void DeleteItem<T>(T item) where T : class, IIdentifiable
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class, IIdentifiable
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Find<T>(object id) where T : class, IIdentifiable
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        void IRepository.Update<T>(T item)
        {
            _context.SaveChanges();
        }
    }
}
