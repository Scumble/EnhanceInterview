using System.Threading.Tasks;
using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IInterviewerService
	{
		InterviewerDtoViewModel GetInterviewerByUserId(string userId);

		void AddInterviewer(InterviewerDto interviewerDto);
	}
}