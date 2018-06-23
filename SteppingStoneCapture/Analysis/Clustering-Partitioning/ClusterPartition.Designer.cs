namespace SteppingStoneCapture.Analysis
{
    partial class ClusterPartition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClusterPartition));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtOutputStream = new System.Windows.Forms.TextBox();
            this.txtInputStream = new System.Windows.Forms.TextBox();
            this.lblOutputStream = new System.Windows.Forms.Label();
            this.lblInputStream = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(220, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 39);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(348, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 39);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(15, 251);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 26;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(15, 158);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseOutput.TabIndex = 25;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(15, 70);
            this.btnBrowseInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseInput.TabIndex = 24;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtOutputStream
            // 
            this.txtOutputStream.Location = new System.Drawing.Point(15, 128);
            this.txtOutputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputStream.Name = "txtOutputStream";
            this.txtOutputStream.Size = new System.Drawing.Size(424, 22);
            this.txtOutputStream.TabIndex = 23;
            // 
            // txtInputStream
            // 
            this.txtInputStream.Location = new System.Drawing.Point(15, 40);
            this.txtInputStream.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputStream.Name = "txtInputStream";
            this.txtInputStream.Size = new System.Drawing.Size(424, 22);
            this.txtInputStream.TabIndex = 22;
            // 
            // lblOutputStream
            // 
            this.lblOutputStream.AutoSize = true;
            this.lblOutputStream.Location = new System.Drawing.Point(12, 107);
            this.lblOutputStream.Name = "lblOutputStream";
            this.lblOutputStream.Size = new System.Drawing.Size(206, 17);
            this.lblOutputStream.TabIndex = 21;
            this.lblOutputStream.Text = "Select Echo Stream From File...";
            // 
            // lblInputStream
            // 
            this.lblInputStream.AutoSize = true;
            this.lblInputStream.Location = new System.Drawing.Point(12, 19);
            this.lblInputStream.Name = "lblInputStream";
            this.lblInputStream.Size = new System.Drawing.Size(207, 17);
            this.lblInputStream.TabIndex = 20;
            this.lblInputStream.Text = "Select Send Stream From File...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Threshold:";
            // 
            // ClusterPartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.txtOutputStream);
            this.Controls.Add(this.txtInputStream);
            this.Controls.Add(this.lblOutputStream);
            this.Controls.Add(this.lblInputStream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClusterPartition";
            this.Text = "Clustering-Partitioning Detection";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.TextBox txtOutputStream;
        private System.Windows.Forms.TextBox txtInputStream;
        private System.Windows.Forms.Label lblOutputStream;
        private System.Windows.Forms.Label lblInputStream;
        private System.Windows.Forms.Label label1;
    }
}