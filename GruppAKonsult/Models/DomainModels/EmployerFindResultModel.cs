using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppAKonsult.Models.DomainModels
{
    public class EmployerFindResultModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Candidate_Id { get;  set; }
        public string Professions { get;  set; }
        public string Languages { get;  set; }
        public string Skills { get; set; }
    }
}