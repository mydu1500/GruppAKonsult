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
        public string Nationality { get; set; }
        public string Address { get; set; }
        public Nullable<int> Postalnumber { get; set; }
        public string City { get; set; }
        public Nullable<int> Birthdate { get; set; }
        public string Cityofbirth { get; set; }
      

        public List<Language> Language { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Profession> Profession { get; set; }


        public void AddLanguageList ()
        {            
            List<Language> languagelist = new List<Language>();

            // adding elements in firstlist 
            for (int i = 0; i < languagelist.Count; i++)
            {
                languagelist.Add(languagelist[i]);
            }
        
        }
        public void AddSkillsList()
        {
            List<Skills> skillslist = new List<Skills>();

            // adding elements in firstlist 
            for (int i = 0; i < skillslist.Count; i++)
            {
                skillslist.Add(skillslist[i]);
            }

        }
        public void AddProfessionList()
        {
            List<Profession> professionlist = new List<Profession>();

            // adding elements in firstlist 
            for (int i = 0; i < professionlist.Count; i++)
            {
                professionlist.Add(professionlist[i]);
            }

        }

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
    }
}
