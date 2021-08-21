using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTSWebUI.Controllers
{
    public class HomeController : Controller
    {
        IRentService _retnService;
        public HomeController(IRentService retnService)
        {
            _retnService = retnService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}