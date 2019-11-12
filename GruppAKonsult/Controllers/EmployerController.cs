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

        public ActionResult ShowCV()
        {
            return View();
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
                    Skills = ((s.C_ == "True" ? "c," : "") +
                              (s.JavaScript == "True" ? "JavaScript," : "") +
                              (s.Java == "True" ? "Java," : "") +
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