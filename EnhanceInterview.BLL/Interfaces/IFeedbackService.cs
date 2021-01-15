using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IFeedbackService
	{
		IEnumerable<FeedbackDto> GetApplicantFeedbacks(int interviewId);

		void AddFeedback(FeedbackDto feedbackDto);

		void UpdateFeedback(FeedbackDto feedbackDto);

		void DeleteFeedback(int feedbackId);
	}
}