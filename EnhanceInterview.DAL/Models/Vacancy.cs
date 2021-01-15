using System;
using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Vacancy
	{
		public int Id { get; set; }

		public int? RecruiterId { get; set; }

		public Recruiter Recruiter { get; set; }

		public string Title { get; set; }

		public string Info { get; set; }

		public string Location { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public ICollection<Interview> Interviews { get; set; }
		public ICollection<VacancyQuestion> VacancyQuestions { get; set; }

		public Vacancy()
		{
			VacancyQuestions = new List<VacancyQuestion>();
			Interviews = new List<Interview>();
		}
	}
}