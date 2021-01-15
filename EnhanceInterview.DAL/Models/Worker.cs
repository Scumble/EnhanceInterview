using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Worker
	{
		public int Id { get; set; }

		public int? CompanyId { get; set; }

		public Company Company { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public ICollection<Interviewer> Interviewers { get; set; }

		public ICollection<Recruiter> Recruiters { get; set; }

		public Worker()
		{
			Recruiters = new List<Recruiter>();
			Interviewers = new List<Interviewer>();
		}
	}
}