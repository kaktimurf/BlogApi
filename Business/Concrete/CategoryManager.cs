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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            try
            {

                _categoryDal.Add(category);
                return new SuccessResult(Messages.SuccessAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorAdded);
            }
                    
        }

        public IResult Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.SuccessDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorDeleted);
            }
        }

        public IDataResult<List<Category>> GetAll()
        {
            try
            {
                
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList(),Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Category>>(Messages.ErrorGetList);
            }
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            try
            {

                return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Id==categoryId), Messages.SuccessGetById);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Category>(Messages.ErrorGetById);
            }
        }

        public IResult Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return new SuccessResult(Messages.SuccessUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorUpdated);
            }
        }
    }
}
