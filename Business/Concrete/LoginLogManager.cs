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
    public class LoginLogManager : ILoginLogService
    {
        ILoginLogDal _loginLogDal;
        public LoginLogManager(ILoginLogDal loginLogDal)
        {
            _loginLogDal = loginLogDal;
        }

        public IResult Add(LoginLog loginLog)
        {
            _loginLogDal.Add(loginLog);
            return new SuccessResult();
        }

        public IResult Delete(LoginLog loginLog)
        {
            _loginLogDal.Delete(loginLog);
            return new SuccessResult();
        }

        public IDataResult<List<LoginLog>> GetAll()
        {
            return new SuccessDataResult<List<LoginLog>>(_loginLogDal.GetAll());
        }

        public IDataResult<LoginLog> GetById(int loginLogId)
        {
            return new SuccessDataResult<LoginLog>(_loginLogDal.Get(l => l.Id == loginLogId));
        }

        public IDataResult<List<LoginLogDetailsDto>> GetLoginLogDetails()
        {
            return new SuccessDataResult<List<LoginLogDetailsDto>>(_loginLogDal.GetLoginLogDetails());
        }

        public IResult Update(LoginLog loginLog)
        {
            _loginLogDal.Update(loginLog);
            return new SuccessResult();
        }
    }
}
