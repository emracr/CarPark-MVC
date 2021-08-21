using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class VehicleLocation : IEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Floor { get; set; }
    }
}
