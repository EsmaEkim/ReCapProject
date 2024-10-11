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
    public class EfUserDal : EfEntityRepositoryBase<User, CarContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from us in context.Users
                             join cu in context.Customers
                             on us.UserId equals cu.CustomerId
                             select new UserDetailDto { UserId = us.UserId, FirstName = us.FirstName, LastName = us.LastName, CompanyName = cu.CompanyName, Email = us.Email, Password = us.Password };
                return result.ToList();
            }
        }
    }
}
