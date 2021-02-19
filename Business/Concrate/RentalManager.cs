using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = ReturnDateCheck(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult();
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail(int carid)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(x => x.CarId == carid));
        }

        public IResult ReturnDateCheck(int carid)
        {
            var result = _rentalDal.GetAll(x => x.CarId == carid && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {   
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
