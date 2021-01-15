using System;
using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class InterviewRepository : IInterviewRepository
	{
		private readonly DatabaseContext _context;

		public InterviewRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<InterviewViewModel> GetAppliedInterviews(int applicantId, string searchString, string status)
		{
			var interviews = from interview in _context.Interviews
				join vacancy in _context.Vacancies on interview.VacancyId equals vacancy.Id
				join recruiter in _context.Recruiters on vacancy.RecruiterId equals recruiter.Id
				join worker in _context.Workers on recruiter.WorkerId equals worker.Id
				where interview.ApplicantId == applicantId &&
					vacancy.Title.Contains(searchString) &&
					interview.Status.Contains(status)
				select new InterviewViewModel
				{
					Id = interview.Id,
					ApplicantId = interview.ApplicantId,
					VacancyId = vacancy.Id,
					VacancyTitle = vacancy.Title,
					ApplyDate = interview.ApplyDate,
					InterviewDate = interview.InterviewDate,
					RejectDate = interview.RejectDate,
					RejectReason = interview.RejectReason,
					InterviewRoom = interview.InterviewRoom,
					Status = interview.Status
				};

			return interviews.OrderByDescending(x=>x.ApplyDate);
		}

		public IEnumerable<InterviewViewModel> GetInterviewsByCompanyId(int companyId, string searchString, string status)
		{
			var interviews = from interview in _context.Interviews
				join vacancy in _context.Vacancies on interview.VacancyId equals vacancy.Id
				join recruiter in _context.Recruiters on vacancy.RecruiterId equals recruiter.Id
				join worker in _context.Workers on recruiter.WorkerId equals worker.Id
				where worker.CompanyId == companyId &&
					vacancy.Title.Contains(searchString) &&
					interview.Status.Contains(status)
				select new InterviewViewModel
				{
					Id = interview.Id,
					ApplicantId = interview.ApplicantId,
					VacancyId = vacancy.Id,
					VacancyTitle = vacancy.Title,
					ApplyDate = interview.ApplyDate,
					InterviewDate = interview.InterviewDate,
					RejectDate = interview.RejectDate,
					RejectReason = interview.RejectReason,
					InterviewRoom = interview.InterviewRoom,
					Status = interview.Status
				};

			return interviews.OrderByDescending(x=>x.ApplyDate);
		}

		public Interview AddInterview(Interview interview)
		{
			if (interview.Id == 0)
			{
				interview.ApplyDate = DateTime.Now;
				_context.Interviews.Add(interview);
			}
			else
			{
				var dbEntry = _context.Interviews.Find(interview.Id);
				if (dbEntry != null)
				{
					dbEntry.VacancyId = interview.VacancyId;
					dbEntry.ApplicantId = interview.ApplicantId;
					dbEntry.Status = interview.Status;
					dbEntry.ApplyDate = DateTime.Now;
					dbEntry.InterviewDate = interview.InterviewDate;
					dbEntry.RejectDate = DateTime.Now;
					dbEntry.RejectReason = interview.RejectReason;
					dbEntry.InterviewRoom = interview.InterviewRoom;
				}
			}

			_context.SaveChanges();
			return interview;
		}

		public Interview GetInterviewById(int interviewId)
		{
			return _context.Interviews.FirstOrDefault(x => x.Id == interviewId);
		}

		public Interview GetInterviewByVacancyId(int vacancyId)
		{
			return _context.Interviews.FirstOrDefault(x => x.VacancyId == vacancyId);
		}

		public Interview GetInterviewByApplicantId(int applicantId, int vacancyId)
		{
			return _context.Interviews.FirstOrDefault(x => x.ApplicantId == applicantId && x.VacancyId == vacancyId);
		}

		public void UpdateInterview(Interview interview)
		{
			_context.Entry(interview).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}