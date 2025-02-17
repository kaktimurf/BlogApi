﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);

        IDataResult<List<Comment>> GetAll();
        IDataResult<Comment> GetById(int commentId);
        IDataResult<Comment> GetByPostId(int postId);
    }
}
