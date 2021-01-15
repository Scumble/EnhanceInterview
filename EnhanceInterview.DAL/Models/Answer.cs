namespace EnhanceInterview.DAL.Models
{
	public class Answer
	{
		public int Id { get; set; }

		public int InterviewId { get; set; }

		public Interview Interview { get; set; }

		public int? VacancyQuestionId { get; set; }

		public int Estimation { get; set; }

		public VacancyQuestion VacancyQuestion { get; set; }
	}
}