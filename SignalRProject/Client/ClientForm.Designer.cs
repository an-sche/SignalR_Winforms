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
        SuspendLayout();
        // 
        // txtClientName
        // 
        txtClientName.Location = new Point(100, 13);
        txtClientName.Name = "txtClientName";
        txtClientName.Size = new Size(167, 23);
        txtClientName.TabIndex = 0;
        // 
        // txtLog
        // 
        txtLog.Location = new Point(403, 11);
        txtLog.Name = "txtLog";
        txtLog.Size = new Size(289, 346);
        txtLog.TabIndex = 1;
        txtLog.Text = "";
        // 
        // lblClientName
        // 
        lblClientName.AutoSize = true;
        lblClientName.Location = new Point(40, 16);
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
        btnConnect.TabIndex = 3;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Location = new Point(311, 41);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(75, 23);
        btnDisconnect.TabIndex = 4;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // btnSend
        // 
        btnSend.Location = new Point(311, 121);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(75, 23);
        btnSend.TabIndex = 5;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(102, 122);
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(167, 23);
        txtMessage.TabIndex = 6;
        // 
        // lblMessage
        // 
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(26, 125);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(56, 15);
        lblMessage.TabIndex = 7;
        lblMessage.Text = "Message:";
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(699, 365);
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
}
