using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.Controllers
{
    public class EmployerController : Controller
    {

        GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();


        // GET: Employer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployerView()
        {
            return View();
        }

        public ActionResult EmployerFind()
        {

            
            return View(db.);
        }

    }
}