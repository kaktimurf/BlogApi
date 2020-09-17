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
    public class ContactManager : IContactService
    {
        private IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public IResult Add(Contact contact)
        {
            try
            {
                _contactDal.Add(contact);
                return new SuccessResult(Messages.SuccessAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorAdded);
            }
        }

        public IResult Delete(Contact contact)
        {
            try
            {
                _contactDal.Delete(contact);
                return new SuccessResult(Messages.SuccessDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorDeleted);
            }
        }

        public IDataResult<List<Contact>> GetAll()
        {
            try
            {

                return new SuccessDataResult<List<Contact>>(_contactDal.GetList(), Messages.SuccessGetList);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Contact>>(Messages.ErrorGetList);
            }
        }

        public IDataResult<Contact> GetById(int contactId)
        {
            try
            {

                return new SuccessDataResult<Contact>(_contactDal.Get(c => c.Id == contactId), Messages.SuccessGetById);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Contact>(Messages.ErrorGetById);
            }
        }

        public IResult Update(Contact contact)
        {
            try
            {
                _contactDal.Update(contact);
                return new SuccessResult(Messages.SuccessUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorUpdated);
            }
        }
    }
}
