using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.AddedError);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetByModelYear(int year)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ModelYear == year));
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.UpdatedError);
            }
            
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedSuccess);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarByColorId(int colorid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(co => co.ColorId == colorid));
        }

        public IDataResult<List<Car>> GetCarByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(br => br.BrandId == brandid));
        }
    }
}
