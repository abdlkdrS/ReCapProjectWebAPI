using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on re.CarId equals c.CarId
                             join cus in context.Customers on re.CustomerId equals cus.CustomerId
                             join us in context.Users on re.CarId equals us.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId,
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 UserName = us.FirstName + " " + us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                             };
                             
                return result.ToList();
            }
        }

    }
}
