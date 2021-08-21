using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentDal : IEntityRepository<Rent>
    {
        List<RentDetailsDto> GetRentDetails();
        List<RentDetailsDto> GetMostBookedMonth();
        List<RentDetailsDto> GetMostBookedVehicleType();

    }
}
