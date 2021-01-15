using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Company
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public ICollection<Worker> Workers { get; set; }

		public Company()
		{
			Workers = new List<Worker>();
		}
	}
}