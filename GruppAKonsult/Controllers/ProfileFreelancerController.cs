using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models;
using GruppAKonsult.ViewModels;

namespace GruppAKonsult.Controllers
{
    public class ProfileFreelancerController : Controller
    {
        private GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();

        //Ta bort denna kod, kompileringsfel
        //// GET: ProfileFreelancer
        //public ActionResult Index()
        //{
        //    return View();
        //}

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
            var model = new FreelancerCVViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult ProfileFreelancer(FreelancerCVViewModel model)
        {
            if (ModelState.IsValid)
            {
                var candidate = db.Freelancer.Add(model.Freelancer);

                db.SaveChanges();


                model.CV.Candidate_Id = candidate.Candidate_Id;


                //CV_ID får 0 värde och det är därför vi summerar 1 till vår query 
                model.CV.CV_Id = db.CV.Max(x => x.CV_Id) + 1;

                var cv = db.CV.Add(model.CV);

                db.SaveChanges();

                var languages = model.SelectedLanguage;

                if (languages != null)
                { 
                    var l = new Language
                    {
                        CV_Id = cv.CV_Id,
                        Candidate_Id = candidate.Candidate_Id,
                        Swedish = languages.Contains("2") ? "True" : "False",
                        English = languages.Contains("3") ? "True" : "False",
                        French = languages.Contains("4") ? "True" : "False",
                        Spanish = languages.Contains("5") ? "True" : "False",
                        German = languages.Contains("6") ? "True" : "False",
                        Norwegian = languages.Contains("7") ? "True" : "False",
                        Danish = languages.Contains("8") ? "True" : "False",
                        Finnish = languages.Contains("9") ? "True" : "False",
                    };

                db.Language.Add(l);
                }

                var professions = model.SelectedProfessions;

                if (professions != null)
                {
                    var p = new Profession
                    {
                        CV_Id = cv.CV_Id,
                        Candidate_Id = candidate.Candidate_Id,

                        Webbdeveloper = professions.Contains("2") ? "True" : "False",
                        Systemdeveloper = professions.Contains("3") ? "True" : "False",
                        Programmer = professions.Contains("4") ? "True" : "False",
                        Softwareengineer = professions.Contains("5") ? "True" : "False",
                        Frontenddeveloper = professions.Contains("6") ? "True" : "False",
                        Backenddeveloper = professions.Contains("7") ? "True" : "False",
                        Javadeveloper = professions.Contains("8") ? "True" : "False",
                        Scrummaster = professions.Contains("9") ? "True" : "False",
                    };

                    db.Profession.Add(p);
                }

                var skills = model.SelectedSkills;
                if (skills != null)
                {
                    var s = new Skills
                    {
                        CV_Id = cv.CV_Id,
                        Candidate_Id = candidate.Candidate_Id,
                        C_ = skills.Contains("1") ? "True" : "False",
                        JavaScript = skills.Contains("2") ? "True" : "False",
                        Java = skills.Contains("3") ? "True" : "False",
                        C__ = skills.Contains("4") ? "True" : "False",
                        JQuery = skills.Contains("5") ? "True" : "False",
                        HTML = skills.Contains("6") ? "True" : "False",
                        CSS = skills.Contains("7") ? "True" : "False",
                        SQL = skills.Contains("7") ? "True" : "False"

                    };

                    db.Skills.Add(s);
                }


                db.SaveChanges();

                //return RedirectToAction("Index");
            }

            return View();
        }
    }
}