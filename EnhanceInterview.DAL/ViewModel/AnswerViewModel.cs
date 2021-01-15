namespace EnhanceInterview.DAL.ViewModel
{
	public class AnswerViewModel
	{
		public int Id { get; set; }

		public int QuestionId { get; set; }

		public int InterviewId { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public int Complexity { get; set; }

		public string Content { get; set; }

		public int Estimation { get; set; }
	}
}