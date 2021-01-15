using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Repositories
{
	public class RecruiterRepository : IRecruiterRepository
	{
		private readonly DatabaseContext _context;

		public RecruiterRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Recruiter GetRecruiterByUserId(string userId)
		{
			var recruiter = from recruiters in _context.Recruiters
				join worker in _context.Workers on recruiters.WorkerId equals worker.Id
				where worker.UserId == userId 
				select recruiters;

			return recruiter.FirstOrDefault();
		}

		public Recruiter GetRecruiterById(int? recruiterId)
		{
			return _context.Recruiters.FirstOrDefault(x=> x.Id == recruiterId);
		}

		public void AddRecruiter(Recruiter recruiter)
		{
			if (recruiter.Id == 0)
			{
				_context.Recruiters.Add(recruiter);
			}
			else
			{
				var dbEntry = _context.Recruiters.Find(recruiter.Id);
				if (dbEntry != null)
				{
					dbEntry.WorkerId = recruiter.WorkerId;
				}
			}

			_context.SaveChanges();
		}
	}
}