using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class VacancyQuestionService : IVacancyQuestionService
	{
		private readonly IVacancyQuestionRepository _vacancyQuestionRepository;
		private readonly IMapper _mapper;
		public VacancyQuestionService(
			IVacancyQuestionRepository vacancyQuestionRepository,
			IMapper mapper)
		{
			_vacancyQuestionRepository = vacancyQuestionRepository;
			_mapper = mapper;
		}

		public VacancyQuestionDto GetVacancyQuestionById(int? vacancyQuestionId)
		{
			return _mapper.Map<VacancyQuestion, VacancyQuestionDto>(
				_vacancyQuestionRepository.GetVacancyQuestionById(vacancyQuestionId));
		}

		public void AddVacancyQuestion(VacancyQuestionDto vacancyQuestionDto)
		{
			_vacancyQuestionRepository.AddVacancyQuestion(_mapper.Map<VacancyQuestionDto, VacancyQuestion>(vacancyQuestionDto));
		}

		public void UpdateVacancyQuestion(VacancyQuestionDto vacancyQuestionDto)
		{
			_vacancyQuestionRepository.UpdateVacancyQuestion(_mapper.Map<VacancyQuestionDto, VacancyQuestion>(vacancyQuestionDto));
		}

		public void DeleteVacancyQuestion(int questionId, int vacancyId)
		{
			_vacancyQuestionRepository.DeleteVacancyQuestion(questionId, vacancyId);
		}
	}
}