using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenOption _tokenOption;
        public AuthManager(IUserService userService, ITokenOption tokenOption)
        {
            _userService = userService;
            _tokenOption = tokenOption;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenOption.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(token,Messages.CreateToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash))
            {
                return new ErrorDataResult<User>(Messages.ErrorLogin);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulyLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegister)
        {
            byte[] passwordHash, passwordSalt;

            var userCheck = _userService.GetByMail(userForRegister.Email);
            if (userCheck!=null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExist);
            }
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordSalt, out passwordHash);
            try
            {
                var user = new User
                {
                    FirstName = userForRegister.FirstName,
                    LastName = userForRegister.LastName,
                    Email = userForRegister.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    UserName = userForRegister.UserName,
                   
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user,Messages.SuccessRegistered);
            }
            catch (Exception)
            {

                return new  ErrorDataResult<User>(Messages.ErrorRegistered);
            }
           
        }

        public IResult UserToCheck(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
