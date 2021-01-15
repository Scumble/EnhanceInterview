using System.Collections.Generic;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IQuestionRepository _questionRepository;
		private readonly IVacancyQuestionService _vacancyQuestionService;
		private readonly IMapper _mapper;
		public QuestionService(
			IQuestionRepository questionRepository,
			IVacancyQuestionService vacancyQuestionService,
			IMapper mapper)
		{
			_questionRepository = questionRepository;
			_vacancyQuestionService = vacancyQuestionService;
			_mapper = mapper;
		}

		public IEnumerable<QuestionDto> GetQuestionsByVacancyId(int vacancyId, string category, string searchString)
		{
			return _mapper.Map<IEnumerable<QuestionViewModel>, IEnumerable<QuestionDto>>(_questionRepository.GetQuestionsByVacancyId(vacancyId, category, searchString));
		}

		public QuestionDto GetQuestionById(int questionId)
		{
			return _mapper.Map<QuestionViewModel, QuestionDto>(
				_questionRepository.GetQuestionById(questionId));
		}

		public void AddQuestion(QuestionDto questionDto, int vacancyId)
		{
			var question = _mapper.Map<Question, QuestionDto>(_questionRepository.AddQuestion(_mapper.Map<QuestionDto, Question>(questionDto)));
			_vacancyQuestionService.AddVacancyQuestion(new VacancyQuestionDto
			{
				VacancyId = vacancyId,
				QuestionId = question.Id
			});
		}

		public void UpdateQuestion(QuestionDto questionDto)
		{
			_questionRepository.UpdateQuestion(_mapper.Map<QuestionDto, Question>(questionDto));
		}

		public void DeleteQuestion(int questionId, int vacancyId)
		{
			_questionRepository.DeleteQuestion(questionId);
			_vacancyQuestionService.DeleteVacancyQuestion(questionId, vacancyId);
		}
	}
}