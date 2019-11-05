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