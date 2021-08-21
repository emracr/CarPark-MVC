using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISecurityQuestionService
    {
        IDataResult<List<SecurityQuestion>> GetAll();
        IDataResult<SecurityQuestion> GetById(int securityQuestionId);
        IResult Add(SecurityQuestion securityQuestion);
        IResult Delete(SecurityQuestion securityQuestion);
        IResult Update(SecurityQuestion securityQuestion);
    }
}
