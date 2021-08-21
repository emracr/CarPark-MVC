using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TransactionLog : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TransactionNameId { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
