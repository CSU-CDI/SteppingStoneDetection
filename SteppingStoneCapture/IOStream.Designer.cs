namespace SteppingStoneCapture
{
    partial class IOStream
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
            this.grpStreamFilter = new System.Windows.Forms.GroupBox();
            this.txtIpOne = new System.Windows.Forms.TextBox();
            this.chkSrcIP1 = new System.Windows.Forms.CheckBox();
            this.lblIP1 = new System.Windows.Forms.Label();
            this.chkDstIP1 = new System.Windows.Forms.CheckBox();
            this.lblIP2 = new System.Windows.Forms.Label();
            this.txtIpTwo = new System.Windows.Forms.TextBox();
            this.chkDstIP2 = new System.Windows.Forms.CheckBox();
            this.chkSrcIP2 = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpStreamFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStreamFilter
            // 
            this.grpStreamFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grpStreamFilter.Controls.Add(this.lblPort);
            this.grpStreamFilter.Controls.Add(this.txtPort);
            this.grpStreamFilter.Controls.Add(this.txtIpOne);
            this.grpStreamFilter.Controls.Add(this.chkSrcIP1);
            this.grpStreamFilter.Controls.Add(this.lblIP1);
            this.grpStreamFilter.Controls.Add(this.chkDstIP1);
            this.grpStreamFilter.Controls.Add(this.lblIP2);
            this.grpStreamFilter.Controls.Add(this.txtIpTwo);
            this.grpStreamFilter.Controls.Add(this.chkDstIP2);
            this.grpStreamFilter.Controls.Add(this.chkSrcIP2);
            this.grpStreamFilter.Location = new System.Drawing.Point(12, 27);
            this.grpStreamFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpStreamFilter.Name = "grpStreamFilter";
            this.grpStreamFilter.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpStreamFilter.Size = new System.Drawing.Size(405, 204);
            this.grpStreamFilter.TabIndex = 56;
            this.grpStreamFilter.TabStop = false;
            this.grpStreamFilter.Text = "IP / PORT";
            // 
            // txtIpOne
            // 
            this.txtIpOne.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIpOne.Location = new System.Drawing.Point(148, 45);
            this.txtIpOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIpOne.Name = "txtIpOne";
            this.txtIpOne.Size = new System.Drawing.Size(221, 22);
            this.txtIpOne.TabIndex = 52;
            // 
            // chkSrcIP1
            // 
            this.chkSrcIP1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSrcIP1.AutoSize = true;
            this.chkSrcIP1.Location = new System.Drawing.Point(27, 33);
            this.chkSrcIP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSrcIP1.Name = "chkSrcIP1";
            this.chkSrcIP1.Size = new System.Drawing.Size(51, 21);
            this.chkSrcIP1.TabIndex = 54;
            this.chkSrcIP1.Text = "Src";
            this.chkSrcIP1.UseVisualStyleBackColor = true;
            // 
            // lblIP1
            // 
            this.lblIP1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIP1.AutoSize = true;
            this.lblIP1.Location = new System.Drawing.Point(96, 47);
            this.lblIP1.Name = "lblIP1";
            this.lblIP1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIP1.Size = new System.Drawing.Size(37, 17);
            this.lblIP1.TabIndex = 50;
            this.lblIP1.Text = "IP-1:";
            // 
            // chkDstIP1
            // 
            this.chkDstIP1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkDstIP1.AutoSize = true;
            this.chkDstIP1.Location = new System.Drawing.Point(27, 57);
            this.chkDstIP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDstIP1.Name = "chkDstIP1";
            this.chkDstIP1.Size = new System.Drawing.Size(51, 21);
            this.chkDstIP1.TabIndex = 55;
            this.chkDstIP1.Text = "Dst";
            this.chkDstIP1.UseVisualStyleBackColor = true;
            // 
            // lblIP2
            // 
            this.lblIP2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIP2.AutoSize = true;
            this.lblIP2.Location = new System.Drawing.Point(96, 106);
            this.lblIP2.Name = "lblIP2";
            this.lblIP2.Size = new System.Drawing.Size(37, 17);
            this.lblIP2.TabIndex = 51;
            this.lblIP2.Text = "IP-2:";
            // 
            // txtIpTwo
            // 
            this.txtIpTwo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIpTwo.Location = new System.Drawing.Point(148, 106);
            this.txtIpTwo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIpTwo.Name = "txtIpTwo";
            this.txtIpTwo.Size = new System.Drawing.Size(221, 22);
            this.txtIpTwo.TabIndex = 53;
            // 
            // chkDstIP2
            // 
            this.chkDstIP2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkDstIP2.AutoSize = true;
            this.chkDstIP2.Location = new System.Drawing.Point(27, 117);
            this.chkDstIP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDstIP2.Name = "chkDstIP2";
            this.chkDstIP2.Size = new System.Drawing.Size(51, 21);
            this.chkDstIP2.TabIndex = 57;
            this.chkDstIP2.Text = "Dst";
            this.chkDstIP2.UseVisualStyleBackColor = true;
            // 
            // chkSrcIP2
            // 
            this.chkSrcIP2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSrcIP2.AutoSize = true;
            this.chkSrcIP2.Location = new System.Drawing.Point(27, 93);
            this.chkSrcIP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSrcIP2.Name = "chkSrcIP2";
            this.chkSrcIP2.Size = new System.Drawing.Size(51, 21);
            this.chkSrcIP2.TabIndex = 56;
            this.chkSrcIP2.Text = "Src";
            this.chkSrcIP2.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(148, 160);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(221, 22);
            this.txtPort.TabIndex = 58;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(96, 163);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 17);
            this.lblPort.TabIndex = 59;
            this.lblPort.Text = "Port:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(160, 244);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 41);
            this.btnOk.TabIndex = 57;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, -1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(303, 17);
            this.lblDescription.TabIndex = 58;
            this.lblDescription.Text = "Filter Capure by Incoming / Outgoing Stream ...";
            // 
            // IOStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 297);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpStreamFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOStream";
            this.Text = "Incoming/Outgoing Stream";
            this.Load += new System.EventHandler(this.IOStream_Load);
            this.grpStreamFilter.ResumeLayout(false);
            this.grpStreamFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStreamFilter;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIpOne;
        private System.Windows.Forms.CheckBox chkSrcIP1;
        private System.Windows.Forms.Label lblIP1;
        private System.Windows.Forms.CheckBox chkDstIP1;
        private System.Windows.Forms.Label lblIP2;
        private System.Windows.Forms.TextBox txtIpTwo;
        private System.Windows.Forms.CheckBox chkDstIP2;
        private System.Windows.Forms.CheckBox chkSrcIP2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblDescription;
    }
}