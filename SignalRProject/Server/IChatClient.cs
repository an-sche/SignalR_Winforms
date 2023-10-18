namespace Server;
public interface IChatClient
{
    public Task BroadcastMessage(string message);
    public Task SendMessage(string who, string message);
    public Task ReceiveMessage(string message);
}
