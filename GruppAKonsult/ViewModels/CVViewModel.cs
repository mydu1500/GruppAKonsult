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
        public CV cv { get; set; }
        public IEnumerable<SelectListItem> AllProfessions { get; set; }
        private List<int> listOfProfessions;
        public List<int> ListOfProfessions
        {
            get
            {
                if (listOfProfessions == null)
                {
                    listOfProfessions = CV.Profession.Select(m => m.Candidate_Id).ToList();
                }
                return listOfProfessions;
            }
            set { listOfProfessions = value; }
        }
    }
}