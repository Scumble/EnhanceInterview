using System.Collections.Generic;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IRatingRepository
	{
		IEnumerable<VacancyRatingViewModel> GetVacancyRating(int vacancyId);

		IEnumerable<RatingViewModel> GetInterviewRatings();
	}
}