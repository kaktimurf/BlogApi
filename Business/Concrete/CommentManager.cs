using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IResult Add(Comment comment)
        {
            try
            {
                _commentDal.Add(comment);
                return new SuccessResult(Messages.SuccessAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorAdded);
            }
        }

        public IResult Delete(Comment comment)
        {
            try
            {
                _commentDal.Delete(comment);
                return new SuccessResult(Messages.SuccessDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorDeleted);
            }
        }

        public IDataResult<List<Comment>> GetAll()
        {
            try
            {

                return new SuccessDataResult<List<Comment>>(_commentDal.GetList(), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Comment>>(Messages.ErrorGetList);
            }
        }

        public IDataResult<Comment> GetById(int commentId)
        {
            try
            {

                return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == commentId), Messages.SuccessGetById);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Comment>(Messages.ErrorGetById);
            }
        }

        public IDataResult<Comment> GetByPostId(int postId)
        {
            try
            {

                return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == postId), Messages.SuccessGetById);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Comment>(Messages.ErrorGetById);
            }
        }

        public IResult Update(Comment comment)
        {
            try
            {
                _commentDal.Update(comment);
                return new SuccessResult(Messages.SuccessUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorUpdated);
            }
        }
    }
}
