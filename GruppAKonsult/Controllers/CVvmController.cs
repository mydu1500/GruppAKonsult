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

        public List<CVViewModel> CvVmList()
        {
            GruppAKonsult_dbEntities2 vmdb = new GruppAKonsult_dbEntities2(); //db Context class
            List<CVViewModel> cvVMList = new List<CVViewModel>(); //lista med detaljer från både CV och Freelancer modellerna
            var cvlist = (from cvitem in vmdb.CV
                          join freelanceritem in vmdb.Freelancer on cvitem.CV_Id equals
              freelanceritem.Candidate_Id
                          select new
                          {
                              cvitem.Drivinglicense,
                              cvitem.Education,         //Det som hör till CV-tabellen
                              cvitem.Workexperience,
                              cvitem.Description,

                              freelanceritem.Firstname,
                              freelanceritem.Lastname,
                              freelanceritem.Email,
                              freelanceritem.Phonenumber,     //Det som hör till Freelancer-tabellen
                              freelanceritem.Nationality,
                              freelanceritem.Birthdate,
                              freelanceritem.Cityofbirth,
                              freelanceritem.Address,
                              freelanceritem.Postalnumber,
                              freelanceritem.City,

                              //Här får vi lägga till language, skills, profession 
                          }).ToList();
            ////Query för att hämta data från databasen genom att använda JOIN för att joina de två tabellerna och lagra data i studentlist
            foreach (var item in cvlist)       //foreach loop för att fylla data från
                                                    //studentlist till List < CVViewModel >
            {
                CVViewModel objcvvm = new CVViewModel(); //ViewModel
                objcvvm.Drivinglicense = item.Drivinglicense;
                objcvvm.Education = item.Education;
                objcvvm.Workexperience = item.Workexperience;
                objcvvm.Description = item.Description;

                objcvvm.Firstname = item.Firstname;
                objcvvm.Lastname = item.Lastname;
                objcvvm.Phonenumber = item.Phonenumber;
                objcvvm.Nationality = item.Nationality;
                cvVMList.Add(objcvvm); //en lista av cvVmList objekt (ViewModel)
            }
            return cvVMList;
        }
    }
}
    
