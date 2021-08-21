using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DeletedCustomerManager : IDeletedCustomerService
    {
        IDeletedCustomerDal _deletedCustomerDal;
        public DeletedCustomerManager(IDeletedCustomerDal deletedCustomerDal)
        {
            _deletedCustomerDal = deletedCustomerDal;
        }

        public IDataResult<List<DeletedCustomer>> GetAll()
        {
            return new SuccessDataResult<List<DeletedCustomer>>(_deletedCustomerDal.GetAll());
        }

        public IDataResult<List<DeletedCustomersDto>> GetDeletedCustomers()
        {
            return new SuccessDataResult<List<DeletedCustomersDto>>(_deletedCustomerDal.GetDeletedCustomers());
        }
    }
}
