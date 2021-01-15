using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;
using EnhanceInterview.DAL.ViewModel;

namespace EnhanceInterview.BLL.Services
{
	public class VacancyService : IVacancyService
	{
		private readonly IVacancyRepository _vacancyRepository;
		private readonly IInterviewService _interviewService;
		private readonly IMapper _mapper;

		public VacancyService(IVacancyRepository vacancyRepository, IInterviewService interviewService, IMapper mapper)
		{
			_vacancyRepository = vacancyRepository;
			_interviewService = interviewService;
			_mapper = mapper;
		}

		public void AddVacancy(VacancyDto vacancyDto)
		{
			_vacancyRepository.AddVacancy(_mapper.Map<VacancyDto, Vacancy>(vacancyDto));
		}

		public void UpdateVacancy(VacancyDto vacancyDto)
		{
			_vacancyRepository.AddVacancy(_mapper.Map<VacancyDto, Vacancy>(vacancyDto));
		}

		public void DeleteVacancy(int vacancyId)
		{
			_vacancyRepository.DeleteVacancy(vacancyId);
		}

		public VacancyDto GetVacancyById(int vacancyId)
		{
			return _mapper.Map<VacancyViewModel, VacancyDto>(
				_vacancyRepository.GetVacancyById(vacancyId));
		}

		public IEnumerable<VacancyDto> GetVacanciesByCompanyId(int companyId, string searchString)
		{
			var vacancies =  _mapper.Map<IEnumerable<VacancyViewModel>, IEnumerable<VacancyDto>>(
				_vacancyRepository.GetVacanciesByCompanyId(companyId, searchString)).ToList();

			foreach (var vacancy in vacancies)
			{
				vacancy.Interview = _interviewService.GetInterviewByVacancyId(vacancy.Id);
			}

			return vacancies;
		}

		public IEnumerable<VacancyDto> GetVacanciesForApplicant(int applicantId, string searchString)
		{
			return _mapper.Map<IEnumerable<VacancyViewModel>, IEnumerable<VacancyDto>>(
				_vacancyRepository.GetVacanciesForApplicant(applicantId, searchString));
		}
	}
}