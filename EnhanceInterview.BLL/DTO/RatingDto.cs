namespace EnhanceInterview.BLL.DTO
{
	public class RatingDto
	{
		public int InterviewId { get; set; }

		public int VacancyId { get; set; }

		public int ApplicantId { get; set; }

		public string VacancyName { get; set; }

		public string CompanyName { get; set; }

		public int EstimationSum { get; set; }
	}
}