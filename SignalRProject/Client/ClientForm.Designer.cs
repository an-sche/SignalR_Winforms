namespace Client;

partial class ClientForm
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
        txtClientName = new TextBox();
        txtLog = new RichTextBox();
        lblClientName = new Label();
        btnConnect = new Button();
        btnDisconnect = new Button();
        btnSend = new Button();
        txtMessage = new TextBox();
        lblMessage = new Label();
        lblWho = new Label();
        txtWho = new TextBox();
        btnBroadcast = new Button();
        label1 = new Label();
        txtServer = new TextBox();
        SuspendLayout();
        // 
        // txtClientName
        // 
        txtClientName.Location = new Point(100, 41);
        txtClientName.Name = "txtClientName";
        txtClientName.Size = new Size(167, 23);
        txtClientName.TabIndex = 0;
        // 
        // txtLog
        // 
        txtLog.Location = new Point(403, 11);
        txtLog.Name = "txtLog";
        txtLog.Size = new Size(289, 346);
        txtLog.TabIndex = 10;
        txtLog.TabStop = false;
        txtLog.Text = "";
        // 
        // lblClientName
        // 
        lblClientName.AutoSize = true;
        lblClientName.Location = new Point(40, 44);
        lblClientName.Name = "lblClientName";
        lblClientName.Size = new Size(42, 15);
        lblClientName.TabIndex = 2;
        lblClientName.Text = "Name:";
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(311, 12);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(75, 23);
        btnConnect.TabIndex = 1;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Location = new Point(311, 41);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(75, 23);
        btnDisconnect.TabIndex = 2;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // btnSend
        // 
        btnSend.Location = new Point(311, 181);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(75, 23);
        btnSend.TabIndex = 5;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(100, 181);
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(167, 23);
        txtMessage.TabIndex = 4;
        // 
        // lblMessage
        // 
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(24, 184);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(56, 15);
        lblMessage.TabIndex = 7;
        lblMessage.Text = "Message:";
        // 
        // lblWho
        // 
        lblWho.AutoSize = true;
        lblWho.Location = new Point(45, 155);
        lblWho.Name = "lblWho";
        lblWho.Size = new Size(35, 15);
        lblWho.TabIndex = 9;
        lblWho.Text = "Who:";
        // 
        // txtWho
        // 
        txtWho.Location = new Point(100, 152);
        txtWho.Name = "txtWho";
        txtWho.Size = new Size(167, 23);
        txtWho.TabIndex = 3;
        // 
        // btnBroadcast
        // 
        btnBroadcast.Location = new Point(311, 210);
        btnBroadcast.Name = "btnBroadcast";
        btnBroadcast.Size = new Size(75, 23);
        btnBroadcast.TabIndex = 6;
        btnBroadcast.Text = "Broadcast";
        btnBroadcast.UseVisualStyleBackColor = true;
        btnBroadcast.Click += btnBroadcast_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(40, 14);
        label1.Name = "label1";
        label1.Size = new Size(42, 15);
        label1.TabIndex = 12;
        label1.Text = "Server:";
        // 
        // txtServer
        // 
        txtServer.Location = new Point(100, 11);
        txtServer.Name = "txtServer";
        txtServer.Size = new Size(167, 23);
        txtServer.TabIndex = 11;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(699, 365);
        Controls.Add(label1);
        Controls.Add(txtServer);
        Controls.Add(btnBroadcast);
        Controls.Add(lblWho);
        Controls.Add(txtWho);
        Controls.Add(lblMessage);
        Controls.Add(txtMessage);
        Controls.Add(btnSend);
        Controls.Add(btnDisconnect);
        Controls.Add(btnConnect);
        Controls.Add(lblClientName);
        Controls.Add(txtLog);
        Controls.Add(txtClientName);
        Name = "ClientForm";
        Text = "Client";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtClientName;
    private RichTextBox txtLog;
    private Label lblClientName;
    private Button btnConnect;
    private Button btnDisconnect;
    private Button btnSend;
    private TextBox txtMessage;
    private Label lblMessage;
    private Label lblWho;
    private TextBox txtWho;
    private Button btnBroadcast;
    private Label label1;
    private TextBox txtServer;
}
