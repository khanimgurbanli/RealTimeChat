using Microsoft.AspNetCore.SignalR;

namespace SingnalR_App.Hubs
{
    public class MainHub : Hub
    {
        List<string> clients = new List<string>();

        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("recieveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("Userjoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("Userleaved", Context.ConnectionId);
        }
    }
}
