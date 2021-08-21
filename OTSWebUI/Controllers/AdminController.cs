using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using OTSWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OTSWebUI.Controllers
{
    public class AdminController : Controller
    {
        private ICustomerService _customerService;
        private IRentService _rentService;
        private ITransactionLogService _transactionLogService;
        private ILoginLogService _loginLogService;
        private IGenderService _genderService;
        private IRentalSituationService _rentalSituationService;
        private ISecurityQuestionService _securityQuestionService;
        private ITransactionTypeService _transactionTypeService;
        private IVehicleTypeService _vehicleTypeService;
        private IVehicleBrandService _vehicleBrandService;
        private IVehicleLocationService _vehicleLocationService;
        private IAdminService _adminService;
        private IErrorLogService _errorLogService;
        private IDeletedCustomerService _deletedCustomerService;
        private IDeletedReservationService _deletedReservationService;
        public AdminController(ICustomerService customerService, IRentService rentService, ITransactionLogService transactionLogService, ILoginLogService loginLogService,
            IGenderService genderService, IRentalSituationService rentalSituationService, ISecurityQuestionService securityQuestionService, ITransactionTypeService transactionTypeService,
            IVehicleTypeService vehicleTypeService, IVehicleBrandService vehicleBrandService, IVehicleLocationService vehicleLocationService, IAdminService adminService, 
            IErrorLogService errorLogService, IDeletedCustomerService deletedCustomerService, IDeletedReservationService deletedReservationService)
        {
            _customerService = customerService;
            _rentService = rentService;
            _transactionLogService = transactionLogService;
            _loginLogService = loginLogService;
            _genderService = genderService;
            _rentalSituationService = rentalSituationService;
            _securityQuestionService = securityQuestionService;
            _transactionTypeService = transactionTypeService;
            _vehicleTypeService = vehicleTypeService;
            _vehicleBrandService = vehicleBrandService;
            _vehicleLocationService = vehicleLocationService;
            _adminService = adminService;
            _errorLogService = errorLogService;
            _deletedCustomerService = deletedCustomerService;
            _deletedReservationService = deletedReservationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Admin admin)
        {
            var adminVerify = _adminService.GetAll().Data.SingleOrDefault(a => a.UserName == admin.UserName && a.Password == admin.Password);

            if (adminVerify != null)
            {
                FormsAuthentication.SetAuthCookie(adminVerify.Id.ToString(), false);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.LoginFailed = "Kullanıcı adı veya parola hatalı tekrar deneyin";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CustomerCount = _customerService.GetAll().Data.Count;
            ViewBag.ReservationCount = _rentService.GetAll().Data.Count;
            ViewBag.LogsCount = (_loginLogService.GetAll().Data.Count) + (_transactionLogService.GetAll().Data.Count) + (_errorLogService.GetAll().Data.Count);
            return View();
        }

        [HttpGet]
        public ActionResult Customers()
        {
            var customers = _customerService.GetCustomerDetails().Data;
            return View(customers);
        }

        public ActionResult DeleteCustomer(int id)
        {
            //Önce ilişkiler siliniyor
            DeleteReservationsOfCustomer(id);
            DeleteTransactionLogsOfCustomer(id);
            DeleteLoginLogsOfCustomer(id);

            //Sonra müşteri siliniyor
            _customerService.Delete(_customerService.GetById(id).Data);
            TempData["CustomerDeleteSuccess"] = "Kullanıcı başarılı bir şekilde silindi";
            return RedirectToAction("Customers", "Admin");
        }

        [HttpGet]
        public ActionResult Reservations()
        {
            var reservations = _rentService.GetRentDetails().Data.ToList();
            return View(reservations);
        }

        public ActionResult DeleteReservation(int id)
        {
            _rentService.Delete(_rentService.GetById(id).Data);
            TempData["ReservationDeleteSuccess"] = "Rezervasyon silme işlemi başarılı";
            return RedirectToAction("Reservations", "Admin");
        }

        public ActionResult LogIndex()
        {
            ViewBag.LoginLogsCount = _loginLogService.GetAll().Data.Count;
            ViewBag.TransactionLogsCount = _transactionLogService.GetAll().Data.Count;
            ViewBag.ErrorLogsCount = _errorLogService.GetAll().Data.Count;
            return View();
        }

        [HttpGet]
        public ActionResult LoginLogs()
        {
            var loginLogs = _loginLogService.GetLoginLogDetails().Data.ToList();
            return View(loginLogs);
        }

        [HttpGet]
        public ActionResult TransactionLogs()
        {
            var transactionLogs = _transactionLogService.GetTransactionLogDetails().Data.ToList();
            return View(transactionLogs);
        }

        [HttpGet]
        public ActionResult ErrorLogs()
        {
            var errorLogs = _errorLogService.GetAll().Data.OrderByDescending(e => e.TimeUtc).ToList();
            return View(errorLogs);
        }

        [HttpGet]
        public ActionResult ErrorLogDetails(System.Guid id)
        {
            var error = _errorLogService.GetAll().Data.Where(e => e.ErrorId == id).ToList();
            return View(error);
        }

        [HttpGet]
        public ActionResult Genders()
        {
            var genders = _genderService.GetAll().Data.ToList();
            return View(genders);
        }

        public ActionResult GenderUpdate(int id)
        {
            var gender = _genderService.GetById(id).Data;
            return View("GenderUpdate", gender);
        }

        [HttpPost]
        public ActionResult GenderUpdate(Gender gender)
        {
            _genderService.Update(gender);
            TempData["GenderUpdateSuccess"] = "Cinsiyet güncelleme işlemi başarılı";
            return RedirectToAction("Genders", "Admin");
        }

        private void DeleteReservationsOfCustomer(int customerId)
        {
            var reservations = _rentService.GetAll().Data.Where(r => r.CustomerId == customerId);
            foreach (var reservation in reservations)
            {
                _rentService.Delete(reservation);
            }
        }

        [HttpGet]
        public ActionResult VehicleStatus()
        {
            var vehicleStatus = _rentalSituationService.GetAll().Data.ToList();
            return View(vehicleStatus);
        }

        [HttpGet]
        public ActionResult VehicleStateAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VehicleStateAdd(RentalSituation rentalSituation)
        {
            _rentalSituationService.Add(rentalSituation);
            TempData["VehicleStateAddSuccess"] = "Araç durumu başarılı bir şekilde eklendi";
            return RedirectToAction("VehicleStatus", "Admin");
        }
        public ActionResult VehicleStatusUpdate(int id)
        {
            var gender = _rentalSituationService.GetById(id).Data;
            return View("VehicleStatusUpdate", gender);
        }

        [HttpPost]
        public ActionResult VehicleStatusUpdate(RentalSituation rentalSituation)
        {
            _rentalSituationService.Update(rentalSituation);
            TempData["VehicleStateUpdateSuccess"] = "Araç durumu güncelleme işlemi başarılı";
            return RedirectToAction("VehicleStatus", "Admin");
        }

        public ActionResult VehicleStateDelete(int id)
        {
            _rentalSituationService.Delete(_rentalSituationService.GetById(id).Data);
            TempData["VehicleStateDeleteSuccess"] = "Araç durumu başarılı bir şekilde silindi";
            return RedirectToAction("VehicleStatus", "Admin");
        }

        [HttpGet]
        public ActionResult SecurityQuestions()
        {
            var securityQuestions = _securityQuestionService.GetAll().Data.ToList();
            return View(securityQuestions);
        }

        [HttpGet]
        public ActionResult SecurityQuestionAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SecurityQuestionAdd(SecurityQuestion securityQuestion)
        {
            _securityQuestionService.Add(securityQuestion);
            TempData["SecurityQuestionAddSuccess"] = "Güvenlik sorusu başarılı bir şekilde eklendi";
            return RedirectToAction("SecurityQuestions", "Admin");
        }

        public ActionResult SecurityQuestionUpdate(int id)
        {
            var securityQuestion = _securityQuestionService.GetById(id).Data;
            return View("SecurityQuestionUpdate", securityQuestion);
        }

        [HttpPost]
        public ActionResult SecurityQuestionUpdate(SecurityQuestion securityQuestion)
        {
            _securityQuestionService.Update(securityQuestion);
            TempData["SecurityQuestionUpdateSuccess"] = "Güvenlik sorusu başarılı bir şekilde güncellendi";
            return RedirectToAction("SecurityQuestions", "Admin");
        }

        public ActionResult SecurityQuestionDelete(int id)
        {
            _securityQuestionService.Delete(_securityQuestionService.GetById(id).Data);
            TempData["SecurityQuestionDeleteSuccess"] = "Güvenlik sorusu başarılı bir şekilde silindi";
            return RedirectToAction("SecurityQuestions", "Admin");
        }

        [HttpGet]
        public ActionResult TransactionTypes()
        {
            var transactionTypes = _transactionTypeService.GetAll().Data;
            return View(transactionTypes);
        }

        [HttpGet]
        public ActionResult TransactionTypeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransactionTypeAdd(TransactionType transactionType)
        {
            _transactionTypeService.Add(transactionType);
            TempData["TransactionLogTypeAddSuccess"] = "İşlem log tipi başarılı bir şekilde eklendi";
            return RedirectToAction("TransactionTypes", "Admin");
        }

        public ActionResult TransactionTypeUpdate(int id)
        {
            var transactionType = _transactionTypeService.GetById(id).Data;
            return View("TransactionTypeUpdate", transactionType);
        }

        [HttpPost]
        public ActionResult TransactionTypeUpdate(TransactionType transactionType)
        {
            _transactionTypeService.Update(transactionType);
            TempData["TransactionLogTypeUpdateSuccess"] = "İşlem log tipi başarılı bir şekilde güncellendi";
            return RedirectToAction("TransactionTypes", "Admin");
        }

        public ActionResult TransactionTypeDelete(int id)
        {
            _transactionTypeService.Delete(_transactionTypeService.GetById(id).Data);
            TempData["TransactionLogTypeDeleteSuccess"] = "İşlem log tipi başarılı bir şekilde silindi";
            return RedirectToAction("TransactionTypes", "Admin");
        }

        [HttpGet]
        public ActionResult VehicleTypes()
        {
            var vehicleTypes = _vehicleTypeService.GetAll().Data.ToList();
            return View(vehicleTypes);
        }

        [HttpGet]
        public ActionResult VehicleTypeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VehicleTypeAdd(VehicleType vehicleType)
        {
            _vehicleTypeService.Add(vehicleType);
            TempData["VehicleTypeAddSuccess"] = "Araç tipi başarılı bir şekilde eklendi";
            return RedirectToAction("VehicleTypes", "Admin");
        }

        public ActionResult VehicleTypeUpdate(int id)
        {
            var vehicleType = _vehicleTypeService.GetById(id).Data;
            return View("VehicleTypeUpdate", vehicleType);
        }

        [HttpPost]
        public ActionResult VehicleTypeUpdate(VehicleType vehicleType)
        {
            _vehicleTypeService.Update(vehicleType);
            TempData["VehicleTypeUpdateSuccess"] = "Araç tipi başarılı bir şekilde güncellendi";
            return RedirectToAction("VehicleTypes", "Admin");
        }

        public ActionResult VehicleTypeDelete(int id)
        {
            _vehicleTypeService.Delete(_vehicleTypeService.GetById(id).Data);
            TempData["VehicleTypeDeleteSuccess"] = "Araç tipi başarılı bir şekilde silindi";
            return RedirectToAction("VehicleTypes", "Admin");
        }

        [HttpGet]
        public ActionResult VehicleBrands()
        {
            var vehicleBrands = _vehicleBrandService.GetVehicleBrandDetails().Data.ToList();
            return View(vehicleBrands);
        }

        [HttpGet]
        public ActionResult VehicleBrandAdd()
        {
            List<VehicleType> vehicleTypes = _vehicleTypeService.GetAll().Data.ToList();
            ViewBag.VehicleTypes = new SelectList(vehicleTypes, "Id", "AracTuru");
            return View();
        }

        [HttpPost]
        public ActionResult VehicleBrandAdd(VehicleBrand vehicleBrand)
        {
            _vehicleBrandService.Add(vehicleBrand);
            TempData["VehicleBrandAddSuccess"] = "Araç markası başarılı bir şekilde eklendi";
            return RedirectToAction("VehicleBrands", "Admin");
        }

        public ActionResult VehicleBrandUpdate(int id)
        {
            List<VehicleType> vehicleTypes = _vehicleTypeService.GetAll().Data.ToList();
            ViewBag.VehicleTypes = new SelectList(vehicleTypes, "Id", "AracTuru");

            var vehicleBrand = _vehicleBrandService.GetById(id).Data;
            return View("VehicleBrandUpdate", vehicleBrand);
        }

        [HttpPost]
        public ActionResult VehicleBrandUpdate(VehicleBrand vehicleBrand)
        {
            _vehicleBrandService.Update(vehicleBrand);
            TempData["VehicleBrandUpdateSuccess"] = "Araç markası başarılı bir şekilde güncellendi";
            return RedirectToAction("VehicleBrands", "Admin");
        }
        public ActionResult VehicleBrandDelete(int id)
        {
            _vehicleBrandService.Delete(_vehicleBrandService.GetById(id).Data);
            TempData["VehicleBrandDeleteSuccess"] = "Araç markası başarılı bir şekilde silindi";
            return RedirectToAction("VehicleBrands", "Admin");
        }

        [HttpGet]
        public ActionResult VehicleLocations()
        {
            var vehicleLocations = _vehicleLocationService.GetAll().Data.ToList();
            return View(vehicleLocations);
        }

        [HttpGet]
        public ActionResult VehicleLocationAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VehicleLocationAdd(VehicleLocation vehicleLocation)
        {
            _vehicleLocationService.Add(vehicleLocation);
            TempData["VehicleLocationAddSuccess"] = "Konum başarılı bir şekilde eklendi";
            return RedirectToAction("VehicleLocations", "Admin");
        }
        public ActionResult VehicleLocationUpdate(int id)
        {
            var vehicleLocation = _vehicleLocationService.GetById(id).Data;
            return View("VehicleLocationUpdate", vehicleLocation);
        }

        [HttpPost]
        public ActionResult VehicleLocationUpdate(VehicleLocation vehicleLocation)
        {
            _vehicleLocationService.Update(vehicleLocation);
            TempData["VehicleLocationUpdateSuccess"] = "Konum başarılı bir şekilde güncellendi";
            return RedirectToAction("VehicleLocations", "Admin");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult VehicleLocationDelete(int id)
        {
            _vehicleLocationService.Delete(_vehicleLocationService.GetById(id).Data);
            TempData["VehicleLocationDeleteSuccess"] = "Konum başarılı bir şekilde silindi";
            return RedirectToAction("VehicleLocations", "Admin");
        }

        public ActionResult Admins()
        {
            var admins = _adminService.GetAll().Data;
            return View(admins);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            admin.RoleId = 1;
            _adminService.Add(admin);
            TempData["AdminAddSuccess"] = "Admin başarılı bir şekilde eklendi";
            return RedirectToAction("Admins", "Admin");
        }

        public ActionResult AdminUpdate(int id)
        {
            var admin = _adminService.GetById(id).Data;
            return View("AdminUpdate", admin);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            var getAdmin = _adminService.GetById(admin.Id).Data;
            admin.Password = getAdmin.Password;
            admin.RoleId = getAdmin.RoleId;
            _adminService.Update(admin);
            TempData["AdminUpdateSuccess"] = "Admin başarılı bir şekilde güncellendi";
            return RedirectToAction("Admins", "Admin");
        }
        public ActionResult AdminDelete(int id)
        {
            _adminService.Delete(_adminService.GetById(id).Data);
            TempData["AdminDeleteSuccess"] = "Admin başarılı bir şekilde silindi";
            return RedirectToAction("Admins", "Admin");
        }

        [HttpGet]
        public ActionResult AdminProfile()
        {
            var admin = _adminService.GetById(Convert.ToInt32(HttpContext.User.Identity.Name)).Data;
            return View("AdminProfile", admin);
        }

        [HttpPost]
        public ActionResult AdminProfile(Admin admin)
        {
            var adminInformation = _adminService.GetById(Convert.ToInt32(HttpContext.User.Identity.Name)).Data;
            admin.Id = adminInformation.Id;
            admin.Password = adminInformation.Password;
            admin.RoleId = adminInformation.RoleId;
            _adminService.Update(admin);
            ViewBag.ProfileUpdateSuccess = "Profiliniz başarılı bir şekilde güncellenmiştir";
            return View();
        }


        [HttpGet]
        public ActionResult AdminPasswordUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminPasswordUpdate(PasswordUpdate passwordUpdate)
        {
            var admin = _adminService.GetById(Convert.ToInt32(HttpContext.User.Identity.Name));
            if (passwordUpdate.NewPassword != passwordUpdate.NewPasswordConfirm)
            {
                ViewBag.PasswordUpdateFailed = "Parolalar birbirleriyle uyuşmamaktadır.";
                return View();
            }
            else if (passwordUpdate.OldPassword != admin.Data.Password)
            {
                ViewBag.PasswordUpdateFailed = "Mevcut parola hatalı lütfen kontrol edin";
                return View();
            }
            else
            {
                Admin adminPasswordUpdate = admin.Data;
                adminPasswordUpdate.Password = passwordUpdate.NewPassword;

                _adminService.Update(adminPasswordUpdate);

                TempData["PasswordUpdateSuccess"] = "Parolanız başarılı bir şekilde güncellenmiştir";

                return RedirectToAction("AdminProfile", "Admin");
            }

        }

        public ActionResult StatisticsAndReports()
        {
            var reservations = _rentService.GetAll().Data;
            var vehicleLocations = _vehicleLocationService.GetAll().Data;
            var transastions = _transactionLogService.GetAll().Data;
            var logins = _loginLogService.GetAll().Data;
            var customers = _customerService.GetAll().Data;

            ViewBag.LastOneMonthTotalReservationCount = transastions.Where(t => t.TransactionNameId == 1 && (DateTime.Now - t.DateOfTransaction).TotalDays <= 30).Count();
            ViewBag.LastOneMonthTotalMoneyEarned = string.Format("{0:C}", reservations.Where(t => (DateTime.Now - t.RezervasyonAlmaTarihi).TotalDays <= 30).Sum(re => re.KiraUcreti));
            ViewBag.LastOneMonthNumberOfNewMembers = transastions.Where(t => t.TransactionNameId == 5 && (DateTime.Now - t.DateOfTransaction).TotalDays <= 30).Count();
            ViewBag.LastOneMonthVisitSystemUserNumber = logins.Where(t => (DateTime.Now - t.DateOfLogin).TotalDays <= 30).Count();

            ViewBag.TotalReservationCount = transastions.Count();
            ViewBag.TotalMoneyEarned = string.Format("{0:C}", reservations.Sum(r => r.KiraUcreti));
            ViewBag.CarParkOccupancyRate = Math.Round((100 * Convert.ToDouble(reservations.Count)) / (vehicleLocations.Count), 2);
            ViewBag.VisitSystemUserNumber = logins.Where(t => (DateTime.Now - t.DateOfLogin).TotalDays <= 30).Count();
            ViewBag.ManUserRate = Math.Round((100 * Convert.ToDouble(customers.Where(c => c.Cinsiyet == 1).Count())) / (Convert.ToDouble(customers.Count())), 2);
            ViewBag.WomanUserRate = Math.Round((100 * Convert.ToDouble(customers.Where(c => c.Cinsiyet == 2).Count())) / (Convert.ToDouble(customers.Count())), 2);
            Months mostBookedMonthName = (Months)Convert.ToInt32(_rentService.GetMostBookedMonth().Data.OrderByDescending(r => r.MonthCount).FirstOrDefault().MonthId) - 1;
            Months leastBookedMonthName = (Months)Convert.ToInt32(_rentService.GetMostBookedMonth().Data.OrderBy(r => r.MonthCount).FirstOrDefault().MonthId) - 1;
            ViewBag.MostBookedMonth = mostBookedMonthName.ToString();
            ViewBag.LeastBookedMonth = leastBookedMonthName.ToString();
            ViewBag.MostBookedVehicleType = _rentService.GetMostBookedVehicleType().Data.OrderByDescending(r => r.VehicleTypeCount).FirstOrDefault().VehicleType.ToString();
            return View();
        }
        enum Months
        {
            Ocak,
            Şubat,
            Mart,
            Nisan,
            Mayıs,
            Haziran,
            Temmuz,
            Ağustos,
            Eylül,
            Ekim,
            Kasım,
            Aralık
        }

        public ActionResult ArchiveDeletedCustomers()
        {
            var deletedCustomers = _deletedCustomerService.GetDeletedCustomers().Data.ToList();
            return View(deletedCustomers);
        }
        public ActionResult ArchiveDeletedReservations()
        {
            var deletedReserations = _deletedReservationService.GetDeletedReservations().Data.ToList();
            return View(deletedReserations);
        }
        private void DeleteTransactionLogsOfCustomer(int customerId)
        {
            var transactionLogs = _transactionLogService.GetAll().Data.Where(r => r.CustomerId == customerId);
            foreach (var transactionLog in transactionLogs)
            {
                _transactionLogService.Delete(transactionLog);
            }
        }
        private void DeleteLoginLogsOfCustomer(int customerId)
        {
            var loginLogs = _loginLogService.GetAll().Data.Where(r => r.CustomerId == customerId);
            foreach (var loginLog in loginLogs)
            {
                _loginLogService.Delete(loginLog);
            }
        }
    }
}