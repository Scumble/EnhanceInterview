using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces
{
	public interface IRecruiterService
	{
		RecruiterDto GetRecruiterByUserId(string userId);

		RecruiterDto GetRecruiterById(int? recruiterId);

		void AddRecruiter(RecruiterDto recruiterDto);
	}
}