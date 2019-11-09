using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GruppAKonsult.Models;

namespace GruppAKonsult.ViewModels
{
    public class FreelancerCVViewModel : CVViewModel
    {

        public Freelancer Freelancer { get; set; }

        public CV CV { get; set; }

       
    }
}
