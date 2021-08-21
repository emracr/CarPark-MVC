using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class LoginLogDetailsDto : IDto
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfLogin { get; set; }
        public DateTime DateOfLogout { get; set; }
    }
}
