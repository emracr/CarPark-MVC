using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DeletedReservationManager : IDeletedReservationService
    {
        IDeletedReservationDal _deletedReservationDal;
        public DeletedReservationManager(IDeletedReservationDal deletedReservationDal)
        {
            _deletedReservationDal = deletedReservationDal;
        }

        public IDataResult<List<DeletedReservation>> GetAll()
        {
            return new SuccessDataResult<List<DeletedReservation>>(_deletedReservationDal.GetAll());
        }

        public IDataResult<List<DeletedReservationsDto>> GetDeletedReservations()
        {
            return new SuccessDataResult<List<DeletedReservationsDto>>(_deletedReservationDal.GetDeletedReservations());
        }
    }
}
