using GruppAKonsult.Models;
using GruppAKonsult.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.Controllers
{
    public class ProfileFreelancerController : Controller
    {

        private GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();
        // GET: ProfileFreelancer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfileFreelancer()
        {
            return View();
        }

        public ActionResult EmptyNewProfile()
        {
            return View();
        }

        public ActionResult FreelancerCV()
        {
            var model = new FreeLancerCVViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProfileFreelancer(FreeLancerCVViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Freelancer.Add(model.Freelancer);
                db.SaveChanges();

                //return RedirectToAction("Index");
            }
            return View();
        }
    }
}