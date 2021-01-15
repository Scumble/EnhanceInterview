using Microsoft.AspNetCore.SignalR;

namespace EnhanceInterview.Providers
{
	public class CustomUserIdProvider : IUserIdProvider
	{
		public string GetUserId(HubConnectionContext connection)
		{
			return connection.User?.Identity.Name;
		}
	}
}