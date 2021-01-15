namespace EnhanceInterview.BLL.DTO
{
	public class LoginModel : AuthorizationBaseModel
	{
		public int CompanyId { get; set; }

		public string Token { get; set; }
	}
}