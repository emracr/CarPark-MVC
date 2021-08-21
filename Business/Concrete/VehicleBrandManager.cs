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
    public class VehicleBrandManager : IVehicleBrandService
    {
        IVehicleBrandDal _vehicleBrandDal;
        public VehicleBrandManager(IVehicleBrandDal vehicleBrandDal)
        {
            _vehicleBrandDal = vehicleBrandDal;
        }

        public IResult Add(VehicleBrand vehicleBrand)
        {
            _vehicleBrandDal.Add(vehicleBrand);
            return new SuccessResult(Messages.VehicleBrandAdded);
        }

        public IResult Delete(VehicleBrand vehicleBrand)
        {
            _vehicleBrandDal.Delete(vehicleBrand);
            return new SuccessResult(Messages.VehicleBrandDeleted);
        }

        public IDataResult<List<VehicleBrand>> GetAll()
        {
            return new SuccessDataResult<List<VehicleBrand>>(_vehicleBrandDal.GetAll(), Messages.VehicleBrandsListed);
        }

        public IDataResult<VehicleBrand> GetById(int vehicleBrandId)
        {
            return new SuccessDataResult<VehicleBrand>(_vehicleBrandDal.Get(v => v.Id == vehicleBrandId), Messages.VehicleBrandListed);
        }

        public IDataResult<List<VehicleBrandDetailsDto>> GetVehicleBrandDetails()
        {
            return new SuccessDataResult<List<VehicleBrandDetailsDto>>(_vehicleBrandDal.GetVehicleBrandDetails());
        }

        public IResult Update(VehicleBrand vehicleBrand)
        {
            _vehicleBrandDal.Update(vehicleBrand);
            return new SuccessResult(Messages.VehicleBrandUpdated);
        }
    }
}
