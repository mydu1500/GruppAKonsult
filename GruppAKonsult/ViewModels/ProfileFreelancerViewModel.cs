using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GruppAKonsult.Models;

namespace GruppAKonsult.ViewModels
{
    public class ProfileFreelancerViewModel
    {
        public Freelancer Freelancer { get; set; }

        public string ProfilePicPath { get; set; }

        public string CandidateSkill { get; set; }
        public string CandidateProfession { get;  set; }
        public string CandidateLanguage { get; set; }
    }
}