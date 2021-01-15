using System;
using System.Collections.Generic;

namespace EnhanceInterview.DAL.Models
{
	public class Applicant
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Information { get; set; }

		public string Skills { get; set; }

		public string Education { get; set; }

		public string Experience { get; set; }

		public string ProfileImgPath { get; set; }

		public DateTime BirthDate { get; set; }

		public ICollection<Interview> Interviews { get; set; }
		public Applicant()
		{
			Interviews = new List<Interview>();
		}
	}
}