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
    public class EfVehicleBrandDal : EfEntityRepositoryBase<VehicleBrand, CarparkContext>, IVehicleBrandDal
    {
        public List<VehicleBrandDetailsDto> GetVehicleBrandDetails()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from b in context.VehicleBrands
                             join vt in context.VehicleTypes
                             on b.AracTuru equals vt.Id
                             select new VehicleBrandDetailsDto()
                             {
                                 Id = b.Id,
                                 BrandName = b.Marka,
                                 VehicleTypeName = vt.AracTuru,
                                 VehicleTypeId = vt.Id
                             };

                return result.ToList();
            }
        }
    }
}
