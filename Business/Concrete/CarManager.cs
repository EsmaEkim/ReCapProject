using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;

        public CarManager(ICarDal carDal,IColorService colorService)
        {
            _carDal = carDal;
            


        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            IResult result = BusinessRules.Run(CheckIfColorOfCarCorrect(car.ColorId),
                CheckIfColorExists(car.ColorId),
                CheckIfColorLimitExceded());
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);


        }

        public IDataResult<List<Car>> GetAll()
        {
            //Jobcodes
            //z.B gibt es eine Berechtigung ?
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

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

        private IResult CheckIfColorExists(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorLimitExceded()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count>5)
            {
                return new ErrorResult(Messages.ColorLimitExceded);

            }
            return new SuccessResult();
            

            
        }
    }
}
