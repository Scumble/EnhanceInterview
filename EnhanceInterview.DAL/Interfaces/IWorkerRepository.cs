using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IWorkerRepository
	{
		Worker GetWorkerById(int workerId);

		Worker AddWorker(Worker worker);

		Worker GetWorkerByUserId(string userId);
	}
}