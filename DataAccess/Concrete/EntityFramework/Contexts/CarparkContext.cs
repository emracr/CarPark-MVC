using Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class CarparkContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentalSituation> RentalSituations { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ErrorLog> ELMAH_Error { get; set; }
        public DbSet<DeletedCustomer> DeletedCustomers { get; set; }
        public DbSet<DeletedReservation> DeletedReservations { get; set; }
    }
}
