using System.Collections.Generic;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IFeedbackRepository
	{
		IEnumerable<FeedbackViewModel> GetApplicantFeedbacks(int interviewId);

		void AddFeedback(Feedback feedback);

		void UpdateFeedback(Feedback feedback);

		void DeleteFeedback(int feedbackId);
	}
}