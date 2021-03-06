﻿namespace SteppingStoneCapture.Analysis
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
            this.radSYN = new System.Windows.Forms.RadioButton();
            this.radFIN = new System.Windows.Forms.RadioButton();
            this.radRST = new System.Windows.Forms.RadioButton();
            this.radACK = new System.Windows.Forms.RadioButton();
            this.radPSH = new System.Windows.Forms.RadioButton();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.txtNumPackets = new System.Windows.Forms.TextBox();
            this.lblNumPackets = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTTL = new System.Windows.Forms.Label();
            this.txtTTL = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblSequence = new System.Windows.Forms.Label();
            this.txtSequence = new System.Windows.Forms.TextBox();
            this.txtACK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWindow = new System.Windows.Forms.TextBox();
            this.lblRequired = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.grpFlags.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(21, 33);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.Size = new System.Drawing.Size(78, 17);
            this.lblSrcIP.TabIndex = 0;
            this.lblSrcIP.Text = "*Source IP:";
            // 
            // lblDestIP
            // 
            this.lblDestIP.AutoSize = true;
            this.lblDestIP.Location = new System.Drawing.Point(37, 63);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(62, 17);
            this.lblDestIP.TabIndex = 1;
            this.lblDestIP.Text = "*Dest IP:";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(31, 92);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(68, 17);
            this.lblSrcPort.TabIndex = 2;
            this.lblSrcPort.Text = "*Src Port:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(221, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 41);
            this.btnCancel.TabIndex = 97;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(11, 365);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 41);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "&Send";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSrcIP
            // 
            this.txtSrcIP.Location = new System.Drawing.Point(100, 30);
            this.txtSrcIP.Name = "txtSrcIP";
            this.txtSrcIP.Size = new System.Drawing.Size(142, 22);
            this.txtSrcIP.TabIndex = 1;
            // 
            // txtDestIP
            // 
            this.txtDestIP.Location = new System.Drawing.Point(100, 58);
            this.txtDestIP.Name = "txtDestIP";
            this.txtDestIP.Size = new System.Drawing.Size(142, 22);
            this.txtDestIP.TabIndex = 2;
            // 
            // txtSrcPort
            // 
            this.txtSrcPort.Location = new System.Drawing.Point(100, 87);
            this.txtSrcPort.Name = "txtSrcPort";
            this.txtSrcPort.Size = new System.Drawing.Size(142, 22);
            this.txtSrcPort.TabIndex = 3;
            // 
            // grpFlags
            // 
            this.grpFlags.Controls.Add(this.radSYN);
            this.grpFlags.Controls.Add(this.radFIN);
            this.grpFlags.Controls.Add(this.radRST);
            this.grpFlags.Controls.Add(this.radACK);
            this.grpFlags.Controls.Add(this.radPSH);
            this.grpFlags.Location = new System.Drawing.Point(11, 200);
            this.grpFlags.Name = "grpFlags";
            this.grpFlags.Size = new System.Drawing.Size(94, 159);
            this.grpFlags.TabIndex = 15;
            this.grpFlags.TabStop = false;
            this.grpFlags.Text = "TCP Flags";
            // 
            // radSYN
            // 
            this.radSYN.AutoSize = true;
            this.radSYN.Location = new System.Drawing.Point(13, 132);
            this.radSYN.Name = "radSYN";
            this.radSYN.Size = new System.Drawing.Size(57, 21);
            this.radSYN.TabIndex = 14;
            this.radSYN.TabStop = true;
            this.radSYN.Text = "SY&N";
            this.radSYN.UseVisualStyleBackColor = true;
            this.radSYN.CheckedChanged += new System.EventHandler(this.radSYN_CheckedChanged);
            // 
            // radFIN
            // 
            this.radFIN.AutoSize = true;
            this.radFIN.Location = new System.Drawing.Point(13, 106);
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
            this.radRST.Location = new System.Drawing.Point(13, 79);
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
            this.radACK.Location = new System.Drawing.Point(13, 52);
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
            this.radPSH.Location = new System.Drawing.Point(13, 25);
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
            this.grpResults.Location = new System.Drawing.Point(111, 225);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(208, 65);
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
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(111, 296);
            this.txtInput.MaxLength = 1000;
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(208, 63);
            this.txtInput.TabIndex = 7;
            this.txtInput.Text = "Message / Payload to Send...";
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // txtDestPort
            // 
            this.txtDestPort.Location = new System.Drawing.Point(100, 115);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(142, 22);
            this.txtDestPort.TabIndex = 4;
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(23, 118);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(76, 17);
            this.lblDestPort.TabIndex = 12;
            this.lblDestPort.Text = "*Dest Port:";
            // 
            // txtNumPackets
            // 
            this.txtNumPackets.Location = new System.Drawing.Point(248, 58);
            this.txtNumPackets.Name = "txtNumPackets";
            this.txtNumPackets.Size = new System.Drawing.Size(71, 22);
            this.txtNumPackets.TabIndex = 6;
            // 
            // lblNumPackets
            // 
            this.lblNumPackets.AutoSize = true;
            this.lblNumPackets.Location = new System.Drawing.Point(248, 30);
            this.lblNumPackets.Name = "lblNumPackets";
            this.lblNumPackets.Size = new System.Drawing.Size(74, 17);
            this.lblNumPackets.TabIndex = 14;
            this.lblNumPackets.Text = "# Packets:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(111, 365);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 41);
            this.btnReset.TabIndex = 98;
            this.btnReset.Text = "Rese&t";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTTL
            // 
            this.lblTTL.AutoSize = true;
            this.lblTTL.Location = new System.Drawing.Point(248, 92);
            this.lblTTL.Name = "lblTTL";
            this.lblTTL.Size = new System.Drawing.Size(38, 17);
            this.lblTTL.TabIndex = 16;
            this.lblTTL.Text = "TTL:";
            // 
            // txtTTL
            // 
            this.txtTTL.Location = new System.Drawing.Point(248, 115);
            this.txtTTL.Name = "txtTTL";
            this.txtTTL.Size = new System.Drawing.Size(55, 22);
            this.txtTTL.TabIndex = 14;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(172, 144);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(37, 17);
            this.lblID.TabIndex = 18;
            this.lblID.Text = "ID #:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(215, 142);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(104, 22);
            this.txtID.TabIndex = 10;
            // 
            // lblSequence
            // 
            this.lblSequence.AutoSize = true;
            this.lblSequence.Location = new System.Drawing.Point(11, 144);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(88, 17);
            this.lblSequence.TabIndex = 20;
            this.lblSequence.Text = "Sequence #:";
            // 
            // txtSequence
            // 
            this.txtSequence.Location = new System.Drawing.Point(100, 141);
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(66, 22);
            this.txtSequence.TabIndex = 9;
            // 
            // txtACK
            // 
            this.txtACK.Location = new System.Drawing.Point(215, 170);
            this.txtACK.Name = "txtACK";
            this.txtACK.Size = new System.Drawing.Size(104, 22);
            this.txtACK.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "ACK #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Window Size:";
            // 
            // txtWindow
            // 
            this.txtWindow.Location = new System.Drawing.Point(100, 172);
            this.txtWindow.Name = "txtWindow";
            this.txtWindow.Size = new System.Drawing.Size(55, 22);
            this.txtWindow.TabIndex = 11;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRequired.Location = new System.Drawing.Point(0, 0);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(103, 25);
            this.lblRequired.TabIndex = 100;
            this.lblRequired.Text = "* Required";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(108, 200);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(102, 17);
            this.lblInterval.TabIndex = 103;
            this.lblInterval.Text = "Interval (millis):";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(216, 200);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(103, 22);
            this.txtInterval.TabIndex = 5;
            // 
            // PacketInject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 414);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.txtWindow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtACK);
            this.Controls.Add(this.txtSequence);
            this.Controls.Add(this.lblSequence);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtTTL);
            this.Controls.Add(this.lblTTL);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblNumPackets);
            this.Controls.Add(this.txtNumPackets);
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
            this.Text = "TCP Injection";
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
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.Label lblDestPort;
        private System.Windows.Forms.TextBox txtNumPackets;
        private System.Windows.Forms.Label lblNumPackets;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton radSYN;
        private System.Windows.Forms.Label lblTTL;
        private System.Windows.Forms.TextBox txtTTL;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.TextBox txtSequence;
        private System.Windows.Forms.TextBox txtACK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWindow;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtInterval;
    }
}