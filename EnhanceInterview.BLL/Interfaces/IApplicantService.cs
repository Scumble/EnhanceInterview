using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IApplicantService
	{
		void AddApplicant(ApplicantDto applicantDto);

		void UpdateApplicant(ApplicantDto applicantDto);

		ApplicantDto GetApplicantById(int id);

		ApplicantDto GetApplicantByUserId(string userId);
	}
}