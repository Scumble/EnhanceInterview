using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.MapperConfig
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<Company, CompanyDto>();
			CreateMap<User, UserDto>();
			CreateMap<Applicant, ApplicantDto>();
			CreateMap<Interviewer, InterviewerDto>();
			CreateMap<Recruiter, RecruiterDto>();
			CreateMap<Worker, InterviewDto>();
			CreateMap<Vacancy, VacancyDto>();
			CreateMap<VacancyViewModel, VacancyDto>();
			CreateMap<InterviewViewModel, InterviewDto>();
			CreateMap<Question, QuestionDto>();
			CreateMap<Answer, AnswerDto>();
			CreateMap<AnswerViewModel, AnswerDto>();
			CreateMap<QuestionViewModel, QuestionDto>();
			CreateMap<RatingViewModel, RatingDto>();
			CreateMap<Interviewer, InterviewerDtoViewModel>();
			CreateMap<FeedbackViewModel, FeedbackDto>();
			CreateMap<VacancyRatingViewModel, VacancyRatingDto>();
		}
	}
}