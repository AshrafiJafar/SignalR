using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string who, string message, string connectionId)
        {
            await Clients.All.SendAsync("ReceivedMessage", who , message, connectionId);
            //await Clients.Client(clientId).SendAsync(who, message);
        }


        public async Task BroadcastToConnection(string data, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("BroadcastToClient", data);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}
