using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;
using System.Net;

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

        // Get my local IP:
        var ipAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
        string ipAddress = ipAddresses.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";

        _clients = new Dictionary<string, Control>();

        string url = "https://" + ipAddress + ":5050";

        _host = WebHost.CreateDefaultBuilder()
            .UseUrls(url)
            .UseStartup<Startup>().Build();

        _hubContext = (IHubContext<MyHub>?)_host.Services
            .GetService(typeof(IHubContext<MyHub>));

        _host.StartAsync();

        txtLog.AppendText("Server Started at: " + url + Environment.NewLine);
    }

    public void AddClient(string client)
    {
        var clientBtn = new Button();
        clientBtn.Text = client;
        clientBtn.Click += (s, e) =>
        {
            BeginInvoke(() => txtClient.Text = client);
        };
        clientBtn.Width = (int)(flowLayoutPanel1.Width * .9);

        _clients.Add(client, clientBtn);
        BeginInvoke(() => flowLayoutPanel1.Controls.Add(clientBtn));
        BeginInvoke(() => txtLog.AppendText($"Client <{client}> Added." + Environment.NewLine));
    }

    public void RemoveClient(string client)
    {
        if (_clients.TryGetValue(client, out var clientLabel))
        {
            _clients.Remove(client);
            BeginInvoke(() => flowLayoutPanel1.Controls.Remove(clientLabel));
            BeginInvoke(() => txtLog.AppendText($"Client <{client}> Removed." + Environment.NewLine));
        }
    }

    public void Log(string message)
    {
        BeginInvoke(() => txtLog.AppendText(message + Environment.NewLine));
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
