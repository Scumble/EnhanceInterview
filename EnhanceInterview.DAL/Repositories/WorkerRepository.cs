using System.Linq;
using EnhanceInterview.DAL.Interfaces;
using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Repositories
{
	public class WorkerRepository : IWorkerRepository
	{
		private readonly DatabaseContext _context;

		public WorkerRepository(DatabaseContext context)
		{
			_context = context;
		}

		public Worker GetWorkerById(int workerId)
		{
			return _context.Workers.FirstOrDefault(x => x.Id == workerId);
		}

		public Worker GetWorkerByUserId(string userId)
		{
			return _context.Workers.FirstOrDefault(x => x.UserId == userId);
		}

		public Worker AddWorker(Worker worker)
		{
			if (worker.Id == 0)
			{
				_context.Workers.Add(worker);
			}
			else
			{
				var dbEntry = _context.Workers.Find(worker.Id);
				if (dbEntry != null)
				{
					dbEntry.FirstName = worker.FirstName;
					dbEntry.LastName = worker.LastName;
					dbEntry.UserId = worker.UserId;
					dbEntry.Email = worker.Email;
					dbEntry.CompanyId = worker.CompanyId;
				}
			}

			_context.SaveChanges();
			return worker;
		}
	}
}