using System.Collections.Generic;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IRatingService
	{
		IEnumerable<VacancyRatingDto> GetVacancyRating(int vacancyId);

		IEnumerable<RatingDto> GetInterviewRatings(int applicantId);
	}
}