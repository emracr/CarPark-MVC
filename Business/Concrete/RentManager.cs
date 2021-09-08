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
        IVehicleLocationService _vehicleLocationService;
        public RentManager(IRentDal rentDal, IVehicleLocationService vehicleLocationService)
        {
            _rentDal = rentDal;
            _vehicleLocationService = vehicleLocationService;
        }

        public IResult Add(Rent rent)
        {
            rent.AracKonumu = ReserveLocation();
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

        private int ReserveLocation()
        {
            int location = 0;
            bool locationFind = false;

            var vehicleLocations = _vehicleLocationService.GetAll().Data;
            var rents = _rentDal.GetAll();

            foreach (var vehicleLocation in vehicleLocations)
            {
                foreach (var rent in rents)
                {
                    if (vehicleLocation.Id == rent.AracKonumu && rent.AracDurumu == 1)
                    {
                        locationFind = false;
                        break;
                    }
                    else
                    {
                        location = vehicleLocation.Id;
                        locationFind = true;
                    }
                }
                if (locationFind)
                {
                    break;
                }
                else
                {
                    foreach (var vehicleLocation2 in vehicleLocations)
                    {
                        foreach (var rent in rents)
                        {
                            if (vehicleLocation2.Id == rent.AracKonumu)
                            {
                                locationFind = false;
                                break;
                            }
                            else
                            {
                                location = vehicleLocation2.Id;
                                locationFind = true;
                            }
                        }
                        if (locationFind)
                        {
                            break;
                        }
                    }
                }
            }
            return location;
        }
    }
}
