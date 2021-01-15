using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class RecruiterService : IRecruiterService
	{
		private readonly IRecruiterRepository _recruiterRepository;
		private readonly IMapper _mapper;
		public RecruiterService(IRecruiterRepository recruiterRepository, IMapper mapper)
		{
			_recruiterRepository = recruiterRepository;
			_mapper = mapper;
		}

		public RecruiterDto GetRecruiterByUserId(string userId)
		{
			return _mapper.Map<Recruiter, RecruiterDto>(_recruiterRepository.GetRecruiterByUserId(userId));
		}

		public RecruiterDto GetRecruiterById(int? recruiterId)
		{
			return _mapper.Map<Recruiter, RecruiterDto>(_recruiterRepository.GetRecruiterById(recruiterId));
		}

		public void AddRecruiter(RecruiterDto recruiterDto)
		{
			_recruiterRepository.AddRecruiter(_mapper.Map<RecruiterDto, Recruiter>(recruiterDto));
		}
	}
}