using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleLocationService
    {
        IDataResult<List<VehicleLocation>> GetAll();
        IDataResult<VehicleLocation> GetById(int vehicleLocationId);
        IResult Add(VehicleLocation vehicleLocation);
        IResult Delete(VehicleLocation vehicleLocation);
        IResult Update(VehicleLocation vehicleLocation);
    }
}
