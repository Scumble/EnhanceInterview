using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class CompanyDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public ICollection<WorkerDto> Workers { get; set; }

		public CompanyDto()
		{
			Workers = new List<WorkerDto>();
		}
	}
}