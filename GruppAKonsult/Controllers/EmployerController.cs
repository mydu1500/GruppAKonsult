using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models.DomainModels;
using GruppAKonsult.ViewModels;

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

        [HttpGet]
        public ActionResult EmployerFind()
        {
            var model = new EmployerFindViewModel();

            return View(model);
        }

        public ActionResult FreelancerProfileView()
        {
            return View();
        }

        public ActionResult ShowCV(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }

            var model = new ProfileFreelancerViewModel();

            try
            {
                var candidateId = id.HasValue ? id.Value : 0;

                var freelancer = db.Freelancer
                    //.Include(x => x.Skills)
                    .FirstOrDefault(x => x.Candidate_Id == candidateId);

                if (freelancer != null)
                {
                    model.Freelancer = freelancer;
                }

                var cvId = db.CV.FirstOrDefault(x => x.Candidate_Id == candidateId)?.CV_Id;
                var skills = db.Skills.FirstOrDefault(x => x.Candidate_Id == candidateId && x.CV_Id == cvId);

                if (skills != null)
                {
                    model.CandidateSkill = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        (skills.C_ == "True" ? "C#" : ""),
                        (skills.SQL == "True" ? "SQL" : ""),
                        (skills.JavaScript == "True" ? "Javascript" : ""),
                        (skills.Java == "True" ? "Java" : ""),
                        (skills.CSS == "True" ? "CSS" : ""),
                        (skills.HTML == "True" ? "HTML" : ""),
                        (skills.JQuery == "True" ? "JQuery" : "")
                    );
                }

                var profession = db.Profession.FirstOrDefault(x => x.Candidate_Id == candidateId && x.CV_Id == cvId);


                if (profession != null)
                {
                    model.CandidateProfession = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        (profession.Webbdeveloper == "True" ? "Webbdeveloper" : ""),
                        (profession.Backenddeveloper == "True" ? "Backenddeveloper" : ""),
                        (profession.Frontenddeveloper == "True" ? "Frontenddeveloper" : ""),
                        (profession.Javadeveloper == "True" ? "Javadeveloper" : ""),
                        (profession.Programmer == "True" ? "Programmer" : ""),
                        (profession.Scrummaster == "True" ? "Scrummaster" : ""),
                        (profession.Softwareengineer == "True" ? "Softwareengineer" : ""),
                        (profession.Systemdeveloper == "True" ? "Systemdeveloper" : "")
                    );
                }

                var language = db.Language.FirstOrDefault(x => x.Candidate_Id == candidateId && x.CV_Id == cvId);

                if (language != null)
                {
                    model.CandidateLanguage = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        (language.Danish == "True" ? "Danska" : ""),
                        (language.Spanish == "True" ? "Spanska" : ""),
                        (language.English == "True" ? "Engelska" : ""),
                        (language.Finnish == "True" ? "Finska" : ""),
                        (language.French == "True" ? "Franska" : ""),
                        (language.German == "True" ? "Tyska" : ""),
                        (language.Swedish == "True" ? "Svenska" : ""),
                        (language.Norwegian == "True" ? "Norska" : "")
                    );

                }

            }
            catch (Exception ex)
            {

            }


            return View(model);
        }


        [HttpPost]
        public ActionResult EmployerFind(EmployerFindViewModel model)
        {

            // Fråga till databasen via SQL
            var query = (from f in db.Freelancer
                join p in db.Profession on f.Candidate_Id equals p.Candidate_Id
                join l in db.Language on f.Candidate_Id equals l.Candidate_Id
                join s in db.Skills on f.Candidate_Id equals s.Candidate_Id
                select new EmployerFindResultModel
                {
                   Candidate_Id = f.Candidate_Id,
                   Firstname =  f.Firstname,
                   Lastname  = f.Lastname,
                    Professions = ((p.Webbdeveloper == "True" ? "Webbutvecklare," : "") +
                                   (p.Systemdeveloper == "True" ? "Systemutvecklare," : "") +
                                   (p.Programmer == "True" ? "Programmerare," : "") +
                                   (p.Softwareengineer == "True" ? "Mjukvaruutveklare," : "") +
                                   (p.Frontenddeveloper == "True" ? "Frontendutvecklare," : "") +
                                   (p.Backenddeveloper == "True" ? "Backendutvecklare," : "") +
                                   (p.Javadeveloper == "True" ? "Javautvecklare," : "") +
                                   (p.Scrummaster == "True" ? "Scrummaster," : "")),
                    Languages = ((l.Swedish == "True" ? "Svenska," : "") +
                                 (l.English == "True" ? "Engelska," : "") +
                                 (l.French == "True" ? "Franska," : "") +
                                 (l.Spanish == "True" ? "Spanska," : "") +
                                 (l.German == "True" ? "Tyska," : "") +
                                 (l.Norwegian == "True" ? "Norska," : "") +
                                 (l.Danish == "True" ? "Danska," : "") +
                                 (l.Finnish == "True" ? "Finska," : "")),
                    Skills = ((s.C_ == "True" ? "C#" : "") +
                              (s.JavaScript == "True" ? "JavaScript," : "") +
                              (s.Java == "True" ? "Java," : "") +
                              (s.C__ == "True" ? "C++" : "") +
                              (s.JQuery == "True" ? "JQuery," : "") +
                              (s.HTML == "True" ? "HTML," : "") +
                              (s.CSS == "True" ? "CSS," : "") +
                              (s.SQL == "True" ? "SQL," : ""))
                }).ToList();


            //Vår sökfunktion
            var list = new List<EmployerFindResultModel>();
            var professionKey = model.ProfessionList.FirstOrDefault(x => x.Value == model.SelectedProfession)?.Text;
            
            if (professionKey != null)
            {
                 list = query.Where(x => x.Professions.Contains(professionKey)).ToList();
            }

            var skillKey = model.SkillsList.FirstOrDefault(x => x.Value == model.SelectedSkill)?.Text;

            if (skillKey != null)
            {
                list = query.Where(x => x.Skills.Contains(skillKey)).ToList();
            }

            var languageKey = model.LanguageList.FirstOrDefault(x => x.Value == model.SelectedLanguage)?.Text;

            if (languageKey != null)
            {
                list = query.Where(x => x.Languages.Contains(languageKey)).ToList();
            }

            model.SearchResults = list;

            return View(model);


        }

        

    }
}