using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class InterviewService : IInterviewService
	{
		private readonly IInterviewRepository _interviewRepository;
		private readonly IMapper _mapper;

		public InterviewService(IInterviewRepository interviewRepository, IMapper mapper)
		{
			_interviewRepository = interviewRepository;
			_mapper = mapper;
		}

		public IEnumerable<InterviewDto> GetInterviewsByCompanyId(int companyId, string searchString, string status)
		{
			return _mapper.Map<IEnumerable<InterviewViewModel>, IEnumerable<InterviewDto>>(
				_interviewRepository.GetInterviewsByCompanyId(companyId, searchString, status));
		}

		public IEnumerable<InterviewDto> GetAppliedInterviews(int applicantId, string searchString, string status)
		{
			return _mapper.Map<IEnumerable<InterviewViewModel>, IEnumerable<InterviewDto>>(
				_interviewRepository.GetAppliedInterviews(applicantId, searchString, status));
		}

		public InterviewDto AddInterview(InterviewDto interviewDto)
		{
			return _mapper.Map<Interview, InterviewDto>(_interviewRepository.AddInterview(
				_mapper.Map<InterviewDto, Interview>(interviewDto)));
		}

		public void UpdateInterview(InterviewDto interviewDto)
		{
			_interviewRepository.UpdateInterview(_mapper.Map<InterviewDto, Interview>(interviewDto));
		}

		public InterviewDto GetInterviewById(int interviewId)
		{
			return _mapper.Map<Interview, InterviewDto>(_interviewRepository.GetInterviewById(interviewId));
		}

		public InterviewDto GetInterviewByVacancyId(int vacancyId)
		{
			return _mapper.Map<Interview, InterviewDto>(_interviewRepository.GetInterviewByVacancyId(vacancyId));
		}

		public InterviewDto GetInterviewByApplicantId(int applicantId, int vacancyId)
		{
			return _mapper.Map<Interview, InterviewDto>(_interviewRepository.GetInterviewByApplicantId(applicantId, vacancyId));
		}
	}
}