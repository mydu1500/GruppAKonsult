using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models;

namespace GruppAKonsult.ViewModels
{
    public class FreelancerCVViewModel : CVViewModel
    {

        public HttpPostedFileBase ProfilePic { get; set; }

       
    }
}
