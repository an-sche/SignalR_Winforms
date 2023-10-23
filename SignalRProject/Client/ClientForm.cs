using Microsoft.AspNetCore.SignalR.Client;

namespace Client;

public partial class ClientForm : Form
{
    HubConnection? connection;

    public ClientForm()
    {
        InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        string name = txtClientName.Text;
        string serverIp = txtServer.Text;

        if (string.IsNullOrEmpty(name))
            return;

        Connect(serverIp);

        connection?.StartAsync().Wait();
        connection?.InvokeCoreAsync("DeclareUser", args: new[] { name });

        btnConnect.Enabled = false;
        txtClientName.Enabled = false;

        btnSend.Enabled = true;
        btnBroadcast.Enabled = true;
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        connection.StopAsync();

        btnConnect.Enabled = true;
        txtClientName.Enabled = true;

        btnSend.Enabled = false;
        btnBroadcast.Enabled = false;
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        connection.InvokeCoreAsync("SendMessage", args: new[] { txtWho.Text, txtMessage.Text });
    }

    private void btnBroadcast_Click(object sender, EventArgs e)
    {
        connection.InvokeCoreAsync("BroadcastMessage", args: new[] { txtMessage.Text });
    }

    private void UpdateText(string text)
    {
        txtLog.AppendText(text + Environment.NewLine);
    }

    private void Connect(string serverIp)
    {
        string url = "https://" + serverIp + ":5050/myHub";

        connection = new HubConnectionBuilder()
            .WithUrl(url, (options) =>
            {
                options.HttpMessageHandlerFactory = (message) =>
                {
                    if (message is HttpClientHandler clientHandler)
                    {
                        clientHandler.ServerCertificateCustomValidationCallback +=
                            (msg, cert, chain, policy) => { return true; };
                    }
                    return message;
                };
            })
            .Build();

        connection.On("ReceiveMessage", (string message) =>
        {
            BeginInvoke(UpdateText, message);
        });
    }
}
