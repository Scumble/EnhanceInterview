using System;
using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class InterviewDto
	{
		public int Id { get; set; }

		public int VacancyId { get; set; }

		public string VacancyTitle { get; set; }

		public VacancyDto Vacancy { get; set; }

		public int ApplicantId { get; set; }

		public string Status { get; set; }

		public DateTime ApplyDate { get; set; }

		public DateTime? InterviewDate { get; set; }

		public ApplicantDto Applicant { get; set; }

		public DateTime? RejectDate { get; set; }

		public string RejectReason { get; set; }

		public string InterviewRoom { get; set; }

		public ICollection<AnswerDto> Answers { get; set; }

		public ICollection<FeedbackDto> Feedbacks { get; set; }

		public InterviewDto()
		{
			Feedbacks = new List<FeedbackDto>();
			Answers = new List<AnswerDto>();
		}
	}
}