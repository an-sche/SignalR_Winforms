using Microsoft.AspNetCore.SignalR;

namespace Server;
public class MyHub : Hub<IChatClient>
{
    public static ConnectionMapping<string> Connections { get; private set; } = new();

    public async Task BroadcastMessage(string message)
    {
        string user = Connections.GetKey(Context.ConnectionId) ?? string.Empty;
        if (string.IsNullOrEmpty(user))
        {
            await Clients.Caller.ReceiveMessage($"You do not exist in Mapping.");
            return;
        }

        string messageToSend = user + ": " + message;

        await Clients.All.ReceiveMessage(messageToSend);
    }

    public async Task SendMessage(string who, string message)
    {
        string user = Connections.GetKey(Context.ConnectionId) ?? string.Empty;
        if (string.IsNullOrEmpty(user))
        {
            await Clients.Caller.ReceiveMessage($"You do not exist in Mapping.");
            return;
        }

        var receiverConnections = Connections.GetConnections(who);
        if (!receiverConnections.Any())
        {
            await Clients.Caller.ReceiveMessage($"User <{who}> does not exist.");
            return;
        }

        string messageToSend = user + ": " + message;
        foreach (var connection in receiverConnections)
        {
            await Clients.Client(connection).ReceiveMessage(messageToSend);
        }
        await Clients.Caller.ReceiveMessage(messageToSend);
    }

    public async Task DeclareUser(string name)
    {
        Connections.Add(name, Context.ConnectionId);
        await Clients.Caller.ReceiveMessage($"User <{name}> Added.");
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var name = Connections.GetKey(Context.ConnectionId);
        if (name != null)
        {
            Connections.Remove(name, Context.ConnectionId);
        }

        return base.OnDisconnectedAsync(exception);
    }
}
