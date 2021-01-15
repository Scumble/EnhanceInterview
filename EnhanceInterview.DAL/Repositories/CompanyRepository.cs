using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly DatabaseContext _context;
		public CompanyRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<Company> GetCompanies(string searchString)
		{
			return _context.Companies.Where(x => x.Name.Contains(searchString));
		}

		public Company GetCompanyById(int companyId)
		{
			return _context.Companies.FirstOrDefault(x => x.Id == companyId);
		}

		public Company GetCompanyByName(string companyName)
		{
			return _context.Companies.FirstOrDefault(x => x.Name == companyName);
		}

		public void AddCompany(Company company)
		{
			if (company.Id == 0)
			{
				_context.Companies.Add(company);
			}
			else
			{
				var dbEntry = _context.Companies.Find(company.Id);
				if (dbEntry != null)
				{
					dbEntry.Name = company.Name;
					dbEntry.Description = company.Description;
					dbEntry.Location = company.Location;
				}
			}

			_context.SaveChanges();
		}

		public void UpdateCompany(Company company)
		{
			_context.Entry(company).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteCompany(int companyId)
		{
			var company = _context.Companies.Find(companyId);

			if (company == null)
			{
				return;
			}

			_context.Companies.Remove(company);
			_context.SaveChanges();
		}
	}
}