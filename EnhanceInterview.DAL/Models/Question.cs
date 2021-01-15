using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Question
	{
		public int Id { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public int Complexity { get; set; }

		public string Content { get; set; }

		public ICollection<VacancyQuestion> VacancyQuestions { get; set; }
		public Question()
		{
			VacancyQuestions = new List<VacancyQuestion>();
		}
	}
}