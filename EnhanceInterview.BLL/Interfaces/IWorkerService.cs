using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IWorkerService
	{
		WorkerDto GetWorkerById(int workerId);

		WorkerDto AddWorker(WorkerDto interviewerDto);

		WorkerDto GetWorkerByUserId(string userId);
	}
}