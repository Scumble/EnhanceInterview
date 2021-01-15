using EnhanceInterview.BLL.Constants;
using EnhanceInterview.BLL.DTO;
using EnhanceInterview.BLL.Interfaces;
using EnhanceInterview.BLL.Interfaces.Authorization;

namespace EnhanceInterview.BLL.Services.Authorization
{
	public class RoleServiceModelBuilder : IRoleServiceModelBuilder
	{
		private readonly IWorkerService _workerService;
		private readonly IApplicantService _applicantService;
		private readonly ICompanyService _companyService;
		private readonly IRecruiterService _recruiterService;
		private readonly IInterviewerService _interviewerService;

		public RoleServiceModelBuilder(
			IWorkerService workerService,
			IApplicantService applicantService,
			ICompanyService companyService,
			IRecruiterService recruiterService,
			IInterviewerService interviewerService)
		{
			_workerService = workerService;
			_applicantService = applicantService;
			_companyService = companyService;
			_recruiterService = recruiterService;
			_interviewerService = interviewerService;
		}

		public void AddWorkerByUserModel(RegistrationModel registrationModel)
		{
			var company = _companyService.GetCompanyByName(registrationModel.CompanyName);

			var workerDto = new WorkerDto
			{
				FirstName = registrationModel.FirstName,
				LastName = registrationModel.LastName,
				Email = registrationModel.Email,
				UserId = registrationModel.UserId,
				CompanyId = company.Id
			};

			var createdWorker = _workerService.AddWorker(workerDto);
			AssignWorkersToRoles(createdWorker.Id, registrationModel.Role);
		}

		public void AddApplicantByUserModel(RegistrationModel registrationModel)
		{
			var applicantDto = new ApplicantDto
			{
				FirstName = registrationModel.FirstName,
				LastName = registrationModel.LastName,
				Email = registrationModel.Email,
				UserId = registrationModel.UserId,
			};

			_applicantService.AddApplicant(applicantDto);
		}

		public LoginModel GetUserModelForWorker(string userId)
		{
			var worker = _workerService.GetWorkerByUserId(userId);
			var userModel = new LoginModel
			{
				UserId = userId, 
				FirstName = worker.FirstName, 
				LastName = worker.LastName,
				Email = worker.Email,
				CompanyId = worker.CompanyId
			};

			return userModel;
		}

		public LoginModel GetUserModelForApplicant(string userId)
		{
			var applicant = _applicantService.GetApplicantByUserId(userId);
			var userModel = new LoginModel
			{
				UserId = userId, 
				FirstName = applicant.FirstName, 
				LastName = applicant.LastName,
				Email = applicant.Email
			};

			return userModel;
		}

		private void AssignWorkersToRoles(int workerId, string role)
		{
			if (role == Roles.RECRUITER)
			{
				_recruiterService.AddRecruiter(new RecruiterDto
				{
					WorkerId = workerId
				});
			}
			else
			{
				_interviewerService.AddInterviewer(new InterviewerDto
				{
					WorkerId = workerId
				});
			}
		}
	}
}