using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models.DomainModels;

namespace GruppAKonsult.ViewModels
{

    public class EmployerFindViewModel : CVViewModel
    {
        public IEnumerable<EmployerFindResultModel> SearchResults { get; set; }
    }
}