﻿using System;
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

        public ActionResult FreelancerCV( int? id)
        {
            var model = new FreelancerCVViewModel()
            {
                Freelancer = new Freelancer(),
                CV = new CV()
            };
            if (id.HasValue)
            {
                var candidateId = id.Value;

                var freelancer = db.Freelancer.FirstOrDefault(x => x.Candidate_Id == candidateId);

                model.Freelancer = freelancer;

                var cv = db.CV.FirstOrDefault(x => x.Candidate_Id == candidateId);

                var language = db.Language.FirstOrDefault(x => x.CV_Id == cv.CV_Id && x.Candidate_Id == candidateId);

                if (language != null)
                {
                    var selectedLanguage = "";

                    if (language.Swedish == "True")
                    {
                        selectedLanguage = "Svenska";
                    }

                    if (language.English == "True")
                    {
                        selectedLanguage = "Engelska";
                    }
                    if (language.French == "True")
                    {
                        selectedLanguage = "Franska";
                    }
                    if (language.Spanish == "True")
                    {
                        selectedLanguage = "Spanska";
                    }
                    if (language.German == "True")
                    {
                        selectedLanguage = "Tyska";
                    }
                    if (language.Norwegian == "True")
                    {
                        selectedLanguage = "Norska";
                    }
                    if (language.Danish == "True")
                    {
                        selectedLanguage = "Danska";
                    }
                    if (language.Finnish == "True")
                    {
                        selectedLanguage = "Finska";
                    }

                    model.SelectedLanguage = selectedLanguage;
                }


                model.CV = cv;
            }



            return View(model);
        }



        public ActionResult UpdatedCV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileFreelancer(FreelancerCVViewModel model)
        {
            //if (ModelState.IsValid)
            {
                var candidate = db.Freelancer.Add(model.Freelancer);

                db.SaveChanges();


                model.CV.Candidate_Id = candidate.Candidate_Id;


                //CV_ID får 0 värde och det är därför vi summerar 1 till vår query 
               model.CV.CV_Id = db.CV.Max(x => x.CV_Id) + 1;

                var cv = db.CV.Add(model.CV);

                db.SaveChanges();

                var languages = model.SelectedLanguages;

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
                        C_ = skills.Contains("2") ? "True" : "False",
                        JavaScript = skills.Contains("3") ? "True" : "False",
                        Java = skills.Contains("4") ? "True" : "False",
                        C__ = skills.Contains("5") ? "True" : "False",
                        JQuery = skills.Contains("6") ? "True" : "False",
                        HTML = skills.Contains("7") ? "True" : "False",
                        CSS = skills.Contains("8") ? "True" : "False",
                        SQL = skills.Contains("9") ? "True" : "False"

                    };

                    db.Skills.Add(s);
                }
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult FreelancerCV(FreelancerCVViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Freelancer.Candidate_Id <= 0)
                {
                    _addFreelancer(model);
                }
                else
                {
                    _editFreelancer(model);
                }

                return RedirectToAction("UpdatedCV", new { id = model.Freelancer.Candidate_Id });
            }

            return View(model);
        }


        #region Helper Methods

        private Language _getLanguage(int cvId, int candidateId, string language)
        {
            return new Language
            {
                CV_Id = cvId,
                Candidate_Id = candidateId,
                Swedish = language.Contains("Svenska").ToString(), 
                English = language.Contains("Engelska").ToString(),
                French = language.Contains("Franska").ToString(),
                Spanish = language.Contains("Spanska").ToString(),
                German = language.Contains("Tyska").ToString(),
                Norwegian = language.Contains("Norska").ToString(),
                Danish = language.Contains("Danska").ToString(),
                Finnish = language.Contains("Finska").ToString(),
            };

        }

        private Profession _getProfession(int cvId, int candidateId, string profession)
        {
            return new Profession
            {
                CV_Id = cvId,
                Candidate_Id = candidateId,

                Webbdeveloper = profession.Contains("Webbutvecklare") ? "True" : "False",
                Systemdeveloper = profession.Contains("Systemutvecklare") ? "True" : "False",
                Programmer = profession.Contains("Programmerare") ? "True" : "False",
                Softwareengineer = profession.Contains("Mjukvaruutveklare") ? "True" : "False",
                Frontenddeveloper = profession.Contains("Frontendutvecklare") ? "True" : "False",
                Backenddeveloper = profession.Contains("Backendutvecklare") ? "True" : "False",
                Javadeveloper = profession.Contains("Javautvecklare") ? "True" : "False",
                Scrummaster = profession.Contains("Scrummaster") ? "True" : "False",
            };

        }

        private Skills _getSkills(int cvId, int candidateId, string skill)
        {
            return new Skills
            {
                CV_Id = cvId,
                Candidate_Id = candidateId,
                C_ = skill.Contains("C#") ? "True" : "False",
                JavaScript = skill.Contains("Javascript") ? "True" : "False",
                Java = skill.Contains("Java") ? "True" : "False",
                C__ = skill.Contains("C++") ? "True" : "False",
                JQuery = skill.Contains("JQuery") ? "True" : "False",
                HTML = skill.Contains("HTML") ? "True" : "False",
                CSS = skill.Contains("CSS") ? "True" : "False",
                SQL = skill.Contains("SQL") ? "True" : "False"

            };

        }
        #endregion

    }
}