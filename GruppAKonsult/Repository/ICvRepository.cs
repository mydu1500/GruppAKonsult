using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GruppAKonsult.Repository
{
    
        public interface ICvRepository
        {
            int GetCandidate_Id(string firstname, string lastname);
            bool AddFreelancerInformation(Freelancer freelancer, HttpPostedFileBase file);
            string AddOrUpdateSkills(Skills skills, int candidateId);
            bool AddLanguage(Language language, int candidateId);
            string AddOrUpdateCv(CV cv, int candidateId);
            Freelancer GetPersonalInfo(int candidateId);
            bool AddProfession(Profession profession, int candidateId);
            bool AddDriverLicense(CV cv, int candidateID);



        }

    
}
