using System.Collections.Generic;

namespace EnhanceInterview.BLL.DTO
{
	public class InterviewerDto
	{
		public int Id { get; set; }

		public int WorkerId { get; set; }

		public WorkerDto Worker { get; set; }

		public ICollection<FeedbackDto> Feedbacks { get; set; }

		public InterviewerDto()
		{
			Feedbacks = new List<FeedbackDto>();
		}
	}
}