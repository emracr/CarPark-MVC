using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class VehicleBrandDetailsDto : IDto
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string BrandName { get; set; }
        public string VehicleTypeName { get; set; }

    }
}
