using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransactionLogManager : ITransactionLogService
    {
        ITransactionLogDal _transactionLogDal;
        public TransactionLogManager(ITransactionLogDal transactionLogDal)
        {
            _transactionLogDal = transactionLogDal;
        }

        public IResult Add(TransactionLog transactionLog)
        {
            _transactionLogDal.Add(transactionLog);
            return new SuccessResult();
        }

        public IResult Delete(TransactionLog transactionLog)
        {
            _transactionLogDal.Delete(transactionLog);
            return new SuccessResult();
        }

        public IDataResult<List<TransactionLog>> GetAll()
        {
            return new SuccessDataResult<List<TransactionLog>>(_transactionLogDal.GetAll());
        }

        public IDataResult<TransactionLog> GetById(int transactionLogId)
        {
            return new SuccessDataResult<TransactionLog>(_transactionLogDal.Get(t => t.Id == transactionLogId));
        }

        public IDataResult<List<TransactionLogDetailsDto>> GetTransactionLogDetails()
        {
            return new SuccessDataResult<List<TransactionLogDetailsDto>>(_transactionLogDal.GetTransactionLogDetails());
        }
    }
}
