namespace SteppingStoneCapture.Analysis
{
    partial class ContentThumbprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentThumbprint));
            this.lblInputStream = new System.Windows.Forms.Label();
            this.lblOutputStream = new System.Windows.Forms.Label();
            this.txtInputStream = new System.Windows.Forms.TextBox();
            this.txtOutputStream = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.grpContentThumbprint = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkPacketCount = new System.Windows.Forms.CheckBox();
            this.chkCharFreq = new System.Windows.Forms.CheckBox();
            this.chkCharFreqTime = new System.Windows.Forms.CheckBox();
            this.grpContentThumbprint.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInputStream
            // 
            this.lblInputStream.AutoSize = true;
            this.lblInputStream.Location = new System.Drawing.Point(39, 48);
            this.lblInputStream.Name = "lblInputStream";
            this.lblInputStream.Size = new System.Drawing.Size(205, 17);
            this.lblInputStream.TabIndex = 0;
            this.lblInputStream.Text = "Select Input Stream From File...";
            // 
            // lblOutputStream
            // 
            this.lblOutputStream.AutoSize = true;
            this.lblOutputStream.Location = new System.Drawing.Point(39, 136);
            this.lblOutputStream.Name = "lblOutputStream";
            this.lblOutputStream.Size = new System.Drawing.Size(217, 17);
            this.lblOutputStream.TabIndex = 1;
            this.lblOutputStream.Text = "Select Output Stream From File...";
            // 
            // txtInputStream
            // 
            this.txtInputStream.Location = new System.Drawing.Point(42, 69);
            this.txtInputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputStream.Name = "txtInputStream";
            this.txtInputStream.Size = new System.Drawing.Size(424, 22);
            this.txtInputStream.TabIndex = 2;
            // 
            // txtOutputStream
            // 
            this.txtOutputStream.Location = new System.Drawing.Point(42, 157);
            this.txtOutputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputStream.Name = "txtOutputStream";
            this.txtOutputStream.Size = new System.Drawing.Size(424, 22);
            this.txtOutputStream.TabIndex = 3;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(42, 99);
            this.btnBrowseInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseInput.TabIndex = 4;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(42, 187);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // grpContentThumbprint
            // 
            this.grpContentThumbprint.Controls.Add(this.chkCharFreqTime);
            this.grpContentThumbprint.Controls.Add(this.chkCharFreq);
            this.grpContentThumbprint.Controls.Add(this.chkPacketCount);
            this.grpContentThumbprint.Location = new System.Drawing.Point(473, 27);
            this.grpContentThumbprint.Name = "grpContentThumbprint";
            this.grpContentThumbprint.Size = new System.Drawing.Size(291, 228);
            this.grpContentThumbprint.TabIndex = 6;
            this.grpContentThumbprint.TabStop = false;
            this.grpContentThumbprint.Text = "Type of Thumbprint";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(651, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 39);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(522, 308);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 39);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkPacketCount
            // 
            this.chkPacketCount.AutoSize = true;
            this.chkPacketCount.Location = new System.Drawing.Point(23, 42);
            this.chkPacketCount.Name = "chkPacketCount";
            this.chkPacketCount.Size = new System.Drawing.Size(114, 21);
            this.chkPacketCount.TabIndex = 8;
            this.chkPacketCount.Text = "&Packet Count";
            this.chkPacketCount.UseVisualStyleBackColor = true;
            this.chkPacketCount.CheckedChanged += new System.EventHandler(this.chkPacketCount_CheckedChanged);
            // 
            // chkCharFreq
            // 
            this.chkCharFreq.AutoSize = true;
            this.chkCharFreq.Location = new System.Drawing.Point(23, 109);
            this.chkCharFreq.Name = "chkCharFreq";
            this.chkCharFreq.Size = new System.Drawing.Size(163, 21);
            this.chkCharFreq.TabIndex = 9;
            this.chkCharFreq.Text = "Character &Frequency";
            this.chkCharFreq.UseVisualStyleBackColor = true;
            this.chkCharFreq.CheckedChanged += new System.EventHandler(this.chkCharFreq_CheckedChanged);
            // 
            // chkCharFreqTime
            // 
            this.chkCharFreqTime.AutoSize = true;
            this.chkCharFreqTime.Enabled = false;
            this.chkCharFreqTime.Location = new System.Drawing.Point(23, 179);
            this.chkCharFreqTime.Name = "chkCharFreqTime";
            this.chkCharFreqTime.Size = new System.Drawing.Size(248, 21);
            this.chkCharFreqTime.TabIndex = 10;
            this.chkCharFreqTime.Text = "Character Frequency + &Timestamp";
            this.chkCharFreqTime.UseVisualStyleBackColor = true;
            this.chkCharFreqTime.CheckedChanged += new System.EventHandler(this.chkCharFreqTime_CheckedChanged);
            // 
            // ContentThumbprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 359);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpContentThumbprint);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.txtOutputStream);
            this.Controls.Add(this.txtInputStream);
            this.Controls.Add(this.lblOutputStream);
            this.Controls.Add(this.lblInputStream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ContentThumbprint";
            this.Text = "Content Thumbprint Detection";
            this.grpContentThumbprint.ResumeLayout(false);
            this.grpContentThumbprint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInputStream;
        private System.Windows.Forms.Label lblOutputStream;
        private System.Windows.Forms.TextBox txtInputStream;
        private System.Windows.Forms.TextBox txtOutputStream;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.GroupBox grpContentThumbprint;
        private System.Windows.Forms.CheckBox chkCharFreqTime;
        private System.Windows.Forms.CheckBox chkCharFreq;
        private System.Windows.Forms.CheckBox chkPacketCount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}