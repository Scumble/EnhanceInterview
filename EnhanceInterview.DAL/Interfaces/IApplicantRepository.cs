using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IApplicantRepository
	{
		void AddApplicant(Applicant applicant);

		void UpdateApplicant(Applicant applicant);

		Applicant GetApplicantById(int id);

		Applicant GetApplicantByUserId(string userId);
	}
}