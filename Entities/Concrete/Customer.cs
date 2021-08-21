using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Cinsiyet { get; set; }
        public int GuvenlikSorusu { get; set; }
        public string GuvenlikCevabi { get; set; }
        public string Parola { get; set; }
    }
}
