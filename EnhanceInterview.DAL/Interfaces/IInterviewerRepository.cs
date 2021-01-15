using EnhanceInterview.DAL.Models;

namespace EnhanceInterview.DAL.Interfaces
{
	public interface IInterviewerRepository
	{
		Interviewer GetInterviewerByWorkerId(int workerId);

		void AddInterviewer(Interviewer interviewer);
	}
}