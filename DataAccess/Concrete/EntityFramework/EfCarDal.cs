using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.CarId equals b.BrandId
                             join co in context.Colors on c.CarId equals co.ColorId
                             select new CarDetailDto {CarId=c.CarId, CarName=c.CarName, BrandName=b.BrandName, ModelYear= c.ModelYear, DailyPrice= c.DailyPrice, Description=c.Description, ColorName= co.ColorName  };
                return result.ToList();
            }
        }
    }
}
