using System;
using System.Collections.Generic;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.DTO
{
	public class VacancyDto
	{
		public int Id { get; set; }

		public int? RecruiterId { get; set; }

		public RecruiterDto Recruiter { get; set; }

		public string Title { get; set; }

		public string Info { get; set; }

		public string Location { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string CompanyName { get; set; }

		public int CompanyId { get; set; }

		public InterviewDto Interview { get; set; }

		public ICollection<InterviewDto> Interviews { get; set; }

		public ICollection<VacancyQuestionDto> VacancyQuestions { get; set; }

		public VacancyDto()
		{
			VacancyQuestions = new List<VacancyQuestionDto>();
			Interviews = new List<InterviewDto>();
		}
	}
}