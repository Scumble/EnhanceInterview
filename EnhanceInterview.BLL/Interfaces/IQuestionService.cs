using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IQuestionService
	{
		IEnumerable<QuestionDto> GetQuestionsByVacancyId(int vacancyId, string category, string searchString);

		QuestionDto GetQuestionById(int questionId);

		void AddQuestion(QuestionDto questionDto, int vacancyId);

		void UpdateQuestion(QuestionDto questionDto);

		void DeleteQuestion(int questionId, int vacancyId);
	}
}