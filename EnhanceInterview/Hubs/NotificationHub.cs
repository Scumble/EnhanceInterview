using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EnhanceInterview.Hubs
{
	public class NotificationHub : Hub
	{
		public void GetDataFromClient(string userId, string connectionId)
		{
			Clients.Client(connectionId).SendAsync("clientMethodName", $"Updated userid {userId}");
		}

		public override Task OnConnectedAsync()
		{
			var connectionId = Context.ConnectionId;
			Clients.Client(connectionId).SendAsync("StartConnection", connectionId);
			return base.OnConnectedAsync();
		}
	}
}