using System.Threading.Tasks;
using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class InterviewerService : IInterviewerService
	{
		private readonly IInterviewerRepository _interviewerRepository;
		private readonly IWorkerService _workerService;
		private readonly IMapper _mapper;

		public InterviewerService(IInterviewerRepository interviewerRepository, IWorkerService workerService, IMapper mapper)
		{
			_interviewerRepository = interviewerRepository;
			_workerService = workerService;
			_mapper = mapper;
		}

		public InterviewerDtoViewModel GetInterviewerByUserId(string userId)
		{
			var worker = _workerService.GetWorkerByUserId(userId);
			return _mapper.Map<Interviewer, InterviewerDtoViewModel>(_interviewerRepository.GetInterviewerByWorkerId(worker.Id));
		}

		public void AddInterviewer(InterviewerDto interviewerDto)
		{
			_interviewerRepository.AddInterviewer(_mapper.Map<InterviewerDto, Interviewer>(interviewerDto));
		}
	}
}