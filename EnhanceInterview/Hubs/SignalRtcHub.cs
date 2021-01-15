using System;
using System.Threading.Tasks;
using EnhanceInterview.Hubs.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EnhanceInterview.Hubs
{
	public class SignalRtcHub: Hub
	{
		public string GetConnectionId()
		{
			return Context.ConnectionId;
		}

		public RtcIceServer[] GetIceServers()
		{
			return new[] { new RtcIceServer() { Username = "", Credential = "" } };
		} 

		public async Task Join(string userName, string roomName)
		{
			var user = User.Get(userName, Context.ConnectionId);
			var room = Room.Get(roomName);

			if (user.CurrentRoom != null)
			{
				room.Users.Remove(user);
				await SendUpdatedUserList(Clients.Others, room, false);
			}

			user.CurrentRoom = room;
			room.Users.Add(user);

			await SendUpdatedUserList(Clients.Caller, room, true);
			await SendUpdatedUserList(Clients.Others, room, false);
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			await HangUp();

			await base.OnDisconnectedAsync(exception);
		}

		public async Task HangUp()
		{
			try
			{
				var callingUser = User.Get(Context.ConnectionId);

				if (callingUser == null)
				{
					return;
				}

				if (callingUser.CurrentRoom != null)
				{
					callingUser.CurrentRoom.Users.Remove(callingUser);
					await SendUpdatedUserList(Clients.Others, callingUser.CurrentRoom, false);
				}

				User.Remove(callingUser);
			}
			catch (Exception ex)
			{
				// ignored
			}
		}

		public async Task SendSignal(string signal, string targetConnectionId)
		{
			var callingUser = User.Get(Context.ConnectionId);
			var targetUser = User.Get(targetConnectionId);

			if (callingUser == null || targetUser == null)
			{
				return;
			}

			var contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy()
			};

			var call = JsonConvert.SerializeObject(callingUser, new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				Formatting = Formatting.Indented
			});

			await Clients.Client(targetConnectionId).SendAsync("receiveSignal", call, signal);
		}

		private async Task SendUpdatedUserList(IClientProxy to, Room room, bool callTo)
		{
			await to.SendAsync(callTo ? "callToUserList" : "updateUserList" , room.Name, room.Users);
		}
	}
}