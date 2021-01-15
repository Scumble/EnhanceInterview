using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IVacancyService
	{
		void AddVacancy(VacancyDto vacancyDto);

		void UpdateVacancy(VacancyDto vacancy);

		void DeleteVacancy(int vacancyId);

		VacancyDto GetVacancyById(int vacancyId);

		IEnumerable<VacancyDto> GetVacanciesByCompanyId(int companyId, string searchString);

		IEnumerable<VacancyDto> GetVacanciesForApplicant(int applicantId, string searchString);
	}
}