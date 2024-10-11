using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from re in context.Rentals
                             join cu in context.Customers on re.RentalId equals cu.CustomerId
                             join us in context.Users on re.RentalId equals us.UserId
                             join c in context.Cars on re.RentalId equals c.CarId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 UserId = us.UserId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
