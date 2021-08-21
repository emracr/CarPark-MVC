using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalSituationManager : IRentalSituationService
    {
        IRentalSituationDal _rentalSituationDal;
        public RentalSituationManager(IRentalSituationDal rentalSituationDal)
        {
            _rentalSituationDal = rentalSituationDal;
        }

        public IResult Add(RentalSituation rentalSituation)
        {
            _rentalSituationDal.Add(rentalSituation);
            return new SuccessResult(Messages.RentalSituationAdded);
        }

        public IResult Delete(RentalSituation rentalSituation)
        {
            _rentalSituationDal.Delete(rentalSituation);
            return new SuccessResult(Messages.RentalSituationDeleted);
        }

        public IDataResult<List<RentalSituation>> GetAll()
        {
            return new SuccessDataResult<List<RentalSituation>>(_rentalSituationDal.GetAll(), Messages.RentalSituationsListed);
        }

        public IDataResult<RentalSituation> GetById(int rentalSituationId)
        {
            return new SuccessDataResult<RentalSituation>(_rentalSituationDal.Get(r => r.Id == rentalSituationId), Messages.RentalSituationListed);
        }

        public IResult Update(RentalSituation rentalSituation)
        {
            _rentalSituationDal.Update(rentalSituation);
            return new SuccessResult(Messages.RentalSituationUpdated);
        }
    }
}
