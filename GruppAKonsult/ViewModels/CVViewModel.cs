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
        public CV Cv { get; set; }
        public Profession Profession { get; set; }  //Lägga till alla klasser här, skills, language etc?
        public Skills Skills { get; set; }
        public Language Language { get; set; }
        public Freelancer Freelancer { get; set; }
        public Employer Employer { get; set; }
        public Profile Profile { get; set; }
        public Jobbank Jobbank { get; set; }

        public IEnumerable<SelectListItem> AllProfessions { get; set; }
        private List<int> listOfProfessions;
        public List<int> ListOfProfessions
        {
            get
            {
                if (listOfProfessions == null)
                {
                    listOfProfessions = Cv.Profession.Select(m => m.Candidate_Id).ToList();
                }
                return listOfProfessions;
            }
            set { listOfProfessions = value; }
        }
    }
}
