using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public IResult Add(User user)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<List<User>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserUpdated);
        }
    }
}
