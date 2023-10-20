using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;

namespace Server;

public partial class ServerForm : Form, IServerForm
{
    public static ServerForm Instance = new();
    private readonly IWebHost? _host;
    private readonly IHubContext<MyHub>? _hubContext;
    private Dictionary<string, Control> _clients;

    private ServerForm()
    {
        Instance = this;

        InitializeComponent();

        _clients = new Dictionary<string, Control>();

        _host = WebHost.CreateDefaultBuilder()
            .UseUrls("https://localhost:5050")
            .UseStartup<Startup>().Build();

        _hubContext = (IHubContext<MyHub>?)_host.Services
            .GetService(typeof(IHubContext<MyHub>));

        _host.StartAsync();
    }

    public void AddClient(string client)
    {
        Label clientLabel = new Label();
        clientLabel.Text = client;
        clientLabel.Click += (s, e) =>
        {
            BeginInvoke(() => txtClient.Text = client);
        };

        _clients.Add(client, clientLabel);
        BeginInvoke(() => flowLayoutPanel1.Controls.Add(clientLabel));
    }

    public void RemoveClient(string client)
    {
        if (_clients.TryGetValue(client, out var clientLabel))
        {
            _clients.Remove(client);
            BeginInvoke(() => flowLayoutPanel1.Controls.Remove(clientLabel));
        }
    }

    public void Log(string message)
    {
        txtLog.AppendText(message);
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
        {
            _hubContext.Clients.Client(connection).SendAsync("ReceiveMessage", "[Server]: " + message);
        }
    }
}
