//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruppAKonsult.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skills
    {
        public int CV_Id { get; set; }
        public int Candidate_Id { get; set; }
        public string C_ { get; set; }
        public string JavaScript { get; set; }
        public string Java { get; set; }
        public string C__ { get; set; }
        public string JQuery { get; set; }
        public string HTML { get; set; }
        public string CSS { get; set; }
        public string SQL { get; set; }
    
        public virtual Freelancer Freelancer { get; set; }
    }
}
