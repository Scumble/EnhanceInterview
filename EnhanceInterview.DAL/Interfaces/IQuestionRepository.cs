using System.Collections.Generic;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IQuestionRepository
	{
		IEnumerable<QuestionViewModel> GetQuestionsByVacancyId(int vacancyId, string category, string searchString);

		QuestionViewModel GetQuestionById(int questionId);

		Question AddQuestion(Question question);

		void UpdateQuestion(Question question);

		void DeleteQuestion(int questionId);
	}
}