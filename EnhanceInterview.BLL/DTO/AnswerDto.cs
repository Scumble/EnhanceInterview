namespace EnhanceInterview.BLL.DTO
{
	public class AnswerDto
	{
		public int Id { get; set; }

		public int InterviewId { get; set; }

		public InterviewDto Interview { get; set; }

		public int? VacancyQuestionId { get; set; }

		public int Estimation { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public int Complexity { get; set; }

		public string Content { get; set; }

		public int QuestionId { get; set; }

		public VacancyQuestionDto VacancyQuestion { get; set; }
	}
}