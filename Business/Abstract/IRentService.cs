using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAll();
        IDataResult<List<RentDetailsDto>> GetRentDetails();
        IDataResult<List<RentDetailsDto>> GetMostBookedMonth();
        IDataResult<List<RentDetailsDto>> GetMostBookedVehicleType();
        IDataResult<Rent> GetById(int rentId);
        IResult Add(Rent rent);
        IResult Delete(Rent rent);
        IResult Update(Rent rent);
    }
}
