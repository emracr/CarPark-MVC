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
    public interface ILoginLogService
    {
        IDataResult<List<LoginLog>> GetAll();
        IDataResult<List<LoginLogDetailsDto>> GetLoginLogDetails();
        IDataResult<LoginLog> GetById(int loginLogId);
        IResult Add(LoginLog loginLog);
        IResult Delete(LoginLog loginLog);
        IResult Update(LoginLog loginLog);
    }
}
