using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IRecruiterRepository
	{
		Recruiter GetRecruiterByUserId(string userId);

		Recruiter GetRecruiterById(int? recruiterId);

		void AddRecruiter(Recruiter recruiter);
	}
}