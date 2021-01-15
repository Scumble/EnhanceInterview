using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces.Authorization
{
	public interface IAccountService
	{
		LoginModel AuthenticateUser(string login, string password);

		void RegisterUser(RegistrationModel registration);
	}
}