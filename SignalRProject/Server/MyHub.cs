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

        string messageToSend = "[All][" + user + "]: " + message;

        await Clients.All.ReceiveMessage(messageToSend);
        ServerForm.Instance?.Log($"[{user}][Broadcast]: {message}");
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

        string messageToSend = "[" + user + "] says: " + message;
        foreach (var connection in receiverConnections)
        {
            await Clients.Client(connection).ReceiveMessage(messageToSend);
        }
        string messageSent = "To [" + who + "]: " + message;
        await Clients.Caller.ReceiveMessage(messageSent);
        ServerForm.Instance?.Log($"[{user}->{who}]: {message}");
    }

    public async Task DeclareUser(string name)
    {
        Connections.Add(name, Context.ConnectionId);
        ServerForm.Instance?.AddClient(name);
        await Clients.Caller.ReceiveMessage($"Connected as <{name}>.");
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var name = Connections.GetKey(Context.ConnectionId);
        if (name != null)
        {
            Connections.Remove(name, Context.ConnectionId);
            ServerForm.Instance?.RemoveClient(name);
        }

        return base.OnDisconnectedAsync(exception);
    }
}
