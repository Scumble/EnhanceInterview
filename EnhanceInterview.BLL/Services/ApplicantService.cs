using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class ApplicantService : IApplicantService
	{
		private readonly IApplicantRepository _applicantRepository;
		private readonly IMapper _mapper;
		public ApplicantService(IApplicantRepository applicantRepository, IMapper mapper)
		{
			_applicantRepository = applicantRepository;
			_mapper = mapper;
		}

		public ApplicantDto GetApplicantByUserId(string userId)
		{
			return _mapper.Map<Applicant, ApplicantDto>(_applicantRepository.GetApplicantByUserId(userId));
		}

		public ApplicantDto GetApplicantById(int id)
		{
			return _mapper.Map<Applicant, ApplicantDto>(_applicantRepository.GetApplicantById(id));
		}

		public void AddApplicant(ApplicantDto applicantDto)
		{
			_applicantRepository.AddApplicant(_mapper.Map<ApplicantDto, Applicant>(applicantDto));
		}

		public void UpdateApplicant(ApplicantDto applicantDto)
		{
			_applicantRepository.UpdateApplicant(_mapper.Map<ApplicantDto, Applicant>(applicantDto));
		}
	}
}