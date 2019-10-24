using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppAKonsult.Models
{
    public class Employer
    {
        public int EmployerID { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public int Phonenumber { get; set;}
        
        public char Address { get; set;}
        
    }

    
}