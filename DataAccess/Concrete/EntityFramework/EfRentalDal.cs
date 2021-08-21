using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rent, CarparkContext>, IRentDal
    {
        public List<RentDetailsDto> GetRentDetails()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from r in context.Rents
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             join v in context.VehicleBrands
                             on r.AracMarkasi equals v.Id
                             join re in context.RentalSituations
                             on r.AracDurumu equals re.Id
                             join vl in context.VehicleLocations
                             on r.AracKonumu equals vl.Id
                             join vt in context.VehicleTypes
                             on v.AracTuru equals vt.Id
                             select new RentDetailsDto()
                             {
                                 Id = r.Id,
                                 TC = c.TC,
                                 CustomerId = r.CustomerId,
                                 CustomerFirstName = c.Ad,
                                 CustomerLastName = c.Soyad,
                                 AracMarkasi = v.Marka,
                                 PlakaNo = r.PlakaNo,
                                 KiraBaslangicTarihi = r.KiraBaslangicTarihi,
                                 KiraBitisTarihi = r.KiraBitisTarihi,
                                 AracDurumu = re.KiraDurumu,
                                 AracDurumuId = re.Id,
                                 KiraUcreti = r.KiraUcreti,
                                 AracKonumu = vl.Location,
                                 AracTuru = vt.AracTuru,
                                 BinaKatNo = vl.Floor
                             };

                return result.ToList();

            }

        }
        public List<RentDetailsDto> GetMostBookedMonth()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from r in context.Rents
                             group r by new
                             {
                                 v = (r.KiraBaslangicTarihi.Month + r.KiraBitisTarihi.Month) / 2
                             }
                             into gcs
                             select new RentDetailsDto()
                             {
                                 MonthId = gcs.Key.v,
                                 MonthCount = gcs.Count()
                             };

                return result.ToList();
            }
        }

        public List<RentDetailsDto> GetMostBookedVehicleType()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from r in context.Rents
                             join vb in context.VehicleBrands
                             on r.AracMarkasi equals vb.Id
                             join vt in context.VehicleTypes
                             on vb.AracTuru equals vt.Id
                             group vt by new
                             {
                                 vt.AracTuru
                             }
                             into gcs
                             select new RentDetailsDto()
                             {
                                 VehicleType = gcs.Key.AracTuru,
                                 VehicleTypeCount = gcs.Count()
                             };

                return result.ToList();
            }
        }

    }
}
