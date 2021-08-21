using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DeletedReservationsDto : IEntity
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleLocation { get; set; }
        public string VehicleStatus { get; set; }
        public string PlateNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ReservationPrice { get; set; }
    }
}
