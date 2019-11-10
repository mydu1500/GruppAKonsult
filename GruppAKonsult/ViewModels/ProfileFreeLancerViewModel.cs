using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GruppAKonsult.Models;

namespace GruppAKonsult.ViewModels
{
    public class ProfileFreeLancerViewModel
    {
        public Freelancer Freelancer { get; set; }

        public string ProfilePicPath { get; set; }
    }
}