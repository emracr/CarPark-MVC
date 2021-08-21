using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTSWebUI.Controllers
{
    [HandleError]
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult PageNotFound()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult UnexpectedError()
        {
            return View();
        }
    }
}