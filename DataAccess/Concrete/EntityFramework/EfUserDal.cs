using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BlogContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new BlogContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where user.Id == userOperationClaim.UserId
                             select new OperationClaim { Id = operationClaim.Id, ClaimName = operationClaim.ClaimName };
                            
                return result.ToList();
            }
        }
    }
}
