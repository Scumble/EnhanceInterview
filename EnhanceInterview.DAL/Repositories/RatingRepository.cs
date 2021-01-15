using System.Collections.Generic;
using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.DAL.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly DatabaseContext _context;

		public RatingRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<RatingViewModel> GetInterviewRatings()
		{
			var rating = from answer in _context.Answers
				join vacancyQuestion in _context.VacancyQuestions on answer.VacancyQuestionId equals vacancyQuestion.Id
				join question in _context.Questions on vacancyQuestion.QuestionId equals question.Id
				select new RatingViewModel
				{
					EstimationSum = answer.Estimation,
					InterviewId = answer.InterviewId,
					VacancyId = vacancyQuestion.VacancyId
				};

			return rating.GroupBy(x => new {x.InterviewId, x.VacancyId})
				.Select(y => new RatingViewModel
				{
					VacancyId = y.Key.VacancyId,
					InterviewId = y.Key.InterviewId,
					EstimationSum = y.Sum(x => x.EstimationSum)
				});
		}

		public IEnumerable<VacancyRatingViewModel> GetVacancyRating(int vacancyId)
		{
			var rating = from answer in _context.Answers
				join interview in _context.Interviews on answer.InterviewId equals interview.Id
				join vacancyQuestion in _context.VacancyQuestions on answer.VacancyQuestionId equals vacancyQuestion.Id
				join question in _context.Questions on vacancyQuestion.QuestionId equals question.Id
				select new VacancyRatingViewModel
				{
					InterviewId = interview.Id,
					VacancyId = interview.VacancyId,
					ApplicantId = interview.ApplicantId,
					Category = question.Category,
					Estimation = answer.Estimation
				};

			return rating.GroupBy(x => new {x.Category, x.InterviewId, x.ApplicantId, x.VacancyId})
				.Select(y => new VacancyRatingViewModel
				{
					Category = y.Key.Category,
					ApplicantId = y.Key.ApplicantId,
					VacancyId = y.Key.VacancyId,
					InterviewId = y.Key.InterviewId,
					Estimation = y.Average(x => x.Estimation)
				}).Where(x=>x.VacancyId == vacancyId);
		}
	}
}