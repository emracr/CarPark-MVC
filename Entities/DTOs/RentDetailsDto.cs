using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentDetailsDto
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string AracKonumu { get; set; }
        public string AracMarkasi { get; set; }
        public string PlakaNo { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
        public string AracDurumu { get; set; }
        public int AracDurumuId { get; set; }
        public decimal KiraUcreti { get; set; }
        public string AracTuru { get; set; }
        public string BinaKatNo { get; set; }
        public int MonthId { get; set; }
        public int MonthCount { get; set; }
        public string VehicleType { get; set; }
        public int VehicleTypeCount { get; set; }
    }
}
