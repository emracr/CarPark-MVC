using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleTypeService
    {
        IDataResult<List<VehicleType>> GetAll();
        IDataResult<VehicleType> GetById(int vehicleTypeId);
        IResult Add(VehicleType vehicleType);
        IResult Delete(VehicleType vehicleType);
        IResult Update(VehicleType vehicleType);
    }
}
