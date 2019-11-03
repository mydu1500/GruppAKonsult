using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GruppAKonsult.ViewModels
{
    public class EmployerVM
    {
        [Required(ErrorMessage = "Var snäll och fyll i fältet")]
        public string Companyname { get; set; }
        [Required(ErrorMessage = "Var snäll och fyll i fältet")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Var snäll och fyll i fältet")]
        public int Phonenumber { get; set; }
    }
}