using Microsoft.AspNetCore.SignalR;
using ChatService;

namespace ProjectWebApi.Hubs
{
    public class ChatHub : Hub
    {
        // Which connection(user) is in which room
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _connections = connections;
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            _connections[Context.ConnectionId] = userConnection;

            // await SendUsersConnected(userConnection.Room);
        }

        public async Task SyncContent(string content, string activeLang)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                Console.WriteLine("This is user room");
                Console.WriteLine(userConnection.Room);
                await Clients.Group(userConnection.Room).SendAsync("ReceiveContent", content, activeLang);
            }
        }
    }
}