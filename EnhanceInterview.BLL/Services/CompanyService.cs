using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
		{
			_companyRepository = companyRepository;
			_mapper = mapper;
		}

		public CompanyDto GetCompanyById(int companyId)
		{
			return _mapper.Map<Company, CompanyDto>(_companyRepository.GetCompanyById(companyId));
		}

		public IEnumerable<CompanyDto> GetCompanies(string searchString)
		{
			return _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(_companyRepository.GetCompanies(searchString));
		}

		public CompanyDto GetCompanyByName(string companyName)
		{
			return _mapper.Map<Company, CompanyDto>(_companyRepository.GetCompanyByName(companyName));
		}

		public void AddCompany(CompanyDto company)
		{
			_companyRepository.AddCompany(_mapper.Map<CompanyDto, Company>(company));
		}

		public void UpdateCompany(CompanyDto company)
		{
			_companyRepository.UpdateCompany(_mapper.Map<CompanyDto, Company>(company));
		}

		public void DeleteCompany(int companyId)
		{
			_companyRepository.DeleteCompany(companyId);
		}
	}
}