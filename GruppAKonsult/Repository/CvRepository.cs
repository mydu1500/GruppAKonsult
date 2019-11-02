using GruppAKonsult.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GruppAKonsult.ViewModels;

namespace GruppAKonsult.Repository
{
    public class CvRepository : ICvRepository
    {
        //db 
        private readonly GruppAKonsult_dbEntities dbEntities = new GruppAKonsult_dbEntities();


        //Implementering av Interface
        public bool AddFreelancerInformation(Freelancer freelancer, HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }

        public bool AddLanguage(Language language, int Candidate_Id)
        {
            int temp = 0;

            Freelancer freelancer = dbEntities.Freelancer.Find(Candidate_Id);

            if(freelancer != null && language != null)
            {
                freelancer.Language.Add(language);
                temp = dbEntities.SaveChanges();

            }

        }

        public string AddOrUpdateCv(CV cv, int candidateId)
        {
            throw new NotImplementedException();
        }

        public string AddOrUpdateSkills(Skills skills, int candidateId)
        {
            throw new NotImplementedException();
        }

        public bool AddProfession(Profession profession, int candidateId)
        {
            throw new NotImplementedException();
        }

        public int GetCandidate_Id(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Freelancer GetPersonalInfo(int candidateId)
        {
            throw new NotImplementedException();
        }
    }
}