using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class WorkerDto
	{
		public int Id { get; set; }

		public int CompanyId { get; set; }

		public CompanyDto Company { get; set; }

		public string UserId { get; set; }

		public UserDto User { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public ICollection<InterviewerDto> Interviewers { get; set; }

		public ICollection<RecruiterDto> Recruiters { get; set; }

		public WorkerDto()
		{
			Recruiters = new List<RecruiterDto>();
			Interviewers = new List<InterviewerDto>();
		}
	}
}