using System;
using System.Collections.Generic;
using System.IO;
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

        //visa profile efter id 
        public ActionResult ProfileFreelancer(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("FreelancerCV");
            }

            var model = new ProfileFreeLancerViewModel();

            try
            {
                var candidateId = id.HasValue ? id.Value : 0;

                var freelancer = db.Freelancer.FirstOrDefault(x => x.Candidate_Id == candidateId);

                if (freelancer != null)
                {
                    model.Freelancer = freelancer;
                }

                var fileName = string.Format("~/Content/Uploads/{0}.jpg", candidateId);

                //var path = Path.Combine("/Content/Uploads/", fileName);

                model.ProfilePicPath = fileName;
            }
            catch (Exception ex)
            {

            }

            return View(model);
        }



        public ActionResult EmptyNewProfile()
        {
            return View();
        }

        public ActionResult FreelancerCV(int? id)
        {
            var model = new FreelancerCVViewModel
            {
                Freelancer = new Freelancer(),
                CV =  new CV()
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
                        selectedLanguage  = "Tyska";
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

                return RedirectToAction("ProfileFreelancer", new { id = model.Freelancer.Candidate_Id });
            }

            return View(model);
        }


        

        #region  Add/Edit Freelancer 
       
        private void _addFreelancer(FreelancerCVViewModel model)
        {
            var candidate = db.Freelancer.Add(model.Freelancer);

            db.SaveChanges();

            model.CV.Candidate_Id = candidate.Candidate_Id;

            if (model.ProfilePic != null && model.ProfilePic.ContentLength > 0)
            {
                var basePath = Server.MapPath("~/Content/Uploads"); //this just gets the uploads folder. Server.MapPath gives the project server directory and then it wil search inside Content/Uploads
                var extension = Path.GetExtension(model.ProfilePic.FileName); //Here we need to get the extension of the uploaded file (proper way) but we dont save extension in the database and so for now it must be always jpg files
                var fileName = string.Format("{0}{1}", candidate.Candidate_Id, extension); //here framing the full filename + extension
                var path = Path.Combine(basePath, fileName); //combining the server uploads path + file name

                model.ProfilePic.SaveAs(path); //just saving in the exact location
            }


            //now this method is being used for both Add and Edit scenario and so we need to do few tweaks

            //CV_ID får 0 värde och det är därför vi summerar 1 till vår query 

            if (model.CV.CV_Id <= 0)
            {
                model.CV.CV_Id = db.CV.Max(x => x.CV_Id) + 1;
            }


            var cv = db.CV.Add(model.CV);

            db.SaveChanges();

            var language = model.SelectedLanguage;

            if (language != null)
            {
                db.Language.Add(_getLanguage(cv.CV_Id, candidate.Candidate_Id, language));
            }


            var profession = model.SelectedProfession;

            if (profession != null)
            {

                db.Profession.Add(_getProfession(cv.CV_Id, candidate.Candidate_Id, profession));
            }

            var skill = model.SelectedSkill;

            if (skill != null)
            {

                db.Skills.Add(_getSkills(cv.CV_Id, candidate.Candidate_Id, skill));
            }

            db.SaveChanges();
        }

       
        private void _editFreelancer(FreelancerCVViewModel model)
        {

            var existingFreelancer = db.Freelancer.FirstOrDefault(x => x.Candidate_Id == model.Freelancer.Candidate_Id);

            if (existingFreelancer != null)
            {
                db.Entry(existingFreelancer).CurrentValues.SetValues(model.Freelancer);
            }

            var existingCV = db.Freelancer.FirstOrDefault(x => x.Candidate_Id == model.Freelancer.Candidate_Id);

            if (existingCV != null)
            {
                db.Entry(existingCV).CurrentValues.SetValues(model.CV);
            }

           

            var selectedLanguage = model.SelectedLanguage;

            if (selectedLanguage != null)
            {
                var existingLanguage = db.Language.FirstOrDefault(x => x.Candidate_Id == model.Freelancer.Candidate_Id && x.CV_Id == model.CV.CV_Id);

                var language = _getLanguage(model.CV.CV_Id, model.Freelancer.Candidate_Id, selectedLanguage);

                if (existingLanguage == null)
                {
                    db.Language.Add(language);
                }
                else
                {
                    db.Entry(existingLanguage).CurrentValues.SetValues(language);
                }
                
            }


                var selectedProfession = model.SelectedProfession;

            if (selectedProfession != null)
            { 
                var existingProfession = db.Profession.FirstOrDefault(x => x.Candidate_Id == model.Freelancer.Candidate_Id && x.CV_Id == model.CV.CV_Id);
                var profession = _getProfession(model.CV.CV_Id, model.Freelancer.Candidate_Id, selectedProfession);

                if (existingProfession == null)
                {
                    db.Profession.Add(profession);
                }
                else
                {
                    db.Entry(existingProfession).CurrentValues.SetValues(profession);
                }
            }

            var selectedSkill = model.SelectedSkill;

            if (selectedSkill != null)
            {

                var existingSkills = db.Skills.FirstOrDefault(x => x.Candidate_Id == model.Freelancer.Candidate_Id && x.CV_Id == model.CV.CV_Id);
                var skill = _getSkills(model.CV.CV_Id, model.Freelancer.Candidate_Id, selectedSkill);

                if (existingSkills == null)
                {
                    db.Skills.Add(skill);
                }
                else
                {
                    db.Entry(existingSkills).CurrentValues.SetValues(skill);
                }
            }

        }

        #endregion

        #region Helper Methods

        private Language _getLanguage(int cvId, int candidateId, string language)
        {
            return new Language
            {
                CV_Id = cvId,
                Candidate_Id = candidateId,
                Swedish = language.Contains("Svenska").ToString(), //shorthand
                English = language.Contains("Engelska").ToString(),
                French = language.Contains("Franska").ToString(),
                Spanish = language.Contains("Spanska").ToString(),
                German = language.Contains("Tyska").ToString(),
                Norwegian = language.Contains("Norska").ToString(),
                Danish = language.Contains("Danska").ToString(),
                Finnish = language.Contains("Finska").ToString(),
            };

        }

        private Profession _getProfession(int cvId, int candidateId, string  profession)
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