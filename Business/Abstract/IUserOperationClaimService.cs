using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);

        IDataResult<UserOperationClaim> GetAll();
        IDataResult<UserOperationClaim> GetById(int userOperationClaimId);
    }
}
