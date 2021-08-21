using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DeletedReservation : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleBrand { get; set; }
        public int VehicleLocation { get; set; }
        public int VehicleStatus { get; set; }
        public string PlateNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ReservationPrice { get; set; }
    }
}
