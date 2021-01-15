using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EnhanceInterview.DAL.Repositories
{
	public class ApplicantRepository : IApplicantRepository
	{
		private readonly DatabaseContext _context;

		public ApplicantRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Applicant GetApplicantByUserId(string userId)
		{
			return _context.Applicants.FirstOrDefault(x => x.UserId == userId);
		}

		public Applicant GetApplicantById(int id)
		{
			return _context.Applicants.FirstOrDefault(x => x.Id == id);
		}

		public void AddApplicant(Applicant applicant)
		{
			if (applicant.Id == 0)
			{
				_context.Applicants.Add(applicant);
			}
			else
			{
				var dbEntry = _context.Applicants.Find(applicant.Id);
				if (dbEntry != null)
				{
					dbEntry.FirstName = applicant.FirstName;
					dbEntry.LastName = applicant.LastName;
					dbEntry.UserId = applicant.UserId;
					dbEntry.Email = applicant.Email;
				}
			}

			_context.SaveChanges();
		}

		public void UpdateApplicant(Applicant applicant)
		{
			_context.Entry(applicant).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}