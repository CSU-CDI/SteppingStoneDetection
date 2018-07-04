namespace SteppingStoneCapture.Analysis
{
    partial class PacketInject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketInject));
            this.lblSrcIP = new System.Windows.Forms.Label();
            this.lblDestIP = new System.Windows.Forms.Label();
            this.lblSrcPort = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSrcIP = new System.Windows.Forms.TextBox();
            this.txtDestIP = new System.Windows.Forms.TextBox();
            this.txtSrcPort = new System.Windows.Forms.TextBox();
            this.grpFlags = new System.Windows.Forms.GroupBox();
            this.radFIN = new System.Windows.Forms.RadioButton();
            this.radRST = new System.Windows.Forms.RadioButton();
            this.radACK = new System.Windows.Forms.RadioButton();
            this.radPSH = new System.Windows.Forms.RadioButton();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.grpFlags.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(22, 23);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.Size = new System.Drawing.Size(73, 17);
            this.lblSrcIP.TabIndex = 0;
            this.lblSrcIP.Text = "Source IP:";
            // 
            // lblDestIP
            // 
            this.lblDestIP.AutoSize = true;
            this.lblDestIP.Location = new System.Drawing.Point(38, 53);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(57, 17);
            this.lblDestIP.TabIndex = 1;
            this.lblDestIP.Text = "Dest IP:";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(32, 82);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(63, 17);
            this.lblSrcPort.TabIndex = 2;
            this.lblSrcPort.Text = "Src Port:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 284);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(115, 41);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSrcIP
            // 
            this.txtSrcIP.Location = new System.Drawing.Point(101, 20);
            this.txtSrcIP.Name = "txtSrcIP";
            this.txtSrcIP.Size = new System.Drawing.Size(219, 22);
            this.txtSrcIP.TabIndex = 5;
            // 
            // txtDestIP
            // 
            this.txtDestIP.Location = new System.Drawing.Point(101, 48);
            this.txtDestIP.Name = "txtDestIP";
            this.txtDestIP.Size = new System.Drawing.Size(219, 22);
            this.txtDestIP.TabIndex = 6;
            // 
            // txtSrcPort
            // 
            this.txtSrcPort.Location = new System.Drawing.Point(101, 77);
            this.txtSrcPort.Name = "txtSrcPort";
            this.txtSrcPort.Size = new System.Drawing.Size(142, 22);
            this.txtSrcPort.TabIndex = 7;
            // 
            // grpFlags
            // 
            this.grpFlags.Controls.Add(this.radFIN);
            this.grpFlags.Controls.Add(this.radRST);
            this.grpFlags.Controls.Add(this.radACK);
            this.grpFlags.Controls.Add(this.radPSH);
            this.grpFlags.Location = new System.Drawing.Point(12, 135);
            this.grpFlags.Name = "grpFlags";
            this.grpFlags.Size = new System.Drawing.Size(94, 132);
            this.grpFlags.TabIndex = 8;
            this.grpFlags.TabStop = false;
            this.grpFlags.Text = "TCP Flags";
            // 
            // radFIN
            // 
            this.radFIN.AutoSize = true;
            this.radFIN.Location = new System.Drawing.Point(13, 102);
            this.radFIN.Name = "radFIN";
            this.radFIN.Size = new System.Drawing.Size(50, 21);
            this.radFIN.TabIndex = 13;
            this.radFIN.TabStop = true;
            this.radFIN.Text = "&FIN";
            this.radFIN.UseVisualStyleBackColor = true;
            this.radFIN.CheckedChanged += new System.EventHandler(this.radFIN_CheckedChanged);
            // 
            // radRST
            // 
            this.radRST.AutoSize = true;
            this.radRST.Location = new System.Drawing.Point(13, 75);
            this.radRST.Name = "radRST";
            this.radRST.Size = new System.Drawing.Size(57, 21);
            this.radRST.TabIndex = 12;
            this.radRST.TabStop = true;
            this.radRST.Text = "&RST";
            this.radRST.UseVisualStyleBackColor = true;
            this.radRST.CheckedChanged += new System.EventHandler(this.radRST_CheckedChanged);
            // 
            // radACK
            // 
            this.radACK.AutoSize = true;
            this.radACK.Location = new System.Drawing.Point(13, 48);
            this.radACK.Name = "radACK";
            this.radACK.Size = new System.Drawing.Size(56, 21);
            this.radACK.TabIndex = 11;
            this.radACK.TabStop = true;
            this.radACK.Text = "&ACK";
            this.radACK.UseVisualStyleBackColor = true;
            this.radACK.CheckedChanged += new System.EventHandler(this.radACK_CheckedChanged);
            // 
            // radPSH
            // 
            this.radPSH.AutoSize = true;
            this.radPSH.Location = new System.Drawing.Point(13, 21);
            this.radPSH.Name = "radPSH";
            this.radPSH.Size = new System.Drawing.Size(57, 21);
            this.radPSH.TabIndex = 10;
            this.radPSH.TabStop = true;
            this.radPSH.Text = "&PSH";
            this.radPSH.UseVisualStyleBackColor = true;
            this.radPSH.CheckedChanged += new System.EventHandler(this.radPSH_CheckedChanged);
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.lblResult);
            this.grpResults.Controls.Add(this.label1);
            this.grpResults.Location = new System.Drawing.Point(112, 131);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(208, 73);
            this.grpResults.TabIndex = 9;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(6, 25);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 29);
            this.lblResult.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 36);
            this.label1.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(112, 210);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(208, 57);
            this.txtInput.TabIndex = 9;
            this.txtInput.Text = "Message to Send...";
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // txtDestPort
            // 
            this.txtDestPort.Location = new System.Drawing.Point(101, 105);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(142, 22);
            this.txtDestPort.TabIndex = 8;
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(24, 108);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(71, 17);
            this.lblDestPort.TabIndex = 12;
            this.lblDestPort.Text = "Dest Port:";
            // 
            // PacketInject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 337);
            this.Controls.Add(this.lblDestPort);
            this.Controls.Add(this.txtDestPort);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpFlags);
            this.Controls.Add(this.txtSrcPort);
            this.Controls.Add(this.txtDestIP);
            this.Controls.Add(this.txtSrcIP);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSrcPort);
            this.Controls.Add(this.lblDestIP);
            this.Controls.Add(this.lblSrcIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PacketInject";
            this.Text = "Inject Packet";
            this.grpFlags.ResumeLayout(false);
            this.grpFlags.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSrcIP;
        private System.Windows.Forms.Label lblDestIP;
        private System.Windows.Forms.Label lblSrcPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtSrcIP;
        private System.Windows.Forms.TextBox txtDestIP;
        private System.Windows.Forms.TextBox txtSrcPort;
        private System.Windows.Forms.GroupBox grpFlags;
        private System.Windows.Forms.RadioButton radFIN;
        private System.Windows.Forms.RadioButton radRST;
        private System.Windows.Forms.RadioButton radACK;
        private System.Windows.Forms.RadioButton radPSH;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.Label lblDestPort;
    }
}