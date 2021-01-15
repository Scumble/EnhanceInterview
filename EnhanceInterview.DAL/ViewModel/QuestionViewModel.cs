namespace EnhanceInterview.DAL.ViewModel
{
	public class QuestionViewModel
	{
		public int Id { get; set; }

		public int VacancyId { get; set; }

		public int VacancyQuestionId { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public int Complexity { get; set; }

		public string Content { get; set; }
	}
}