namespace EnhanceInterview.DAL.Models
{
	public class Feedback
	{
		public int Id { get; set; }

		public int InterviewerId { get; set; }

		public Interviewer Interviewer { get; set; }

		public int InterviewId { get; set; }

		public Interview Interview { get; set; }

		public string Content { get; set; }
	}
}