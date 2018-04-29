namespace SteppingStoneCapture.Tools
{
    partial class CustomLoadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomLoadForm));
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.extensionChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(12, 12);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(319, 20);
            this.FilePathTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(175, 38);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(256, 38);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.Accept_Click);
            // 
            // extensionChkBox
            // 
            this.extensionChkBox.AutoSize = true;
            this.extensionChkBox.Location = new System.Drawing.Point(12, 43);
            this.extensionChkBox.Name = "extensionChkBox";
            this.extensionChkBox.Size = new System.Drawing.Size(94, 17);
            this.extensionChkBox.TabIndex = 3;
            this.extensionChkBox.Text = "Add Extension";
            this.extensionChkBox.UseVisualStyleBackColor = true;
            // 
            // CustomLoadForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 68);
            this.Controls.Add(this.extensionChkBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(442, 172);
            this.MinimizeBox = false;
            this.Name = "CustomLoadForm";
            this.Text = "Load from Dump File...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox extensionChkBox;
    }
}