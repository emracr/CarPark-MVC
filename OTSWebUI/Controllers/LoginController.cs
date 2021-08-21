using Business.Abstract;
using Entities.Concrete;
using OTSWebUI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OTSWebUI.Controllers
{
    public class LoginController : Controller
    {
        ICustomerService _customerService;
        ILoginLogService _loginLogService;
        ITransactionLogService _transactionLogService;
        ISecurityQuestionService _securityQuestionService;
        public LoginController(ICustomerService customerService, ILoginLogService loginLogService, ITransactionLogService transactionLogService, ISecurityQuestionService securityQuestionService)
        {
            _customerService = customerService;
            _loginLogService = loginLogService;
            _transactionLogService = transactionLogService;
            _securityQuestionService = securityQuestionService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccountLogin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AccountLogin(Customer customer)
        {
            var customerVerification = _customerService.GetAll().Data.SingleOrDefault(c => c.Email == customer.Email && c.Parola == customer.Parola);

            if (customerVerification != null)
            {
                FormsAuthentication.SetAuthCookie(customerVerification.Id.ToString(), false);
                GetCustomerName(customerVerification.Id);
                LoginLog loginLog = new LoginLog() { CustomerId = customerVerification.Id, DateOfLogin = DateTime.Now };
                _loginLogService.Add(loginLog);
                Session["LoginLogId"] = _loginLogService.GetById(loginLog.Id).Data.Id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFailed = "Email veya parola hatalı tekrar deneyin";
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var loginLog = _loginLogService.GetById(Convert.ToInt32(Session["LoginLogId"])).Data;
            loginLog.DateOfLogout = DateTime.Now;
            _loginLogService.Update(loginLog);
            return RedirectToAction("AccountLogin", "Login");
        }

        public void GetCustomerName(int customerId)
        {
            var customer = _customerService.GetAll().Data.SingleOrDefault(c => c.Id == customerId);
            ClassGetUserName.setUserName(customer.Ad.ToUpper() + " " + customer.Soyad.ToUpper());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            List<SecurityQuestion> securityQuestions = _securityQuestionService.GetAll().Data.ToList();
            ViewBag.SecurityQuestions = new SelectList(securityQuestions, "Id", "GuvenlikSorusu");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Customer customer)
        {
            List<SecurityQuestion> securityQuestions = _securityQuestionService.GetAll().Data.ToList();
            ViewBag.SecurityQuestions = new SelectList(securityQuestions, "Id", "GuvenlikSorusu");

            if (TCExists(customer.TC))
            {
                ViewBag.ResultMessage = "Girdiğiniz TC kimlik zaten kayıtlı";
                return View();
            }
            else if (EmailExists(customer.Email))
            {
                ViewBag.ResultMessage = "Girdiğiniz Email adresi zaten kayıtlı";
                return View();
            }
            else
            {
                customer.RoleId = 2;
                _customerService.Add(customer);
                TransactionLog transactionLog = new TransactionLog() { CustomerId = customer.Id, TransactionNameId = 5, DateOfTransaction = DateTime.Now };
                _transactionLogService.Add(transactionLog);
                return RedirectToAction("AccountLogin", "Login");
            }
        }

        public bool TCExists(string tc)
        {
            var customers = _customerService.GetAll().Data;
            foreach (var customer in customers)
            {
                if (customer.TC == tc)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EmailExists(string email)
        {
            var customers = _customerService.GetAll().Data;
            foreach (var customer in customers)
            {
                if (customer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}