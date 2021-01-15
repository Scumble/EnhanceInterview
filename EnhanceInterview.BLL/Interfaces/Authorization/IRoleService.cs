using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces.Authorization
{
	public interface IRoleService
	{
		void CreateUserByRole(RegistrationModel model);

		LoginModel GetUserByRole(string userId, string role);
	}
}