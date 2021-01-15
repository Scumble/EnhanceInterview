namespace EnhanceInterview.BLL.DTO
{
	public class VacancyRatingDto
	{
		public int InterviewId { get; set; }

		public int VacancyId { get; set; }

		public string Category { get; set; }

		public double Estimation { get; set; }

		public int ApplicantId { get; set; }

		public string ApplicantName { get; set; }

		public double EstimationSum { get; set; }
	}
}