using System;
using System.Collections.Generic;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IInterviewRepository
	{
		IEnumerable<InterviewViewModel> GetAppliedInterviews(int applicantId, string searchString, string status);

		IEnumerable<InterviewViewModel> GetInterviewsByCompanyId(int companyId, string searchString, string status);

		Interview AddInterview(Interview interview);

		void UpdateInterview(Interview interview);

		Interview GetInterviewById(int interviewId);

		Interview GetInterviewByVacancyId(int vacancyId);

		Interview GetInterviewByApplicantId(int applicantId, int vacancyId);
	}
}