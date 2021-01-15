namespace EnhanceInterview.DAL.ViewModel
{
	public class FeedbackViewModel
	{
		public int Id { get; set; }

		public int InterviewerId { get; set; }

		public int InterviewId { get; set; }

		public int WorkerId { get; set; }

		public string Content { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Role { get; set; }

		public string VacancyTitle { get; set; }
	}
}