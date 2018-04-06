namespace SteppingStoneCapture
{
    partial class IOConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConnectionFilter = new System.Windows.Forms.GroupBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIpOne = new System.Windows.Forms.TextBox();
            this.lblIP1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ConnectionCombo = new System.Windows.Forms.ComboBox();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.streamsGrpBox = new System.Windows.Forms.GroupBox();
            this.EchoChk = new System.Windows.Forms.CheckBox();
            this.AckChk = new System.Windows.Forms.CheckBox();
            this.sendChk = new System.Windows.Forms.CheckBox();
            this.grpConnectionFilter.SuspendLayout();
            this.streamsGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectionFilter
            // 
            this.grpConnectionFilter.Controls.Add(this.streamsGrpBox);
            this.grpConnectionFilter.Controls.Add(this.applyBtn);
            this.grpConnectionFilter.Controls.Add(this.lblPort);
            this.grpConnectionFilter.Controls.Add(this.txtPort);
            this.grpConnectionFilter.Controls.Add(this.txtIpOne);
            this.grpConnectionFilter.Controls.Add(this.lblIP1);
            this.grpConnectionFilter.Location = new System.Drawing.Point(3, 22);
            this.grpConnectionFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpConnectionFilter.Name = "grpConnectionFilter";
            this.grpConnectionFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpConnectionFilter.Size = new System.Drawing.Size(564, 159);
            this.grpConnectionFilter.TabIndex = 0;
            this.grpConnectionFilter.TabStop = false;
            this.grpConnectionFilter.Text = "IP / PORT";
            // 
            // applyBtn
            // 
            this.applyBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.applyBtn.Location = new System.Drawing.Point(245, 124);
            this.applyBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(101, 28);
            this.applyBtn.TabIndex = 64;
            this.applyBtn.Text = "&Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(53, 81);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 17);
            this.lblPort.TabIndex = 63;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPort.Location = new System.Drawing.Point(104, 78);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(239, 22);
            this.txtPort.TabIndex = 62;
            // 
            // txtIpOne
            // 
            this.txtIpOne.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIpOne.Location = new System.Drawing.Point(104, 23);
            this.txtIpOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIpOne.Name = "txtIpOne";
            this.txtIpOne.ReadOnly = true;
            this.txtIpOne.Size = new System.Drawing.Size(239, 22);
            this.txtIpOne.TabIndex = 61;
            // 
            // lblIP1
            // 
            this.lblIP1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIP1.AutoSize = true;
            this.lblIP1.Location = new System.Drawing.Point(16, 27);
            this.lblIP1.Name = "lblIP1";
            this.lblIP1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIP1.Size = new System.Drawing.Size(73, 17);
            this.lblIP1.TabIndex = 60;
            this.lblIP1.Text = "Sensor IP:";
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(440, 255);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 41);
            this.btnOk.TabIndex = 58;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 2);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(333, 17);
            this.lblDescription.TabIndex = 59;
            this.lblDescription.Text = "Filter Capture by Incoming / Outgoing Connection ...";
            // 
            // ConnectionCombo
            // 
            this.ConnectionCombo.Enabled = false;
            this.ConnectionCombo.FormattingEnabled = true;
            this.ConnectionCombo.Location = new System.Drawing.Point(101, 210);
            this.ConnectionCombo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ConnectionCombo.Name = "ConnectionCombo";
            this.ConnectionCombo.Size = new System.Drawing.Size(463, 24);
            this.ConnectionCombo.TabIndex = 63;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(11, 214);
            this.connectionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(83, 17);
            this.connectionLabel.TabIndex = 64;
            this.connectionLabel.Text = "Connection:";
            // 
            // streamsGrpBox
            // 
            this.streamsGrpBox.Controls.Add(this.EchoChk);
            this.streamsGrpBox.Controls.Add(this.AckChk);
            this.streamsGrpBox.Controls.Add(this.sendChk);
            this.streamsGrpBox.Location = new System.Drawing.Point(385, 20);
            this.streamsGrpBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.streamsGrpBox.Name = "streamsGrpBox";
            this.streamsGrpBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.streamsGrpBox.Size = new System.Drawing.Size(171, 132);
            this.streamsGrpBox.TabIndex = 65;
            this.streamsGrpBox.TabStop = false;
            this.streamsGrpBox.Text = "I / O Streams";
            // 
            // EchoChk
            // 
            this.EchoChk.AutoSize = true;
            this.EchoChk.Location = new System.Drawing.Point(18, 56);
            this.EchoChk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.EchoChk.Name = "EchoChk";
            this.EchoChk.Size = new System.Drawing.Size(62, 21);
            this.EchoChk.TabIndex = 64;
            this.EchoChk.Text = "&Echo";
            this.EchoChk.UseVisualStyleBackColor = true;
            this.EchoChk.CheckedChanged += new System.EventHandler(this.EchoChk_CheckedChanged);
            // 
            // AckChk
            // 
            this.AckChk.AutoSize = true;
            this.AckChk.Location = new System.Drawing.Point(18, 27);
            this.AckChk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AckChk.Name = "AckChk";
            this.AckChk.Size = new System.Drawing.Size(136, 21);
            this.AckChk.TabIndex = 63;
            this.AckChk.Text = "Ac&knowledgment";
            this.AckChk.UseVisualStyleBackColor = true;
            this.AckChk.CheckedChanged += new System.EventHandler(this.AckChk_CheckedChanged);
            // 
            // sendChk
            // 
            this.sendChk.AutoSize = true;
            this.sendChk.Location = new System.Drawing.Point(17, 85);
            this.sendChk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.sendChk.Name = "sendChk";
            this.sendChk.Size = new System.Drawing.Size(63, 21);
            this.sendChk.TabIndex = 65;
            this.sendChk.Text = "&Send";
            this.sendChk.UseVisualStyleBackColor = true;
            this.sendChk.CheckedChanged += new System.EventHandler(this.sendChk_CheckedChanged);
            // 
            // IOConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 313);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.ConnectionCombo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpConnectionFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOConnection";
            this.Text = "Incoming/Outgoing Connection";
            this.Load += new System.EventHandler(this.IOConnection_Load);
            this.grpConnectionFilter.ResumeLayout(false);
            this.grpConnectionFilter.PerformLayout();
            this.streamsGrpBox.ResumeLayout(false);
            this.streamsGrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnectionFilter;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIpOne;
        private System.Windows.Forms.Label lblIP1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox ConnectionCombo;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.GroupBox streamsGrpBox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.CheckBox EchoChk;
        private System.Windows.Forms.CheckBox AckChk;
        private System.Windows.Forms.CheckBox sendChk;
    }
}