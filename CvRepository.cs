using System;
using GruppAKonsult.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;

namespace CvRepository.Repository
{
	public interface ICvRepository
	{
        int GetCandidate_Id(string firstname, string lastname);
        bool AddFreelancerInformation(Freelancer freelancer, HttpPostedFilebase file);
        string AddOrUpdateSkills(Skills skills, int candidateId);
        bool AddLanguage(Languahe, int candidateId);
        string AddOrUpdateCv(CV cv, int candidateId);
        Freelancer GetPersonalInfo(int candidateId);


	}
}
