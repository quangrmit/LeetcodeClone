using Microsoft.AspNetCore.SignalR;
using ChatService;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            // _connections[Context.ConnectionId] = userConnection;

            // await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} has joined {userConnection.Room}");

            // await SendUsersConnected(userConnection.Room);
        }

        public async Task SyncContent(string content, string activeLang)
        {
            await Clients.All.SendAsync("ReceiveContent", content, activeLang);

        }
    }
}