using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.BLL.Interfaces.Authorization;

namespace EnhanceInterview.BLL.Services.Authorization
{
	public class RoleService : IRoleService
	{
		private readonly IRoleServiceModelBuilder _roleServiceModelBuilder;

		public RoleService(IRoleServiceModelBuilder roleServiceModelBuilder)
		{
			_roleServiceModelBuilder = roleServiceModelBuilder;
		}

		public void CreateUserByRole(RegistrationModel model)
		{
			if (model.Role == Roles.APPLICANT)
			{
				_roleServiceModelBuilder.AddApplicantByUserModel(model);
			}
			else
			{
				_roleServiceModelBuilder.AddWorkerByUserModel(model);
			}
		}

		public LoginModel GetUserByRole(string userId, string role)
		{
			var userModel = role == Roles.APPLICANT ?
				_roleServiceModelBuilder.GetUserModelForApplicant(userId) :
				_roleServiceModelBuilder.GetUserModelForWorker(userId);

			return userModel;
		}
	}
}