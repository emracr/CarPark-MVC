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
    public class ErrorLogManager : IErrorLogService
    {
        IErrorLogDal _errorLogDal;
        public ErrorLogManager(IErrorLogDal errorLogDal)
        {
            _errorLogDal = errorLogDal;
        }

        public IDataResult<List<ErrorLog>> GetAll()
        {
            return new SuccessDataResult<List<ErrorLog>>(_errorLogDal.GetAll());
        }
    }
}
