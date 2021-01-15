using System.Collections.Generic;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IAnswerRepository
	{
		IEnumerable<AnswerViewModel> GetInterviewResultsByInterviewId(int interviewId, string searchString, string category);

		Answer AddAnswer(Answer answer);

		void UpdateAnswer(Answer answer);

		void DeleteAnswer(int answerId);
	}
}