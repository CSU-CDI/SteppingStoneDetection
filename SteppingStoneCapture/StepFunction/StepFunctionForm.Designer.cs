namespace SteppingStoneCapture.StepFunction
{
    partial class StepFunctionForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EchoStreamBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.echoStreamLabel = new System.Windows.Forms.Label();
            this.sendStreamLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadStreamFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStreamFIlesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 0;
            // 
            // EchoStreamBox
            // 
            this.EchoStreamBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EchoStreamBox.Location = new System.Drawing.Point(168, 31);
            this.EchoStreamBox.Name = "EchoStreamBox";
            this.EchoStreamBox.Size = new System.Drawing.Size(150, 20);
            this.EchoStreamBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.echoStreamLabel);
            this.groupBox1.Controls.Add(this.sendStreamLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.EchoStreamBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // echoStreamLabel
            // 
            this.echoStreamLabel.AutoSize = true;
            this.echoStreamLabel.Location = new System.Drawing.Point(165, 15);
            this.echoStreamLabel.Name = "echoStreamLabel";
            this.echoStreamLabel.Size = new System.Drawing.Size(90, 13);
            this.echoStreamLabel.TabIndex = 4;
            this.echoStreamLabel.Text = "Echo Stream File:";
            // 
            // sendStreamLabel
            // 
            this.sendStreamLabel.AutoSize = true;
            this.sendStreamLabel.Location = new System.Drawing.Point(1, 15);
            this.sendStreamLabel.Name = "sendStreamLabel";
            this.sendStreamLabel.Size = new System.Drawing.Size(90, 13);
            this.sendStreamLabel.TabIndex = 3;
            this.sendStreamLabel.Text = "Send Stream File:";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(160, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadStreamFilesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadStreamFilesToolStripMenuItem
            // 
            this.loadStreamFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadStreamFIlesToolStripMenuItem1});
            this.loadStreamFilesToolStripMenuItem.Name = "loadStreamFilesToolStripMenuItem";
            this.loadStreamFilesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.loadStreamFilesToolStripMenuItem.Text = "&Menu";
            this.loadStreamFilesToolStripMenuItem.Click += new System.EventHandler(this.loadStreamFilesToolStripMenuItem_Click);
            // 
            // loadStreamFIlesToolStripMenuItem1
            // 
            this.loadStreamFIlesToolStripMenuItem1.Name = "loadStreamFIlesToolStripMenuItem1";
            this.loadStreamFIlesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loadStreamFIlesToolStripMenuItem1.Text = "Load &Stream Files";
            // 
            // StepFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StepFunctionForm";
            this.Text = "StepFunctionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox EchoStreamBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label echoStreamLabel;
        private System.Windows.Forms.Label sendStreamLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadStreamFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStreamFIlesToolStripMenuItem1;
    }
}