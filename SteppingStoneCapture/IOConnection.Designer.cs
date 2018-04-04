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
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIpOne = new System.Windows.Forms.TextBox();
            this.lblIP1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.AckChk = new System.Windows.Forms.CheckBox();
            this.EchoChk = new System.Windows.Forms.CheckBox();
            this.sendChk = new System.Windows.Forms.CheckBox();
            this.ConnectionCombo = new System.Windows.Forms.ComboBox();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.streamsGrpBox = new System.Windows.Forms.GroupBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.grpConnectionFilter.SuspendLayout();
            this.streamsGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectionFilter
            // 
            this.grpConnectionFilter.Controls.Add(this.applyBtn);
            this.grpConnectionFilter.Controls.Add(this.lblPort);
            this.grpConnectionFilter.Controls.Add(this.txtPort);
            this.grpConnectionFilter.Controls.Add(this.txtIpOne);
            this.grpConnectionFilter.Controls.Add(this.lblIP1);
            this.grpConnectionFilter.Location = new System.Drawing.Point(2, 18);
            this.grpConnectionFilter.Margin = new System.Windows.Forms.Padding(2);
            this.grpConnectionFilter.Name = "grpConnectionFilter";
            this.grpConnectionFilter.Padding = new System.Windows.Forms.Padding(2);
            this.grpConnectionFilter.Size = new System.Drawing.Size(288, 129);
            this.grpConnectionFilter.TabIndex = 0;
            this.grpConnectionFilter.TabStop = false;
            this.grpConnectionFilter.Text = "IP / PORT";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(39, 66);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 63;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(78, 63);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(181, 20);
            this.txtPort.TabIndex = 62;
            // 
            // txtIpOne
            // 
            this.txtIpOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpOne.Location = new System.Drawing.Point(78, 19);
            this.txtIpOne.Margin = new System.Windows.Forms.Padding(2);
            this.txtIpOne.Name = "txtIpOne";
            this.txtIpOne.ReadOnly = true;
            this.txtIpOne.Size = new System.Drawing.Size(181, 20);
            this.txtIpOne.TabIndex = 61;
            // 
            // lblIP1
            // 
            this.lblIP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIP1.AutoSize = true;
            this.lblIP1.Location = new System.Drawing.Point(12, 22);
            this.lblIP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIP1.Name = "lblIP1";
            this.lblIP1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIP1.Size = new System.Drawing.Size(56, 13);
            this.lblIP1.TabIndex = 60;
            this.lblIP1.Text = "Sensor IP:";
            // 
            // btnOk
            // 
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(330, 207);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 33);
            this.btnOk.TabIndex = 58;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 2);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(252, 13);
            this.lblDescription.TabIndex = 59;
            this.lblDescription.Text = "Filter Capture by Incoming / Outgoing Connection ...";
            // 
            // AckChk
            // 
            this.AckChk.AutoSize = true;
            this.AckChk.Location = new System.Drawing.Point(6, 22);
            this.AckChk.Name = "AckChk";
            this.AckChk.Size = new System.Drawing.Size(108, 17);
            this.AckChk.TabIndex = 60;
            this.AckChk.Text = "Acknowledgment";
            this.AckChk.UseVisualStyleBackColor = true;
            // 
            // EchoChk
            // 
            this.EchoChk.AutoSize = true;
            this.EchoChk.Location = new System.Drawing.Point(6, 45);
            this.EchoChk.Name = "EchoChk";
            this.EchoChk.Size = new System.Drawing.Size(51, 17);
            this.EchoChk.TabIndex = 61;
            this.EchoChk.Text = "Echo";
            this.EchoChk.UseVisualStyleBackColor = true;
            // 
            // sendChk
            // 
            this.sendChk.AutoSize = true;
            this.sendChk.Location = new System.Drawing.Point(6, 68);
            this.sendChk.Name = "sendChk";
            this.sendChk.Size = new System.Drawing.Size(51, 17);
            this.sendChk.TabIndex = 62;
            this.sendChk.Text = "Send";
            this.sendChk.UseVisualStyleBackColor = true;
            // 
            // ConnectionCombo
            // 
            this.ConnectionCombo.FormattingEnabled = true;
            this.ConnectionCombo.Location = new System.Drawing.Point(75, 171);
            this.ConnectionCombo.Name = "ConnectionCombo";
            this.ConnectionCombo.Size = new System.Drawing.Size(348, 21);
            this.ConnectionCombo.TabIndex = 63;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(9, 174);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(64, 13);
            this.connectionLabel.TabIndex = 64;
            this.connectionLabel.Text = "Connection:";
            // 
            // streamsGrpBox
            // 
            this.streamsGrpBox.Controls.Add(this.EchoChk);
            this.streamsGrpBox.Controls.Add(this.AckChk);
            this.streamsGrpBox.Controls.Add(this.sendChk);
            this.streamsGrpBox.Location = new System.Drawing.Point(295, 40);
            this.streamsGrpBox.Name = "streamsGrpBox";
            this.streamsGrpBox.Size = new System.Drawing.Size(128, 96);
            this.streamsGrpBox.TabIndex = 65;
            this.streamsGrpBox.TabStop = false;
            this.streamsGrpBox.Text = "Streams";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(184, 101);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 64;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // IOConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 254);
            this.Controls.Add(this.streamsGrpBox);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.ConnectionCombo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpConnectionFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOConnection";
            this.Text = "Incoming/Outgoing Connection";
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
        private System.Windows.Forms.CheckBox AckChk;
        private System.Windows.Forms.CheckBox EchoChk;
        private System.Windows.Forms.CheckBox sendChk;
        private System.Windows.Forms.ComboBox ConnectionCombo;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.GroupBox streamsGrpBox;
        private System.Windows.Forms.Button applyBtn;
    }
}