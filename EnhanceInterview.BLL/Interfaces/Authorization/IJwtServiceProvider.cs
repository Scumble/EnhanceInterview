namespace EnhanceInterview.BLL.Interfaces.Authorization
{
	public interface IJwtServiceProvider
	{
		string GenerateJwtToken(string userId, string role);
	}
}