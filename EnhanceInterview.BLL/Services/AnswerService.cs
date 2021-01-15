using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class AnswerService : IAnswerService
	{
		private readonly IAnswerRepository _answerRepository;
		private readonly IVacancyQuestionService _vacancyQuestionService;
		private readonly IQuestionService _questionService;
		private readonly IMapper _mapper;

		public AnswerService(
			IAnswerRepository answerRepository,
			IVacancyQuestionService vacancyQuestionService,
			IQuestionService questionService,
			IMapper mapper)
		{
			_answerRepository = answerRepository;
			_vacancyQuestionService = vacancyQuestionService;
			_questionService = questionService;
			_mapper = mapper;
		}

		public IEnumerable<AnswerDto> GetInterviewResultsByInterviewId(int interviewId, string searchString, string category)
		{
			return _mapper.Map<IEnumerable<AnswerViewModel>, IEnumerable<AnswerDto>>(_answerRepository.GetInterviewResultsByInterviewId(interviewId, searchString, category));
		}

		public AnswerDto AddAnswer(AnswerDto answerDto)
		{
			var questionId = _vacancyQuestionService.GetVacancyQuestionById(answerDto.VacancyQuestionId).QuestionId;
			var questionDto = _questionService.GetQuestionById(questionId);
			answerDto.Estimation *= questionDto.Complexity;
			return _mapper.Map<Answer, AnswerDto>(_answerRepository.AddAnswer(_mapper.Map<AnswerDto, Answer>(answerDto)));
		}

		public void UpdateAnswer(AnswerDto answerDto)
		{
			_answerRepository.UpdateAnswer(_mapper.Map<AnswerDto, Answer>(answerDto));
		}

		public void DeleteAnswer(int answerId)
		{
			_answerRepository.DeleteAnswer(answerId);
		}
	}
}