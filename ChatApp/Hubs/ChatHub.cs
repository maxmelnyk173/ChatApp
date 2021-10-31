using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
	public class ChatHub : Hub
	{
		public Task JoinRoom(string roomName)
		{
			return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
		}

		public Task LeaveRoom(string roomName)
		{
			return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
		}
	}
}
