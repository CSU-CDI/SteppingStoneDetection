namespace SteppingStoneCapture.Analysis
{
    partial class CrossOverPacket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrossOverPacket));
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtOutputStream = new System.Windows.Forms.TextBox();
            this.txtInputStream = new System.Windows.Forms.TextBox();
            this.lblOutputStream = new System.Windows.Forms.Label();
            this.lblInputStream = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(13, 164);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseOutput.TabIndex = 15;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(13, 76);
            this.btnBrowseInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseInput.TabIndex = 14;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtOutputStream
            // 
            this.txtOutputStream.Location = new System.Drawing.Point(13, 134);
            this.txtOutputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputStream.Name = "txtOutputStream";
            this.txtOutputStream.Size = new System.Drawing.Size(424, 22);
            this.txtOutputStream.TabIndex = 13;
            // 
            // txtInputStream
            // 
            this.txtInputStream.Location = new System.Drawing.Point(13, 46);
            this.txtInputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputStream.Name = "txtInputStream";
            this.txtInputStream.Size = new System.Drawing.Size(424, 22);
            this.txtInputStream.TabIndex = 12;
            // 
            // lblOutputStream
            // 
            this.lblOutputStream.AutoSize = true;
            this.lblOutputStream.Location = new System.Drawing.Point(10, 113);
            this.lblOutputStream.Name = "lblOutputStream";
            this.lblOutputStream.Size = new System.Drawing.Size(206, 17);
            this.lblOutputStream.TabIndex = 11;
            this.lblOutputStream.Text = "Select Echo Stream From File...";
            // 
            // lblInputStream
            // 
            this.lblInputStream.AutoSize = true;
            this.lblInputStream.Location = new System.Drawing.Point(10, 25);
            this.lblInputStream.Name = "lblInputStream";
            this.lblInputStream.Size = new System.Drawing.Size(207, 17);
            this.lblInputStream.TabIndex = 10;
            this.lblInputStream.Text = "Select Send Stream From File...";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(218, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 39);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(346, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 39);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CrossOverPacket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 309);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.txtOutputStream);
            this.Controls.Add(this.txtInputStream);
            this.Controls.Add(this.lblOutputStream);
            this.Controls.Add(this.lblInputStream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CrossOverPacket";
            this.Text = "Cross-Over Packet Detection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.TextBox txtOutputStream;
        private System.Windows.Forms.TextBox txtInputStream;
        private System.Windows.Forms.Label lblOutputStream;
        private System.Windows.Forms.Label lblInputStream;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}