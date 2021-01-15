using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class RecruiterDto
	{
		public int Id { get; set; }

		public int WorkerId { get; set; }

		public WorkerDto Worker { get; set; }

		public ICollection<VacancyDto> Vacancies { get; set; }

		public RecruiterDto()
		{
			Vacancies = new List<VacancyDto>();
		}
	}
}