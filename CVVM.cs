using System;
using GruppAKonsult.Models;

public class CVVM
{
	public CVVM()
	{
	}

    public CV cv { get; set; }
    public IEnumerable<SelectListItem> AllProfessions { get; set; }
    private List<int> listOfProfessions;
    public List<int> ListOfProfessions
    {
        get
        {
            if (listOfProfessions == null)
            {
                listOfProfessions = CV.Profession.Select(m => m.Candidate_Id).ToList();
            }
            return listOfProfessions;
        }
        set { listOfProfessions = value; }
    }
}
