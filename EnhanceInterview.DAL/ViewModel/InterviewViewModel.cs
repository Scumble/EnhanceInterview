using System;

namespace EnhanceInterview.DAL.ViewModel
{
	public class InterviewViewModel
	{
		public int Id { get; set; }

		public int VacancyId { get; set; }

		public string VacancyTitle { get; set; }

		public int ApplicantId { get; set; }

		public string Status { get; set; }

		public DateTime ApplyDate { get; set; }

		public DateTime? InterviewDate { get; set; }

		public DateTime? RejectDate { get; set; }

		public string RejectReason { get; set; }

		public string InterviewRoom { get; set; }
	}
}