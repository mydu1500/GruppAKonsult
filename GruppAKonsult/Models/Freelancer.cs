using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppAKonsult.Models
{
    public class Freelancer
    {
        public int FreelancerID { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public int Phonenumber { get; set; }

        public char Address { get; set; }
    }
}