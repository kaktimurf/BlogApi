using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);

        IDataResult<OperationClaim> GetAll();
        IDataResult<OperationClaim> GetById(int operationClaimId);
    }
}
