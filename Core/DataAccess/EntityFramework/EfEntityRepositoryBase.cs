using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
     where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext carContext = new TContext())
            {
                return filter == null ? carContext.Set<TEntity>().ToList() : carContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext carContext = new TContext())
            {
                return carContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var updatesEntity = carContext.Entry(entity);
                updatesEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var deletedEntity = carContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }

    }
}
