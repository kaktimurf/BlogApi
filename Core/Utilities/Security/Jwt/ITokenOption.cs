using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenOption
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaim);
    }
}
