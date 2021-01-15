using System;
using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class VacancyRepository : IVacancyRepository
	{
		private readonly DatabaseContext _context;

		public VacancyRepository(DatabaseContext context)
		{
			_context = context;
		}

		public void AddVacancy(Vacancy vacancy)
		{
			if (vacancy.Id == 0)
			{
				vacancy.StartDate = DateTime.Now;
				_context.Vacancies.Add(vacancy);
			}
			else
			{
				var dbEntry = _context.Vacancies.Find(vacancy.Id);
				if (dbEntry != null)
				{
					dbEntry.RecruiterId = vacancy.RecruiterId;
					dbEntry.Title = vacancy.Title;
					dbEntry.Info = vacancy.Info;
					dbEntry.Location = vacancy.Location;
					dbEntry.EndDate = vacancy.EndDate;
				}
			}

			_context.SaveChanges();
		}

		public void UpdateVacancy(Vacancy vacancy)
		{
			_context.Entry(vacancy).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteVacancy(int vacancyId)
		{
			var vacancy = _context.Vacancies.Find(vacancyId);

			if (vacancy == null)
			{
				return;
			}

			_context.Vacancies.Remove(vacancy);
			_context.SaveChanges();
		}

		public VacancyViewModel GetVacancyById(int vacancyId)
		{
			var vacancies = from vacancy in _context.Vacancies
				join recruiter in _context.Recruiters on vacancy.RecruiterId equals recruiter.Id
				join worker in _context.Workers on recruiter.WorkerId equals worker.Id
				join company in _context.Companies on worker.CompanyId equals company.Id
				where vacancy.Id == vacancyId
				select new VacancyViewModel
				{
					Id = vacancy.Id,
					RecruiterId = vacancy.RecruiterId,
					Title = vacancy.Title,
					Info = vacancy.Info,
					Location = vacancy.Location,
					StartDate = vacancy.StartDate,
					EndDate = vacancy.EndDate,
					CompanyName = company.Name,
					CompanyId = company.Id
				};

			return vacancies.FirstOrDefault();
		}

		public IEnumerable<VacancyViewModel> GetVacanciesByCompanyId(int companyId, string searchString)
		{
			var vacancies = from vacancy in _context.Vacancies
				join recruiter in _context.Recruiters on vacancy.RecruiterId equals recruiter.Id
				join worker in _context.Workers on recruiter.WorkerId equals worker.Id
				join company in _context.Companies on worker.CompanyId equals company.Id
				where worker.CompanyId == companyId && vacancy.Title.Contains(searchString)
				select new VacancyViewModel
				{
					Id = vacancy.Id,
					RecruiterId = vacancy.RecruiterId,
					Title = vacancy.Title,
					Info = vacancy.Info,
					Location = vacancy.Location,
					StartDate = vacancy.StartDate,
					EndDate = vacancy.EndDate,
					CompanyName = company.Name,
					CompanyId = company.Id
				};

			return vacancies.OrderByDescending(x=>x.StartDate);
		}

		public IEnumerable<VacancyViewModel> GetVacanciesForApplicant(int applicantId, string searchString)
		{
			var vacancies = from vacancy in _context.Vacancies
				join interview in _context.Interviews.Where(x=> x.ApplicantId == applicantId) on vacancy.Id 
					equals interview.VacancyId into joined
				from interview in joined.DefaultIfEmpty()
				join recruiter in _context.Recruiters on vacancy.RecruiterId equals recruiter.Id
				join worker in _context.Workers on recruiter.WorkerId equals worker.Id
				join company in _context.Companies on worker.CompanyId equals company.Id
				where interview.VacancyId == null && vacancy.Title.Contains(searchString)
				select new VacancyViewModel
				{
					Id = vacancy.Id,
					RecruiterId = vacancy.RecruiterId,
					Title = vacancy.Title,
					Info = vacancy.Info,
					Location = vacancy.Location,
					StartDate = vacancy.StartDate,
					EndDate = vacancy.EndDate,
					CompanyName = company.Name,
					CompanyId = company.Id
				};

			return vacancies.OrderByDescending(x=>x.StartDate);
		}
	}
}