using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IAnswerService
	{
		IEnumerable<AnswerDto> GetInterviewResultsByInterviewId(int interviewId, string searchString, string category);

		AnswerDto AddAnswer(AnswerDto answerDto);

		void UpdateAnswer(AnswerDto answerDto);

		void DeleteAnswer(int answerId);
	}
}