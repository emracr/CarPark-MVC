using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGenderService
    {
        IDataResult<List<Gender>> GetAll();
        IDataResult<Gender> GetById(int genderId);
        IResult Add(Gender gender);
        IResult Delete(Gender gender);
        IResult Update(Gender gender);
    }
}
