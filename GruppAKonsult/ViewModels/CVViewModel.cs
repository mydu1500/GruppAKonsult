using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppAKonsult.ViewModels
{
    public class CVViewModel
    {
        public CVViewModel()
        {
            AddLanguageList();
            AddProfessionList();
            AddSkillsList();
            AddCityList();
        }

        //Egenskaper från CV
        public string Drivinglicense { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }
        public string Workexperience { get; set; }

        //Egenskaper från employer   
        public string Companyname { get; set; }
        public string Email { get; set; }
        //public Nullable<int> Phonenumber { get; set; }
        public int Phonenumber { get; set; }

        //Egenskaper från freelancer
        public int Candidate_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        //public Nullable<int> Postalnumber { get; set; }
        public int Postalnumber { get; set; }

        public string City { get; set; }
        //public Nullable<int> Birthdate { get; set; }

        public int Birthdate { get; set; }
        public string Cityofbirth { get; set; }

        //Onödig??
        //public List<Language> Language { get; set; }
        //public List<Skills> Skills { get; set; }
        //public List<Profession> Profession { get; set; }

        public Freelancer Freelancer { get; set; }

        public CV CV { get; set; }

        public string[] SelectedLanguages { get; set; }

        public string[] SelectedProfessions { get; set; }

        public string[] SelectedSkills { get; set; }

        public string SelectedProfession { get; set; }

        public string SelectedSkill { get; set; }

        public string SelectedLanguage { get; set; }

        public string SelectedCity { get; set; }

        public IEnumerable<SelectListItem> LanguageList { get; set; }

        public IEnumerable<SelectListItem> ProfessionList { get; set; }

        public IEnumerable<SelectListItem> SkillsList { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }

        private void AddLanguageList()
        {
            LanguageList = new List<SelectListItem>()
            {
               
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
                new SelectListItem { Text = "Välj Yrkesområde" },
                new SelectListItem { Value = "2", Text = "Webbutvecklare" },
                new SelectListItem { Value = "3", Text = "Systemutvecklare" },
                new SelectListItem { Value = "4", Text = "Programmerare" },
                new SelectListItem { Value = "5", Text = "Mjukvaruutveklare" },
                new SelectListItem { Value = "6", Text = "Frontendutvecklare" },
                new SelectListItem { Value = "7", Text = "Backendutvecklare" },
                new SelectListItem { Value = "8", Text = "Javautvecklare" },
                new SelectListItem { Value = "9", Text = "Scrummaster" }
            };
        }

        private void AddSkillsList()
        {
            SkillsList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Välj kompetens" },
                new SelectListItem { Value = "2", Text = "C#" },
                new SelectListItem { Value = "3", Text = "JavaScript" },
                //new SelectListItem { Value = "4", Text = "Java" },
                new SelectListItem { Value = "5", Text = "C++" },
                new SelectListItem { Value = "6", Text = "JQuery" },
                new SelectListItem { Value = "7", Text = "HTML" },
                new SelectListItem { Value = "8", Text = "CSS" },
                new SelectListItem { Value = "9", Text = "SQL" }
            };
        }

        private void AddCityList()
        {
            CityList = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Helsingborg" },
                new SelectListItem { Value = "2", Text = "Kristianstad" },
                new SelectListItem { Value = "3", Text = "Landskrona" },
                new SelectListItem { Value = "4", Text = "Lund" },
                new SelectListItem { Value = "5", Text = "Malmö" },
                new SelectListItem { Value = "6", Text = "Ystad" },
                new SelectListItem { Value = "7", Text = "Stockholm" },
                new SelectListItem { Value = "7", Text = "Göteborg" }
            };
        }

    }
}




           
