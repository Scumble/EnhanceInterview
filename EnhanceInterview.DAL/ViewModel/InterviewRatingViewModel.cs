namespace EnhanceInterview.DAL.ViewModel
{
	public class VacancyRatingViewModel
	{
		public int InterviewId { get; set; }

		public int VacancyId { get; set; }

		public string Category { get; set; }

		public double Estimation { get; set; }

		public int ApplicantId { get; set; }
	}
}