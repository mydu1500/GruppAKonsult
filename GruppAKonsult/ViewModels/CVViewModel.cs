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
        public Nullable<int> Phonenumber { get; set; }

        //Egenskaper från freelancer
        public int Candidate_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public Nullable<int> Postalnumber { get; set; }
        public string City { get; set; }
        public Nullable<int> Birthdate { get; set; }
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
            LanguageList = new List<SelectListItem>() //move to db in future
            {
               
                new SelectListItem { Value = "Svenska", Text = "Svenska"},
                new SelectListItem { Value = "Engelska", Text = "Engelska"},
                new SelectListItem { Value = "Franska", Text = "Franska"},
                new SelectListItem { Value = "Spanska", Text = "Spanska"},
                new SelectListItem { Value = "Tyska", Text = "Tyska"},
                new SelectListItem { Value = "Norska", Text = "Norska"},
                new SelectListItem { Value = "Danska", Text = "Danska"},
                new SelectListItem { Value = "Finska", Text = "Finska"}

            };
        }

        private void AddProfessionList()
        {
            ProfessionList = new List<SelectListItem>() //move to db in future
            {
                new SelectListItem { Value = "Webbutvecklare", Text = "Webbutvecklare" },
                new SelectListItem { Value = "Systemutvecklare", Text = "Systemutvecklare" },
                new SelectListItem { Value = "Programmerare", Text = "Programmerare" },
                new SelectListItem { Value = "Mjukvaruutveklare", Text = "Mjukvaruutveklare" },
                new SelectListItem { Value = "Frontendutvecklare", Text = "Frontendutvecklare" },
                new SelectListItem { Value = "Backendutvecklare", Text = "Backendutvecklare" },
                new SelectListItem { Value = "Javautvecklare", Text = "Javautvecklare" },
                new SelectListItem { Value = "Scrummaster", Text = "Scrummaster" }
            };
        }

        private void AddSkillsList()
        {
            SkillsList = new List<SelectListItem>() //move to db in future save id and name e.g. Id = 1, name = c#
            {
                new SelectListItem { Value = "C#", Text = "C#" },
                new SelectListItem { Value = "Javascript", Text = "Javascript" },
                new SelectListItem { Value = "Java", Text = "Java" },
                new SelectListItem { Value = "C++", Text = "C++" },
                new SelectListItem { Value = "JQuery", Text = "JQuery" },
                new SelectListItem { Value = "HTML", Text = "HTML" },
                new SelectListItem { Value = "CSS", Text = "CSS" },
                new SelectListItem { Value = "SQL", Text = "SQL" }
            };
        }

        private void AddCityList()
        {
            CityList = new List<SelectListItem>() //move to db in future
            {
                new SelectListItem { Value = "Helsingborg", Text = "Helsingborg" },
                new SelectListItem { Value = "Kristianstad", Text = "Kristianstad" },
                new SelectListItem { Value = "Landskrona", Text = "Landskrona" },
                new SelectListItem { Value = "Lund", Text = "Lund" },
                new SelectListItem { Value = "Malmö", Text = "Malmö" },
                new SelectListItem { Value = "Ystad", Text = "Ystad" },
                new SelectListItem { Value = "Stockholm", Text = "Stockholm" },
                new SelectListItem { Value = "Göteborg", Text = "Göteborg" }
            };
        }
    }
}




            //public void AddLanguageList()
            //{
            //    List<Language> languagelist = new List<Language>();

            //    // adding elements in firstlist 
            //    for (int i = 0; i < languagelist.Count; i++)
            //    {
            //        languagelist.Add(languagelist[i]);
            //    }

            //}
            //public void AddSkillsList()
            //{
            //    List<Skills> skillslist = new List<Skills>();

            //    // adding elements in firstlist 
            //    for (int i = 0; i < skillslist.Count; i++)
            //    {
            //        skillslist.Add(skillslist[i]);
            //    }

            //}
            //public void AddProfessionList()
            //{
            //    List<Profession> professionlist = new List<Profession>();

            //    // adding elements in firstlist 
            //    for (int i = 0; i < professionlist.Count; i++)
            //    {
            //        professionlist.Add(professionlist[i]);
            //    }

            //}

            //public IEnumerable<SelectListItem> AllProfessions { get; set; }
            //private List<int> listOfProfessions;
            //public List<int> ListOfProfessions
            //{
            //    get
            //    {
            //        if (listOfProfessions == null)
            //        {
            //            listOfProfessions = Cv.Profession.Select(m => m.Candidate_Id).ToList();
            //        }
            //        return listOfProfessions;
            //    }
            //    set { listOfProfessions = value; }
            //}
