using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class QuestionDto
	{
		public int Id { get; set; }

		public string Category { get; set; }

		public string Type { get; set; }

		public int Complexity { get; set; }

		public string Content { get; set; }

		public int VacancyId { get; set; }

		public int VacancyQuestionId { get; set; }

		public ICollection<VacancyQuestionDto> VacancyQuestions { get; set; }
		public QuestionDto()
		{
			VacancyQuestions = new List<VacancyQuestionDto>();
		}
	}
}