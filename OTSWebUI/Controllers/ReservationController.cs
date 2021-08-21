using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using OTSWebUI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace OTSWebUI.Controllers
{
    public class ReservationController : Controller
    {
        IRentService _rentService;
        IVehicleBrandService _vehicleBrandService;
        IVehicleTypeService _vehicleTypeService;
        IVehicleLocationService _vehicleLocationService;
        ITransactionLogService _transactionLogService;
        public ReservationController(IRentService rentService, IVehicleBrandService vehicleBrandService, IVehicleTypeService vehicleTypeService, IVehicleLocationService vehicleLocationService, ITransactionLogService transactionLogService)
        {
            _rentService = rentService;
            _vehicleBrandService = vehicleBrandService;
            _vehicleTypeService = vehicleTypeService;
            _vehicleLocationService = vehicleLocationService;
            _transactionLogService = transactionLogService;
        }

        [HttpGet]
        public ActionResult MyReservation()
        {
            var reservations = _rentService.GetRentDetails().Data.Where(r => r.AracDurumuId == 1).ToList();
            List<RentDetailsDto> rents = reservations.Where(c => c.CustomerId == Convert.ToInt32(HttpContext.User.Identity.Name)).ToList();
            ViewBag.MyReservationCount = rents.Count;
            return View(rents);
        }
        [HttpGet]
        public ActionResult GetReservation()
        {

            List<VehicleType> types = _vehicleTypeService.GetAll().Data.ToList();
            ViewBag.VehicleTypes = new SelectList(types, "Id", "AracTuru");

            return View();
        }

        [HttpPost]
        public ActionResult GetReservation(Rent rent)
        {
            Rent reservevation = new Rent();
            reservevation.CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name);
            reservevation.AracMarkasi = rent.AracMarkasi;
            reservevation.AracKonumu = ReserveLocation();
            reservevation.PlakaNo = rent.PlakaNo;
            reservevation.KiraBaslangicTarihi = rent.KiraBaslangicTarihi;
            reservevation.KiraBitisTarihi = rent.KiraBitisTarihi;
            reservevation.AracDurumu = 1;
            reservevation.KiraUcreti = ((rent.KiraBitisTarihi - rent.KiraBaslangicTarihi).Days) * 10;
            reservevation.RezervasyonAlmaTarihi = DateTime.Now;

            _rentService.Add(reservevation);
            TransactionLog transactionLog = new TransactionLog() { CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name), TransactionNameId = 1, DateOfTransaction = DateTime.Now };
            _transactionLogService.Add(transactionLog);
            return (RedirectToAction("ReservationSummary", reservevation));
        }

        public ActionResult CompleteReservation(int id)
        {
            var reservation = _rentService.GetById(id).Data;
            reservation.AracDurumu = 2;
            _rentService.Update(reservation);
            TransactionLog transactionLog = new TransactionLog() { CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name), TransactionNameId = 9, DateOfTransaction = DateTime.Now };
            _transactionLogService.Add(transactionLog);
            TempData["ReservationCompleted"] = "Aracınız sistemsel olarak otoparktan alınmıştır. Lütfen en kısa sürede aracınız otoparktan alın";
            return RedirectToAction("MyReservation", "Reservation");
        }
        public ActionResult CancelMyReservation(int id)
        {
            _rentService.Delete(_rentService.GetById(id).Data);
            TransactionLog transactionLog = new TransactionLog() { CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name), TransactionNameId = 2, DateOfTransaction = DateTime.Now };
            _transactionLogService.Add(transactionLog);
            return RedirectToAction("MyReservation", "Reservation");
        }

        [HttpGet]
        public ActionResult ReservationSummary(Rent rent)
        {
            ViewBag.VehicleType = GetVehicleTypeByBrandId(rent.AracMarkasi);
            ViewBag.VehicleBrand = _vehicleBrandService.GetById(rent.AracMarkasi).Data.Marka;
            ViewBag.ReserveStartDate = rent.KiraBaslangicTarihi.ToShortDateString();
            ViewBag.ReserveEndDate = rent.KiraBitisTarihi.ToShortDateString();
            ViewBag.VehicleLocation = _vehicleLocationService.GetById(rent.AracKonumu).Data.Location;
            ViewBag.VehicleLocationFloor = _vehicleLocationService.GetById(rent.AracKonumu).Data.Floor;
            ViewBag.UserName = ClassGetUserName.getuserName;
            return View();
        }

        public JsonResult GetVehicleBrands(int vehicleType)
        {
            List<VehicleBrand> vehicleBrands = _vehicleBrandService.GetAll().Data.Where(m => m.AracTuru == vehicleType).ToList();
            return Json(vehicleBrands, JsonRequestBehavior.AllowGet);
        }

        public string GetVehicleTypeByBrandId(int vehicleId)
        {
            var vehicleBrand = _vehicleBrandService.GetById(vehicleId).Data;
            var vehicleType = _vehicleTypeService.GetById(vehicleBrand.AracTuru);
            return vehicleType.Data.AracTuru;
        }
        public int ReserveLocation()
        {
            int location = 0;
            bool locationFind = false;

            var vehicleLocations = _vehicleLocationService.GetAll().Data.ToList();
            var rents = _rentService.GetAll().Data.ToList();

            foreach (var vehicleLocation in vehicleLocations)
            {
                foreach (var rent in rents)
                {
                    if (vehicleLocation.Id == rent.AracKonumu && rent.AracDurumu == 1)
                    {
                        locationFind = false;
                        break;
                    }
                    else
                    {
                        location = vehicleLocation.Id;
                        locationFind = true;
                    }
                }
                if (locationFind)
                {
                    break;
                }
                else
                {
                    foreach (var vehicleLocation2 in vehicleLocations)
                    {
                        foreach (var rent in rents)
                        {
                            if (vehicleLocation2.Id == rent.AracKonumu)
                            {
                                locationFind = false;
                                break;
                            }
                            else
                            {
                                location = vehicleLocation2.Id;
                                locationFind = true;
                            }
                        }
                        if (locationFind)
                        {
                            break;
                        }
                    }
                }
            }
            return location;
        }
    }
}