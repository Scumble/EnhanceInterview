using System;
using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Interview
	{
		public int Id { get; set; }

		public int VacancyId { get; set; }

		public Vacancy Vacancy { get; set; }

		public int ApplicantId { get; set; }

		public Applicant Applicant { get; set; }

		public string Status { get; set; }

		public DateTime ApplyDate { get; set; }

		public DateTime? InterviewDate { get; set; }

		public DateTime? RejectDate { get; set; }

		public string RejectReason { get; set; }

		public string InterviewRoom { get; set; }

		public ICollection<Answer> Answers { get; set; }
		public ICollection<Feedback> Feedbacks { get; set; }
		public Interview()
		{
			Feedbacks = new List<Feedback>();
			Answers = new List<Answer>();
		}
	}
}