using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetAllByGetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<Car> GetCarsByName(decimal min, decimal max);
    }
}
