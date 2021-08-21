using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string Cinsiyet { get; set; }
    }
}
