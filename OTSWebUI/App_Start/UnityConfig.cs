using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OTSWebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IRentService, RentManager>();
            container.RegisterType<IRentDal, EfRentalDal>();

            container.RegisterType<ICustomerService, CustomerManager>();
            container.RegisterType<ICustomerDal, EfCustomerDal>();

            container.RegisterType<IVehicleBrandService, VehicleBrandManager>();
            container.RegisterType<IVehicleBrandDal, EfVehicleBrandDal>();

            container.RegisterType<IVehicleTypeService, VehicleTypeManager>();
            container.RegisterType<IVehicleTypeDal, EfVehicleTypeDal>();

            container.RegisterType<IVehicleLocationService, VehicleLocationManager>();
            container.RegisterType<IVehicleLocationDal, EfVehicleLocationDal>();

            container.RegisterType<ILoginLogService, LoginLogManager>();
            container.RegisterType<ILoginLogDal, EfLoginLogDal>();

            container.RegisterType<ITransactionLogService, TransactionLogManager>();
            container.RegisterType<ITransactionLogDal, EfTransactionLogDal>();

            container.RegisterType<IGenderService, GenderManager>();
            container.RegisterType<IGenderDal, EfGenderDal>();

            container.RegisterType<IRentalSituationService, RentalSituationManager>();
            container.RegisterType<IRentalSituationDal, EfRentalSituationDal>();

            container.RegisterType<ISecurityQuestionService, SecurityQuestionManager>();
            container.RegisterType<ISecurityQuestionDal, EfSecurityQuestionDal>();

            container.RegisterType<ITransactionTypeService, TransactionTypeManager>();
            container.RegisterType<ITransactionTypeDal, EfTransactionTypeDal>();

            container.RegisterType<IAdminService, AdminManager>();
            container.RegisterType<IAdminDal, EfAdminDal>();

            container.RegisterType<IErrorLogService, ErrorLogManager>();
            container.RegisterType<IErrorLogDal, EfErrorLogDal>();

            container.RegisterType<IDeletedCustomerService, DeletedCustomerManager>();
            container.RegisterType<IDeletedCustomerDal, EfDeletedCustomerDal>();

            container.RegisterType<IDeletedReservationService, DeletedReservationManager>();
            container.RegisterType<IDeletedReservationDal, EfDeletedReservationDal>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}