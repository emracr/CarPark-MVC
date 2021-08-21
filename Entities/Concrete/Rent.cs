using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rent : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AracKonumu { get; set; }
        public int AracMarkasi { get; set; }
        public string PlakaNo { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
        public int AracDurumu { get; set; }
        public decimal KiraUcreti { get; set; }
        public DateTime RezervasyonAlmaTarihi { get; set; }
    }
}
