using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpPost]
        public ActionResult FreelancerCV( HttpPostedFileBase inputGroupFile02)
        {

            if(inputGroupFile02 != null && inputGroupFile02.ContentLength >0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(inputGroupFile02.FileName));
                    inputGroupFile02.SaveAs(path);
                    ViewBag.Message = "Filen är korrekt uppladdad";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error" + ex.Message.ToString();
                }
            else
            {

                ViewBag.Message = " Vänligen välj en fil";
            }

                    



            //if (fileBase == null)
            //{
            //    ModelState.AddModelError("Error", "Vänligen välj en bild ");
            //    return View();

            //}
            //if ((fileBase.ContentType == "image/x-png" || fileBase.ContentType =="image/jpeg" ))

            //{
            //    ModelState.AddModelError("Error", "Bara .png och .jpeg är tillåtet att ladda upp");
            //    return View();

            //}
                




            return View();
        }
    }
}