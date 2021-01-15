using AutoMapper;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.BLL.Services
{
	public class WorkerService : IWorkerService
	{
		private readonly IWorkerRepository _workerRepository;
		private readonly IMapper _mapper;
		public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
		{
			_workerRepository = workerRepository;
			_mapper = mapper;
		}

		public WorkerDto GetWorkerById(int workerId)
		{
			return _mapper.Map<Worker, WorkerDto>(_workerRepository.GetWorkerById(workerId));
		}

		public WorkerDto GetWorkerByUserId(string userId)
		{
			return _mapper.Map<Worker, WorkerDto>(_workerRepository.GetWorkerByUserId(userId));
		}

		public WorkerDto AddWorker(WorkerDto workerDto)
		{
			return _mapper.Map<Worker, WorkerDto>(_workerRepository.AddWorker(_mapper.Map<WorkerDto, Worker>(workerDto)));
		}
	}
}