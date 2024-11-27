using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            if (CheckIfColorOfCarCorrect(car.ColorId).Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }

            return new ErrorResult();


        }

        public IDataResult<List<Car>> GetAll()
        {
            //Jobcodes
            //z.B gibt es eine Berechtigung?
            //if (DateTime.Now.Hour == 6)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByCarId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetByModelYear(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }



        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c => c.CarId == car.CarId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ColorCountOfCarError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfColorOfCarCorrect(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId  == colorId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ColorCountOfCarError);
            }
            return new SuccessResult();
        }
    }
}
