using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class VacancyQuestionDto
	{
		public int Id { get; set; }

		public int QuestionId { get; set; }

		public QuestionDto Question { get; set; }

		public int VacancyId { get; set; }

		public VacancyDto Vacancy { get; set; }

		public ICollection<AnswerDto> Answers { get; set; }

		public VacancyQuestionDto()
		{
			Answers = new List<AnswerDto>();
		}
	}
}