using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfColorDal:IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Color entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();

            }
        }

        public void Update(Color entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var updatesEntity = carContext.Entry(entity);
                updatesEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
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
