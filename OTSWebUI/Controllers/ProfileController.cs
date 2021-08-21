using Business.Abstract;
using Entities.Concrete;
using OTSWebUI.Classes;
using OTSWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTSWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private ICustomerService _customerService;
        private ITransactionLogService _transactionLogService;
        public ProfileController(ICustomerService customerService, ITransactionLogService transactionLogService)
        {
            _customerService = customerService;
            _transactionLogService = transactionLogService;
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            var customer = _customerService.GetAll().Data.SingleOrDefault(c => c.Id == Convert.ToInt32(HttpContext.User.Identity.Name));
            return View("MyProfile", customer);
        }

        [HttpPost]
        public ActionResult MyProfile(Customer customer)
        {
            var findCustomer = _customerService.GetById(Convert.ToInt32(HttpContext.User.Identity.Name)).Data;

            customer.Id = Convert.ToInt32(HttpContext.User.Identity.Name);
            customer.TC = findCustomer.TC;
            customer.GuvenlikSorusu = findCustomer.GuvenlikSorusu;
            customer.GuvenlikCevabi = findCustomer.GuvenlikCevabi;
            customer.Parola = findCustomer.Parola;
            customer.RoleId = findCustomer.RoleId;

            _customerService.Update(customer);
            TransactionLog transactionLog = new TransactionLog() { CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name), TransactionNameId = 3, DateOfTransaction = DateTime.Now };
            _transactionLogService.Add(transactionLog);

            ClassGetUserName.setUserName(customer.Ad.ToUpper() + " " + customer.Soyad.ToUpper());
            ViewBag.ProfileUpdateSuccess = "Profiliniz başarılı bir şekilde güncellenmiştir";
            return View();
        }

        [HttpGet]
        public ActionResult PasswordUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordUpdate(PasswordUpdate passwordUpdate)
        {
            var customer = _customerService.GetById(Convert.ToInt32(HttpContext.User.Identity.Name));
            if (passwordUpdate.NewPassword != passwordUpdate.NewPasswordConfirm)
            {
                ViewBag.PasswordUpdateFailed = "Parolalar birbirleriyle uyuşmamaktadır.";
            }
            else if (passwordUpdate.OldPassword != customer.Data.Parola)
            {
                ViewBag.PasswordUpdateFailed = "Mevcut parola hatalı lütfen kontrol edin";
            }
            else
            {
                Customer customerUpdatePassword = customer.Data;
                customerUpdatePassword.Parola = passwordUpdate.NewPassword;

                _customerService.Update(customerUpdatePassword);
                TransactionLog transactionLog = new TransactionLog() { CustomerId = Convert.ToInt32(HttpContext.User.Identity.Name), TransactionNameId = 4, DateOfTransaction = DateTime.Now };
                _transactionLogService.Add(transactionLog);

                ViewBag.PasswordUpdateSuccess = "Parolanız başarılı bir şekilde güncellenmiştir";
            }
            return View();
        }
    }
}