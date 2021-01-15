using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class VacancyQuestion
	{
		public int Id { get; set; }

		public int QuestionId { get; set; }

		public Question Question { get; set; }

		public int VacancyId { get; set; }

		public Vacancy Vacancy { get; set; }

		public ICollection<Answer> Answers { get; set; }

		public VacancyQuestion()
		{
			Answers = new List<Answer>();
		}
	}
}