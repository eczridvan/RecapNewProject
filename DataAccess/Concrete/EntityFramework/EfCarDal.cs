﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal:ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext carContext = new CarContext())
            {
                return filter == null ? carContext.Set<Car>().ToList() : carContext.Set<Car>().Where(filter).ToList();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext carContext = new CarContext())
            {
                return carContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var updatesEntity = carContext.Entry(entity);
                updatesEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext carContext = new CarContext())
            {
                var deletedEntity = carContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }
    }
}