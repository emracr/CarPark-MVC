using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class VehicleBrand : IEntity
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public int AracTuru { get; set; }
    }
}
