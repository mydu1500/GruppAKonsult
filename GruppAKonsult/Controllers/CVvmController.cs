using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models;
using GruppAKonsult.ViewModels;

namespace GruppAKonsult.Controllers
{
    public class CVvmController : Controller
    {
        // GET: CVvm
        public ActionResult Index()
        {
            return View();
        }
        //Skapa en lista med vymodellobjekt från våra viewmodel
        // Listan som innehåller en massa objekt 

        public List<CVViewModel> cvvmList()
        {
            GruppAKonsult_dbEntities2 vmdb = new GruppAKonsult_dbEntities2(); //db Context class
            List<CVViewModel> cvVMList = new List<CVViewModel>(); //lista med detaljer fårn både Student och Class modellerna
            var cvlist = (from cvitem in vmdb.CV
                          join freelanceritem in vmdb.Freelancer on cvitem.CV_Id equals
              freelanceritem.Candidate_Id
                          select new
                          {
                              cvitem.Drivinglicense,
                              cvitem.Education,
                              cvitem.Workexperience,
                              cvitem.Description,
                              freelanceritem.Firstname,
                              freelanceritem.Lastname,
                              freelanceritem.Nationality,
                              freelanceritem.Phonenumber,

                          }).ToList();
            ////Query för att hämta data från databasen genom att använda JOIN för att joina de två tabellerna och lagra data i studentlist
            //    foreach (var item in studentlist) //foreach loop för att fylla data från
            //    studentlist till List < StudentVM >
            {
            }
        }
    }
}