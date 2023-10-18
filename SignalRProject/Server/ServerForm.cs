using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Server;

public partial class ServerForm : Form
{
    private IWebHost? _host;

    public ServerForm()
    {
        InitializeComponent();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {

    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        _host = WebHost.CreateDefaultBuilder()
            .UseUrls("https://localhost:5050")
            .UseStartup<Startup>().Build();

        _host.StartAsync();

        btnStart.Enabled = false;
        btnStop.Enabled = true;
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        _host?.StopAsync();

        btnStop.Enabled = false;
        btnStart.Enabled = true;
    }
}
