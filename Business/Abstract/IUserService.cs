﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        User GetByMail(string email);
     List<OperationClaim> GetClaims(User user);
    }
}
