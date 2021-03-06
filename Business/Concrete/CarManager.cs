﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class CarManager:ICarService
   {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       public List<Car> GetAll()
       {
           return _carDal.GetAll();
       }

       public List<Car> GetAllByGetCarsByBrandId(int id)
       {
           return _carDal.GetAll(p => p.BrandId == id);
       }

       public List<Car> GetCarsByColorId(int id)
       {
           return _carDal.GetAll(p => p.ColorId == id);
       }


       public List<Car> GetCarsByName(decimal min, decimal max)
       {
           return _carDal.GetAll(p => p.DailyPrice <= min && p.DailyPrice >= max);
       }

       public List<CarDetailDto> GetCarDetails()
       {
           return _carDal.GetCarDetails();
       }
   }
}
