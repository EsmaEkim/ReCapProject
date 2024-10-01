using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            //Jobcodes
            //z.B gibt es eine Berechtigung? 
            return _carDal.GetAll(); 
        }

        public List<Car> GetAllByCarId(int id)
        {
            return _carDal.GetAll(c => c.CarId == id);
        }

        public List<Car> GetByModelYear(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(int id)
        {
            return _carDal.GetAll(c => c.DailyPrice>= 0);
        }
    }
}
