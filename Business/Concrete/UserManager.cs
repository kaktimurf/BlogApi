using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.SuccessAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorAdded);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.SuccessDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorDeleted);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {

                return new SuccessDataResult<List<User>>(_userDal.GetList(), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<User>>(Messages.ErrorGetList);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            try
            {

                return new SuccessDataResult<User>(_userDal.Get(c => c.Id == userId), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<User>(Messages.ErrorGetList);
            }
        }

        public User GetByMail(string email)
        {

            return _userDal.Get(u => u.Email == email);

        }

        public List<OperationClaim> GetClaims(User user)
        {

               return _userDal.GetClaims(user);   
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.SuccessUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorUpdated);
            }
        }
    }
}
