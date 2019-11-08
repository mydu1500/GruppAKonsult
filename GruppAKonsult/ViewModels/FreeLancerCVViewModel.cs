using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GruppAKonsult.Models;

namespace GruppAKonsult.ViewModels
{
    public class FreelancerCVViewModel : CVViewModel
    {

        public FreelancerCVViewModel()
        {
            AddLanguageList();
            AddProfessionList();
            AddSkillsList();
        }

        public Freelancer Freelancer { get; set; }

        public CV CV { get; set; }

        public string[] SelectedLanguage { get; set; }

        public string[] SelectedProfessions { get; set; }

        public string[] SelectedSkills { get; set; }

        public IEnumerable<SelectListItem> LanguageList { get; set; }

        public IEnumerable<SelectListItem> ProfessionList { get; set; }

        public IEnumerable<SelectListItem> SkillsList { get; set; }

        private void AddLanguageList()
        {
            LanguageList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Språk"},
                new SelectListItem { Value = "2", Text = "Svenska"},
                new SelectListItem { Value = "3", Text = "Engelska"},
                new SelectListItem { Value = "4", Text = "Franska"},
                new SelectListItem { Value = "5", Text = "Spanska"},
                new SelectListItem { Value = "6", Text = "Tyska"},
                new SelectListItem { Value = "7", Text = "Norska"},
                new SelectListItem { Value = "8", Text = "Danska"},
                new SelectListItem { Value = "9", Text = "Finska"}


            };
        }

        private void AddProfessionList()
        {
            ProfessionList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Grafisk designer" },
                new SelectListItem { Value = "2", Text = "Programmerare" },
                new SelectListItem { Value = "3", Text = "Webbutvecklare" },
                new SelectListItem { Value = "4", Text = "Javautvecklare" },
                new SelectListItem { Value = "5", Text = "Scrummaster" },
                new SelectListItem { Value = "6", Text = "Frontend utvecklare" },
                new SelectListItem { Value = "7", Text = "Backend utvecklar" }
            };
        }

        private void AddSkillsList()
        {
            SkillsList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Java" },
                new SelectListItem { Value = "2", Text = "HTML" },
                new SelectListItem { Value = "3", Text = "Javascript" },
                new SelectListItem { Value = "4", Text = "CSS" },
                new SelectListItem { Value = "5", Text = "C++" },
                new SelectListItem { Value = "6", Text = "JQuery" },
                new SelectListItem { Value = "7", Text = "SQL" }
            };
        }
    }
}
