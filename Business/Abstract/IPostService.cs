using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);

        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetById(int postId);
        IDataResult<Post> GetByCategryId(int categoryId);
    }
}
