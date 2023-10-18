using Microsoft.AspNetCore.SignalR.Client;

namespace Client;

public partial class ClientForm : Form
{
    HubConnection connection;

    public ClientForm()
    {
        InitializeComponent();

        connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5050/myHub")
            .Build();

        connection.On("ReceiveMessage", (string message) =>
        {
            BeginInvoke(UpdateText, message);
        });
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        connection.StartAsync().Wait();
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        connection.StopAsync();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        connection.InvokeCoreAsync("SendMessage", args: new[] { txtClientName.Text, txtMessage.Text });
    }

    private void UpdateText(string text)
    {
        txtLog.AppendText(text + Environment.NewLine);
    }
}
