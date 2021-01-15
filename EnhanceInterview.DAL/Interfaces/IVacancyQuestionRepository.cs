using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IVacancyQuestionRepository
	{
		VacancyQuestion GetVacancyQuestionById(int? vacancyQuestionId);

		void AddVacancyQuestion(VacancyQuestion vacancyQuestion);

		void UpdateVacancyQuestion(VacancyQuestion vacancyQuestion);

		void DeleteVacancyQuestion(int questionId, int vacancyId);
	}
}