using System.Collections.Generic;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface ICompanyRepository
	{
		Company GetCompanyById(int companyId);

		IEnumerable<Company> GetCompanies(string searchString);

		Company GetCompanyByName(string companyName);

		void AddCompany(Company company);

		void UpdateCompany(Company company);

		void DeleteCompany(int companyId);
	}
}