using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class FeedbackService : IFeedbackService
	{
		private readonly IFeedbackRepository _feedbackRepository;
		private readonly IMapper _mapper;
		public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
		{
			_feedbackRepository = feedbackRepository;
			_mapper = mapper;
		}

		public IEnumerable<FeedbackDto> GetApplicantFeedbacks(int interviewId)
		{
			return _mapper.Map<IEnumerable<FeedbackViewModel>, IEnumerable<FeedbackDto>>(
				_feedbackRepository.GetApplicantFeedbacks(interviewId));
		}

		public void AddFeedback(FeedbackDto feedbackDto)
		{
			_feedbackRepository.AddFeedback(_mapper.Map<FeedbackDto, Feedback>(feedbackDto));
		}

		public void UpdateFeedback(FeedbackDto feedbackDto)
		{
			_feedbackRepository.AddFeedback(_mapper.Map<FeedbackDto, Feedback>(feedbackDto));
		}

		public void DeleteFeedback(int feedbackId)
		{
			_feedbackRepository.DeleteFeedback(feedbackId);
		}
	}
}