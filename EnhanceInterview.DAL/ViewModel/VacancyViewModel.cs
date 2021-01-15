using System;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.ViewModel
{
	public class VacancyViewModel
	{
		public int Id { get; set; }

		public int? RecruiterId { get; set; }

		public string Title { get; set; }

		public string Info { get; set; }

		public string Location { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string CompanyName { get; set; }

		public int CompanyId { get; set; }
	}
}