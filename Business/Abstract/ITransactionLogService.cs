using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransactionLogService
    {
        IDataResult<List<TransactionLog>> GetAll();
        IDataResult<List<TransactionLogDetailsDto>> GetTransactionLogDetails();
        IDataResult<TransactionLog> GetById(int transactionLogId);
        IResult Add(TransactionLog transactionLog);
        IResult Delete(TransactionLog transactionLog);
    }
}
