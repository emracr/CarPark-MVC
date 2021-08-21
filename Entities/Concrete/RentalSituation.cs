using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RentalSituation : IEntity
    {
        public int Id { get; set; }
        public string KiraDurumu { get; set; }
    }
}
