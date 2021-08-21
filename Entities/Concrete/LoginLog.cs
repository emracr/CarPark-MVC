using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LoginLog : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfLogin { get; set; }
        public DateTime DateOfLogout { get; set; }
    }
}
