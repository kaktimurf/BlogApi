using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;
        private IFileServices _fileService;
    
        public PostManager(IPostDal postDal, IFileServices fileService)
        {
            _postDal = postDal;
            _fileService = fileService;
            
        }

        public IResult Add(Post post)
        {

            
            using (FileStream readFile = new FileStream(Path.Combine(@"C:\Users\kakti\source\repos\Blog\BlogAPI\wwwroot\Files\Txt", "FileDirectory.txt"), FileMode.Open,FileAccess.Read))
            {
                
                StreamReader sr = new StreamReader(readFile);
                var ImgPath=sr.ReadLine();
                post.ImagePath = ImgPath;
            }

            try
            {
                
                 
                _postDal.Add(post);
                return new SuccessResult(Messages.SuccessAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorAdded);
            }
        }

        public IResult Delete(Post post)
        {


            post.ImagePath = "";
            try
            {
                _postDal.Delete(post);
                return new SuccessResult(Messages.SuccessDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorDeleted);
            }
        }

        public IDataResult<List<Post>> GetAll()
        {
            try
            {

                return new SuccessDataResult<List<Post>>(_postDal.GetList(), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Post>>(Messages.ErrorGetList);
            }
        }

        public IDataResult<Post> GetByCategryId(int categoryId)
        {
            try
            {

                return new SuccessDataResult<Post>(_postDal.Get(c=>c.CategoryId==categoryId), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Post>(Messages.ErrorGetList);
            }
        }

        public IDataResult<Post> GetById(int postId)
        {
            try
            {

                return new SuccessDataResult<Post>(_postDal.Get(c => c.Id == postId), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Post>(Messages.ErrorGetList);
            }
        }

        public IResult Update(Post post)
        {
            using (FileStream readFile = new FileStream(Path.Combine(@"C:\Users\kakti\source\repos\Blog\BlogAPI\wwwroot\Files\Txt", "FileDirectory.txt"), FileMode.Open, FileAccess.Read))
            {

                StreamReader sr = new StreamReader(readFile);
                var ImgPath = sr.ReadLine();
                post.ImagePath = ImgPath;
            }
            try
            {
                _postDal.Update(post);
                return new SuccessResult(Messages.SuccessUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorUpdated);
            }
        }
    }
}
