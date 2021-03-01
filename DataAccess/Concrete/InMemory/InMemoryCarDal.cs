using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
   {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 500000, ModelYear= "2021", Description = "AUID"},
                new Car{CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 400000, ModelYear = "2020", Description = "MERCEDES"},
                new Car{CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 600000, ModelYear = "2020", Description = "MERCEDES"},
                new Car{CarId = 4, BrandId = 3, ColorId = 2, DailyPrice = 300000, ModelYear = "2018", Description = "BMW"},
                new Car{CarId = 5, BrandId = 3, ColorId = 2, DailyPrice = 200000, ModelYear = "2012", Description = "BMW"},
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car uptadeCar = _cars.FirstOrDefault(p => p.CarId == car.CarId);

            uptadeCar.BrandId = car.BrandId;
            uptadeCar.ColorId = car.ColorId;
            uptadeCar.DailyPrice = car.DailyPrice;
            uptadeCar.ModelYear = car.ModelYear;
            uptadeCar.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.FirstOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(deleteCar);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }
    }
}
