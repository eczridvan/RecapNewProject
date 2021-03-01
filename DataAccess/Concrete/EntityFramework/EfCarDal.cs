using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext carContext = new CarContext())
            {
                var result = from c in carContext.Cars
                    join b in carContext.Brands
                        on c.BrandId equals b.BrandId
                    select new CarDetailDto()
                    {
                        CarName = c.Description,
                        BrandName = b.Name,

                    };
                return result.ToList();
            }
        }
    }
}
