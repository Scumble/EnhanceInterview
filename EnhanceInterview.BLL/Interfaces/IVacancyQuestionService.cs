using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IVacancyQuestionService
	{
		VacancyQuestionDto GetVacancyQuestionById(int? vacancyQuestionId);

		void AddVacancyQuestion(VacancyQuestionDto vacancyQuestionDto);

		void UpdateVacancyQuestion(VacancyQuestionDto vacancyQuestionDto);

		void DeleteVacancyQuestion(int questionId, int vacancyId);
	}
}