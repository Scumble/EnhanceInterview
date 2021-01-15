using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Repositories
{
	public class InterviewerRepository : IInterviewerRepository
	{
		private readonly DatabaseContext _context;

		public InterviewerRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Interviewer GetInterviewerByWorkerId(int workerId)
		{
			return _context.Interviewers.FirstOrDefault(x=>x.WorkerId == workerId);
		}

		public void AddInterviewer(Interviewer interviewer)
		{
			if (interviewer.Id == 0)
			{
				_context.Interviewers.Add(interviewer);
			}
			else
			{
				var dbEntry = _context.Interviewers.Find(interviewer.Id);
				if (dbEntry != null)
				{
					dbEntry.WorkerId = interviewer.WorkerId;
				}
			}

			_context.SaveChanges();
		}
	}
}