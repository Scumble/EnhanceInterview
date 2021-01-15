using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class User
	{
		public string UserId { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public ICollection<Worker> Workers { get; set; }

		public ICollection<Applicant> Applicants { get; set; }

		public User()
		{
			Applicants = new List<Applicant>();
			Workers = new List<Worker>();
		}
	}
}