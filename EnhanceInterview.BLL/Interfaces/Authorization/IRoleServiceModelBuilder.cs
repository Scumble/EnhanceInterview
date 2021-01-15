using EnhanceInterview.BLL.DTO;

namespace EnhanceInterview.BLL.Interfaces.Authorization
{
	public interface IRoleServiceModelBuilder
	{
		void AddWorkerByUserModel(RegistrationModel registrationModel);

		void AddApplicantByUserModel(RegistrationModel registrationModel);

		LoginModel GetUserModelForWorker(string userId);

		LoginModel GetUserModelForApplicant(string userId);
	}
}