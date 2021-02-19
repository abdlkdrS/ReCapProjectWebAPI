using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);

        IResult Delete(Rental rental);

        IResult Update(Rental rental);

        IResult ReturnDateCheck(int carid);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetail(int carid);
    }
}
