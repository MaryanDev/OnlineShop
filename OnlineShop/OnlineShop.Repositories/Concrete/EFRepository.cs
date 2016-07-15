using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Repositories.Abstract;
using OnlineShop.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace OnlineShop.Repositories.Concrete
{
    public class EFRepository : IRepository
    {
        public void Delete<TEntity>(Func<TEntity, bool> criteria) where TEntity : class
        {
            using(var context = new ShopEntities())
            {
                context.Set<TEntity>().Remove(context.Set<TEntity>().SingleOrDefault<TEntity>(criteria));
                context.SaveChanges();
            }
        }

        public bool Exists<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class
        {
            TEntity resultEntity;
            using (var context = new ShopEntities())
            {
                resultEntity = context.Set<TEntity>().SingleOrDefault<TEntity>(criteria);
            }
            return resultEntity == null ? false : true;
        }

        public IEnumerable<TEntity> Get<TEntity>(Func<TEntity, bool> criteria = null, params Expression<Func<TEntity, object>>[] paths) where TEntity : class
        {
            using(var context = new ShopEntities())
            {
                IQueryable<TEntity> query =  context.Set<TEntity>();
                query = IncludePaths(paths, query);

                if (criteria != null)
                {
                    query = query.Where(criteria).AsQueryable();
                }
                return query.ToList();
            }
        }

        public TEntity GetSingle<TEntity>(Func<TEntity, bool> criteria = null, params Expression<Func<TEntity, object>>[] paths) where TEntity : class
        {
            using (var context = new ShopEntities())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                query = IncludePaths(paths, query);

                if (criteria != null)
                {
                    query = query.Where(criteria).AsQueryable();
                }
                return query.SingleOrDefault();
            }
        }

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
            TEntity insertedEntity = null;
            using (var context = new ShopEntities())
            {
                insertedEntity = context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return insertedEntity;
            }
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            using(var context = new ShopEntities())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
                return entity;
            }
        }

        private IQueryable<TEntity> IncludePaths<TEntity>(Expression<Func<TEntity, object>>[] paths, IQueryable<TEntity> query) where TEntity : class
        {
            if (paths != null)
            {
                foreach (var path in paths)
                {
                    query = query.Include(path);
                }
            }
            return query;
        }
    }
}
