using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalSituationService
    {
        IDataResult<List<RentalSituation>> GetAll();
        IDataResult<RentalSituation> GetById(int rentalSituationId);
        IResult Add(RentalSituation rentalSituation);
        IResult Delete(RentalSituation rentalSituation);
        IResult Update(RentalSituation rentalSituation);
    }
}
