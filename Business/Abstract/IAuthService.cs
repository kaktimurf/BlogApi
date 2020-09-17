using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IDataResult<User> Register(UserForRegisterDto userForRegister);
        IResult UserToCheck(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
