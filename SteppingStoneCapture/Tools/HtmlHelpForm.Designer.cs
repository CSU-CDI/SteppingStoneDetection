namespace SteppingStoneCapture.Tools
{
    partial class HtmlHelpForm
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
            this.htmlWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // htmlWebBrowser
            // 
            this.htmlWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.htmlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.htmlWebBrowser.Name = "htmlWebBrowser";
            this.htmlWebBrowser.Size = new System.Drawing.Size(800, 450);
            this.htmlWebBrowser.TabIndex = 0;
            // 
            // HtmlHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.htmlWebBrowser);
            this.Name = "HtmlHelpForm";
            this.Text = "HtmlHelpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser htmlWebBrowser;
    }
}