using Microsoft.AspNetCore.SignalR;

namespace Server;
public class MyHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", "this is a server message");
    }

}
