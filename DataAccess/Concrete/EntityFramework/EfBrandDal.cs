using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfBrandDal:IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Brand entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var updatedEntity = carContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarContext carContext = new CarContext() )
            {
                var deletedEntity = carContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();

            }
        }
    }
}
