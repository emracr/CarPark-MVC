using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDeletedReservationDal : EfEntityRepositoryBase<DeletedReservation, CarparkContext>, IDeletedReservationDal
    {
        public List<DeletedReservationsDto> GetDeletedReservations()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var query = ((from dr in context.DeletedReservations
                               join c in context.Customers
                               on dr.CustomerId equals c.Id
                               join vb in context.VehicleBrands
                               on dr.VehicleBrand equals vb.Id
                               join vl in context.VehicleLocations
                               on dr.VehicleLocation equals vl.Id
                               join rs in context.RentalSituations
                               on dr.VehicleStatus equals rs.Id
                               select new DeletedReservationsDto()
                               {
                                   Id = dr.Id,
                                   FirstName = c.Ad,
                                   LastName = c.Soyad,
                                   TC = c.TC,
                                   VehicleBrand = vb.Marka,
                                   VehicleLocation = vl.Location,
                                   VehicleStatus = rs.KiraDurumu,
                                   StartDate = dr.StartDate,
                                   EndDate = dr.EndDate,
                                   PlateNumber = dr.PlateNumber,
                                   ReservationPrice = dr.ReservationPrice
                               })
                             .Union(
                    from dr in context.DeletedReservations
                    join c in context.DeletedCustomers
                    on dr.CustomerId equals c.Id
                    join vb in context.VehicleBrands
                    on dr.VehicleBrand equals vb.Id
                    join vl in context.VehicleLocations
                    on dr.VehicleLocation equals vl.Id
                    join rs in context.RentalSituations
                    on dr.VehicleStatus equals rs.Id
                    select new DeletedReservationsDto()
                    {
                        Id = dr.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        TC = c.TC,
                        VehicleBrand = vb.Marka,
                        VehicleLocation = vl.Location,
                        VehicleStatus = rs.KiraDurumu,
                        StartDate = dr.StartDate,
                        EndDate = dr.EndDate,
                        PlateNumber = dr.PlateNumber,
                        ReservationPrice = dr.ReservationPrice
                    }));

                return query.ToList();

            }
        }
    }
}
