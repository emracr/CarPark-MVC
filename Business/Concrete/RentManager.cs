using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;
        public RentManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }

        public IResult Add(Rent rent)
        {
            _rentDal.Add(rent);
            return new SuccessResult(Messages.RentAdded);
        }

        public IResult Delete(Rent rent)
        {
            _rentDal.Delete(rent);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll(), Messages.RentsListed);
        }

        public IDataResult<Rent> GetById(int rentId)
        {
            return new SuccessDataResult<Rent>(_rentDal.Get(r => r.Id == rentId), Messages.RentListed);
        }

        public IDataResult<List<RentDetailsDto>> GetMostBookedMonth()
        {
            return new SuccessDataResult<List<RentDetailsDto>>(_rentDal.GetMostBookedMonth());
        }

        public IDataResult<List<RentDetailsDto>> GetMostBookedVehicleType()
        {
            return new SuccessDataResult<List<RentDetailsDto>>(_rentDal.GetMostBookedVehicleType());
        }

        public IDataResult<List<RentDetailsDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentDetailsDto>>(_rentDal.GetRentDetails());
        }

        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}
