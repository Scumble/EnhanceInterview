namespace EnhanceInterview.BLL.DTO
{
	public class FeedbackDto
	{
		public int Id { get; set; }

		public int InterviewerId { get; set; }

		public InterviewerDto Interviewer { get; set; }

		public int InterviewId { get; set; }

		public InterviewDto Interview { get; set; }

		public string Content { get; set; }

		public int WorkerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Role { get; set; }

		public string VacancyTitle { get; set; }
	}
}