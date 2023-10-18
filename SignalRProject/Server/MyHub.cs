using Microsoft.AspNetCore.SignalR;

namespace Server;
public class MyHub : Hub<IChatClient>
{
    public static ConnectionMapping<string> Connections { get; private set; } = new();

    public async Task BroadcastMessage(string message)
    {
        await Clients.All.ReceiveMessage(message);
    }

    public async Task SendMessage(string who, string message)
    {

        if (!Connections.GetConnections(who).Any())
        {
            // This is error, return "User Not Found"
            await Clients.Caller.ReceiveMessage($"User <{who}> does not exist.");
            return;
        }

        foreach (var connection in Connections.GetConnections(who))
        {
            await Clients.Client(connection).ReceiveMessage(message);
        }
    }

    public override Task OnConnectedAsync()
    {
        // TODO: Add Connection association of user to connection id
        string? user = Context.User?.Identity?.Name;

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        // TODO: Remove Connection association of user to connection id
        string? user = Context.User?.Identity?.Name;

        return base.OnDisconnectedAsync(exception);
    }
}
