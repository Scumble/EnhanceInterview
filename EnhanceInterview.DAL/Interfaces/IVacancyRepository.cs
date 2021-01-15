using System.Collections.Generic;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IVacancyRepository
	{
		void AddVacancy(Vacancy vacancy);

		void UpdateVacancy(Vacancy vacancy);

		void DeleteVacancy(int vacancyId);

		VacancyViewModel GetVacancyById(int vacancyId);

		IEnumerable<VacancyViewModel> GetVacanciesByCompanyId(int companyId, string searchString);

		IEnumerable<VacancyViewModel> GetVacanciesForApplicant(int applicantId, string searchString);
	}
}