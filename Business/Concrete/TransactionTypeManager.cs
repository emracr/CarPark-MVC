using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransactionTypeManager : ITransactionTypeService
    {
        private ITransactionTypeDal _transactionTypeDal;
        public TransactionTypeManager(ITransactionTypeDal transactionTypeDal)
        {
            _transactionTypeDal = transactionTypeDal;
        }

        public IResult Add(TransactionType transactionType)
        {
            _transactionTypeDal.Add(transactionType);
            return new SuccessResult();
        }

        public IResult Delete(TransactionType transactionType)
        {
            _transactionTypeDal.Delete(transactionType);
            return new SuccessResult();
        }

        public IDataResult<List<TransactionType>> GetAll()
        {
            return new SuccessDataResult<List<TransactionType>>(_transactionTypeDal.GetAll());
        }

        public IDataResult<TransactionType> GetById(int transactionTypeId)
        {
            return new SuccessDataResult<TransactionType>(_transactionTypeDal.Get(t => t.Id == transactionTypeId));
        }

        public IResult Update(TransactionType transactionType)
        {
            _transactionTypeDal.Update(transactionType);
            return new SuccessResult();
        }
    }
}
