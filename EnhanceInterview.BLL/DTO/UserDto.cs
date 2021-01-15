using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class UserDto
	{
		public string UserId { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public ICollection<WorkerDto> Workers { get; set; }

		public ICollection<ApplicantDto> Applicants { get; set; }

		public UserDto()
		{
			Applicants = new List<ApplicantDto>();
			Workers = new List<WorkerDto>();
		}
	}
}