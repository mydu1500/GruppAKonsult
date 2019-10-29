using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.Controllers
{
    public class EmployerLogInController : Controller
    {
        // GET: EmployerLogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployerLogIn()
        {
            ViewBag.Message = "";
            return View();
        }
    }
}