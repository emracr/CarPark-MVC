using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleBrandService
    {
        IDataResult<List<VehicleBrand>> GetAll();
        IDataResult<List<VehicleBrandDetailsDto>> GetVehicleBrandDetails();
        IDataResult<VehicleBrand> GetById(int vehicleBrandId);
        IResult Add(VehicleBrand vehicleBrand);
        IResult Delete(VehicleBrand vehicleBrand);
        IResult Update(VehicleBrand vehicleBrand);
    }
}
