using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IInterviewService
	{
		IEnumerable<InterviewDto> GetAppliedInterviews(int applicantId, string searchString, string status);

		IEnumerable<InterviewDto> GetInterviewsByCompanyId(int companyId, string searchString, string status);

		InterviewDto AddInterview(InterviewDto interviewDto);

		void UpdateInterview(InterviewDto interviewDto);

		InterviewDto GetInterviewById(int interviewId);

		InterviewDto GetInterviewByVacancyId(int vacancyId);

		InterviewDto GetInterviewByApplicantId(int applicantId, int vacancyId);
	}
}