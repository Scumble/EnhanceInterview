using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Recruiter
	{
		public int Id { get; set; }

		public int WorkerId { get; set; }

		public Worker Worker { get; set; }

		public ICollection<Vacancy> Vacancies { get; set; }

		public Recruiter()
		{
			Vacancies = new List<Vacancy>();
		}
	}
}