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
    public class VehicleTypeManager : IVehicleTypeService
    {
        IVehicleTypeDal _vehicleTypeDal;
        public VehicleTypeManager(IVehicleTypeDal vehicleTypeDal)
        {
            _vehicleTypeDal = vehicleTypeDal;
        }

        public IResult Add(VehicleType vehicleType)
        {
            _vehicleTypeDal.Add(vehicleType);
            return new SuccessResult(Messages.VehicleTypeAdded);
        }

        public IResult Delete(VehicleType vehicleType)
        {
            _vehicleTypeDal.Delete(vehicleType);
            return new SuccessResult(Messages.VehicleTypeDeleted);
        }

        public IDataResult<List<VehicleType>> GetAll()
        {
            return new SuccessDataResult<List<VehicleType>>(_vehicleTypeDal.GetAll(), Messages.VehicleTypesListed);
        }

        public IDataResult<VehicleType> GetById(int vehicleTypeId)
        {
            return new SuccessDataResult<VehicleType>(_vehicleTypeDal.Get(v => v.Id == vehicleTypeId), Messages.VehicleTypeListed);
        }

        public IResult Update(VehicleType vehicleType)
        {
            _vehicleTypeDal.Update(vehicleType);
            return new SuccessResult(Messages.VehicleTypeUpdated);
        }
    }
}
