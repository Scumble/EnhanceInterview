using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EnhanceInterview.Hubs
{
	public class ChatHub : Hub
	{
		public async Task EnterChat(string userName, string groupName)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
			await Clients.Group(groupName).SendAsync("EnterChat", userName);
		}

		public async Task Send(string message, string userName, string groupName)
		{
			await Clients.Group(groupName).SendAsync("Send", message, userName, DateTime.Now);
		}

		public async Task UpdateCodeEditor(string text, string groupName)
		{
			await Clients.Group(groupName).SendAsync("UpdateCodeEditor", text);
		}
	}
}