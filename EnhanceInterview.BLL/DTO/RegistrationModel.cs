namespace EnhanceInterview.BLL.DTO
{
	public class RegistrationModel : AuthorizationBaseModel
	{
		public string Password { get; set; }

		public string CompanyName { get; set; }
	}
}