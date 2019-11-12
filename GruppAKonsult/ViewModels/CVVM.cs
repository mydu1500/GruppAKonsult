using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GruppAKonsult.ViewModels
{
    public class CVVM
    {
        [Required(ErrorMessage ="Var snäll och fyll i fältet", AllowEmptyStrings =false)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Var snäll och fyll i fältet",AllowEmptyStrings =false)]
        public string Education { get; set; }

        [Required(ErrorMessage = "Var snäll och fyll i fältet", AllowEmptyStrings =false)]
        public string Workexperience { get; set; }

    }
}