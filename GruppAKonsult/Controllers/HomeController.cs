using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Vilka är vi?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Här hittar du våra kontaktuppgifter";

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Logga in";

            return View();
        }
    }
}