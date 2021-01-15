using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class RatingService : IRatingService
	{
		private const double TECHNICAL_COEFFICIENT = 0.5;
		private const double PSYCHOLOGICAL_COEFFICIENT = 0.25;
		private const double HR_COEFFICIENT = 0.25;

		private readonly IRatingRepository _ratingRepository;
		private readonly IVacancyService _vacancyService;
		private readonly IInterviewService _interviewService;
		private readonly IApplicantService _applicantService;
		private readonly IMapper _mapper;
		public RatingService(
			IRatingRepository ratingRepository,
			IVacancyService vacancyService,
			IInterviewService interviewService,
			IApplicantService applicantService,
			IMapper mapper)
		{
			_ratingRepository = ratingRepository;
			_vacancyService = vacancyService;
			_interviewService = interviewService;
			_applicantService = applicantService;
			_mapper = mapper;
		}

		public IEnumerable<RatingDto> GetInterviewRatings(int applicantId)
		{
			var ratings = _mapper.Map<IEnumerable<RatingViewModel>, IEnumerable<RatingDto>>(_ratingRepository.GetInterviewRatings());
			var interviewRatings = ratings.ToList();

			foreach (var rating in interviewRatings)
			{
				var vacancy =  _vacancyService.GetVacancyById(rating.VacancyId);
				var interview = _interviewService.GetInterviewById(rating.InterviewId);

				rating.CompanyName = vacancy.CompanyName;
				rating.VacancyName = vacancy.Title;
				rating.ApplicantId = interview.ApplicantId;
			}

			return interviewRatings.Where(x => x.ApplicantId == applicantId).OrderByDescending(x => x.EstimationSum);
		}

		public IEnumerable<VacancyRatingDto> GetVacancyRating(int vacancyId)
		{
			var normalizedSet = NormalizeRatingSet(vacancyId);

			var resultSetList = GetResultSet(normalizedSet).ToList();
			foreach (var result in resultSetList)
			{
				var applicant = _applicantService.GetApplicantById(result.ApplicantId);
				result.ApplicantName = $"{applicant.FirstName} {applicant.LastName}";
			}

			return resultSetList;
		}

		private IOrderedEnumerable<VacancyRatingDto> GetResultSet(IEnumerable<VacancyRatingDto> normalizedSet)
		{
			return MultiplySetByCoefficient(normalizedSet).GroupBy(x => new
			{
				x.InterviewId,
				x.VacancyId,
				x.ApplicantId
			}).Select(
				y => new VacancyRatingDto
				{
					InterviewId = y.Key.InterviewId,
					VacancyId = y.Key.VacancyId,
					ApplicantId = y.Key.ApplicantId,
					EstimationSum = y.Sum(x => x.Estimation)
				}).OrderByDescending(x => x.EstimationSum);
		}

		private IEnumerable<VacancyRatingDto> NormalizeRatingSet(int vacancyId)
		{
			var ratingSet = _mapper.Map<IEnumerable<VacancyRatingViewModel>, IEnumerable<VacancyRatingDto>>(
				_ratingRepository.GetVacancyRating(vacancyId));

			var vacancyRatingDtos = ratingSet.ToList();

			var maxTechnicalEstimation = vacancyRatingDtos
				.Where(x => x.Category == "Technical")
				.Average(x => x.Estimation);

			var maxPsychologicalEstimation = vacancyRatingDtos
				.Where(x => x.Category == "Psychological")
				.Average(x => x.Estimation);

			var maxHrEstimation = vacancyRatingDtos
				.Where(x => x.Category == "HR")
				.Average(x => x.Estimation);

			foreach (var rating in vacancyRatingDtos)
			{
				switch (rating.Category)
				{
					case "Technical":
						rating.Estimation /= maxTechnicalEstimation;
						break;
					case "Psychological":
						rating.Estimation /= maxPsychologicalEstimation;
						break;
					case "HR":
						rating.Estimation /= maxHrEstimation;
						break;
				}
			}

			return vacancyRatingDtos;
		}

		private IEnumerable<VacancyRatingDto> MultiplySetByCoefficient(IEnumerable<VacancyRatingDto> vacancyRatingDtos)
		{
			var ratingDtos = vacancyRatingDtos.ToList();
			foreach (var vacancyRating in ratingDtos)
			{
				switch (vacancyRating.Category)
				{
					case "Technical":
						vacancyRating.Estimation *= TECHNICAL_COEFFICIENT;
						break;
					case "Psychological":
						vacancyRating.Estimation *= PSYCHOLOGICAL_COEFFICIENT;
						break;
					case "HR":
						vacancyRating.Estimation *= HR_COEFFICIENT;
						break;
				}
			}

			return ratingDtos;
		}
	}
}