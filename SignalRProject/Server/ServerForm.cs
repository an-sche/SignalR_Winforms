using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;

namespace Server;

public partial class ServerForm : Form
{
    private readonly IWebHost? _host;
    private readonly IHubContext<MyHub>? _hubContext;

    public ServerForm()
    {
        InitializeComponent();

        _host = WebHost.CreateDefaultBuilder()
            .UseUrls("https://localhost:5050")
            .UseStartup<Startup>().Build();

        _hubContext = (IHubContext<MyHub>?)_host.Services
            .GetService(typeof(IHubContext<MyHub>));

        _host.StartAsync();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        if (_hubContext == null)
            return;

        string client = txtClient.Text;
        string message = txtMessage.Text;

        if (!MyHub.Connections.GetConnections(client).Any())
            return;

        foreach (var connection in MyHub.Connections.GetConnections(client))
            _hubContext.Clients.Client(connection).SendAsync("ReceiveMessage", "Server: " + message);
    }
}
