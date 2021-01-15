using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface ICompanyService
	{
		CompanyDto GetCompanyById(int companyId);

		IEnumerable<CompanyDto> GetCompanies(string searchString);

		CompanyDto GetCompanyByName(string companyName);

		void AddCompany(CompanyDto company);

		void UpdateCompany(CompanyDto company);

		void DeleteCompany(int companyId);
	}
}