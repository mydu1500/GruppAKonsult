﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.Controllers
{
    public class ProfileFreelancerController : Controller
    {
        // GET: ProfileFreelancer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfileFreelancer()
        {
            return View();
        }

        //Lägg till redigeringsprofil för att ändra CV

        public ActionResult FreelancerCV()
        {
            return View();
        }
    }
}