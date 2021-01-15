using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Interviewer
	{
		public int Id { get; set; }

		public int WorkerId { get; set; }

		public Worker Worker { get; set; }

		public ICollection<Feedback> Feedbacks { get; set; }

		public Interviewer()
		{
			Feedbacks = new List<Feedback>();
		}
	}
}