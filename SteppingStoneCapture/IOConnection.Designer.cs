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
            this.grpConnectionFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectionFilter
            // 
            this.grpConnectionFilter.Controls.Add(this.lblPort);
            this.grpConnectionFilter.Controls.Add(this.txtPort);
            this.grpConnectionFilter.Controls.Add(this.txtIpOne);
            this.grpConnectionFilter.Controls.Add(this.lblIP1);
            this.grpConnectionFilter.Location = new System.Drawing.Point(2, 18);
            this.grpConnectionFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpConnectionFilter.Name = "grpConnectionFilter";
            this.grpConnectionFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpConnectionFilter.Size = new System.Drawing.Size(283, 99);
            this.grpConnectionFilter.TabIndex = 0;
            this.grpConnectionFilter.TabStop = false;
            this.grpConnectionFilter.Text = "IP / PORT";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(34, 66);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 63;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(73, 63);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(167, 20);
            this.txtPort.TabIndex = 62;
            // 
            // txtIpOne
            // 
            this.txtIpOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpOne.Location = new System.Drawing.Point(73, 19);
            this.txtIpOne.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIpOne.Name = "txtIpOne";
            this.txtIpOne.Size = new System.Drawing.Size(167, 20);
            this.txtIpOne.TabIndex = 61;
            // 
            // lblIP1
            // 
            this.lblIP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIP1.AutoSize = true;
            this.lblIP1.Location = new System.Drawing.Point(7, 22);
            this.lblIP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIP1.Name = "lblIP1";
            this.lblIP1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIP1.Size = new System.Drawing.Size(56, 13);
            this.lblIP1.TabIndex = 60;
            this.lblIP1.Text = "Sensor IP:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(188, 137);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // IOConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 181);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpConnectionFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOConnection";
            this.Text = "Incoming/Outgoing Connection";
            this.grpConnectionFilter.ResumeLayout(false);
            this.grpConnectionFilter.PerformLayout();
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
    }
}