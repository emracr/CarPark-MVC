using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class VehicleLocationManager : IVehicleLocationService
    {
        IVehicleLocationDal _vehicleLocationDal;
        public VehicleLocationManager(IVehicleLocationDal vehicleLocationDal)
        {
            _vehicleLocationDal = vehicleLocationDal;
        }

        public IResult Add(VehicleLocation vehicleLocation)
        {
            _vehicleLocationDal.Add(vehicleLocation);
            return new SuccessResult();
        }

        public IResult Delete(VehicleLocation vehicleLocation)
        {
            _vehicleLocationDal.Delete(vehicleLocation);
            return new SuccessResult();
        }

        public IDataResult<List<VehicleLocation>> GetAll()
        {
            return new SuccessDataResult<List<VehicleLocation>>(_vehicleLocationDal.GetAll());
        }

        public IDataResult<VehicleLocation> GetById(int vehicleLocationId)
        {
            return new SuccessDataResult<VehicleLocation>(_vehicleLocationDal.Get(v => v.Id == vehicleLocationId));
        }

        public IResult Update(VehicleLocation vehicleLocation)
        {
            _vehicleLocationDal.Update(vehicleLocation);
            return new SuccessResult();
        }
    }
}
