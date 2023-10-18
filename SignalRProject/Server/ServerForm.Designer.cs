namespace Server;

partial class ServerForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtLog = new RichTextBox();
        flowLayoutPanel1 = new FlowLayoutPanel();
        lblClients = new Label();
        txtMessage = new TextBox();
        lblMessage = new Label();
        btnSend = new Button();
        lblClient = new Label();
        txtClient = new TextBox();
        SuspendLayout();
        // 
        // txtLog
        // 
        txtLog.Location = new Point(12, 12);
        txtLog.Name = "txtLog";
        txtLog.Size = new Size(294, 426);
        txtLog.TabIndex = 0;
        txtLog.TabStop = false;
        txtLog.Text = "";
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Location = new Point(588, 33);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(200, 405);
        flowLayoutPanel1.TabIndex = 1;
        // 
        // lblClients
        // 
        lblClients.AutoSize = true;
        lblClients.Location = new Point(588, 15);
        lblClients.Name = "lblClients";
        lblClients.Size = new Size(43, 15);
        lblClients.TabIndex = 2;
        lblClients.Text = "Clients";
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(341, 118);
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(213, 23);
        txtMessage.TabIndex = 2;
        // 
        // lblMessage
        // 
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(341, 100);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(53, 15);
        lblMessage.TabIndex = 4;
        lblMessage.Text = "Message";
        // 
        // btnSend
        // 
        btnSend.Location = new Point(479, 147);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(75, 23);
        btnSend.TabIndex = 5;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // lblClient
        // 
        lblClient.AutoSize = true;
        lblClient.Location = new Point(341, 56);
        lblClient.Name = "lblClient";
        lblClient.Size = new Size(38, 15);
        lblClient.TabIndex = 7;
        lblClient.Text = "Client";
        // 
        // txtClient
        // 
        txtClient.Location = new Point(341, 74);
        txtClient.Name = "txtClient";
        txtClient.Size = new Size(213, 23);
        txtClient.TabIndex = 1;
        // 
        // ServerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lblClient);
        Controls.Add(txtClient);
        Controls.Add(btnSend);
        Controls.Add(lblMessage);
        Controls.Add(txtMessage);
        Controls.Add(lblClients);
        Controls.Add(flowLayoutPanel1);
        Controls.Add(txtLog);
        Name = "ServerForm";
        Text = "Server";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RichTextBox txtLog;
    private FlowLayoutPanel flowLayoutPanel1;
    private Label lblClients;
    private TextBox txtMessage;
    private Label lblMessage;
    private Button btnSend;
    private Label lblClient;
    private TextBox txtClient;
}
