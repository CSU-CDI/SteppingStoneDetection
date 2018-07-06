namespace SteppingStoneCapture.Analysis.PacketMatching
{
    partial class PacketMatchingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketMatchingForm));
            this.ResetBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultGrpBox = new System.Windows.Forms.GroupBox();
            this.resTextBox = new System.Windows.Forms.RichTextBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTxtBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.resultGrpBox.SuspendLayout();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBtn.Location = new System.Drawing.Point(614, 48);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(134, 23);
            this.ResetBtn.TabIndex = 5;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runBtn.Location = new System.Drawing.Point(614, 10);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(134, 23);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveTextItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "&Menu";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.ConnectionFileItem_Click);
            // 
            // saveTextItem
            // 
            this.saveTextItem.Name = "saveTextItem";
            this.saveTextItem.Size = new System.Drawing.Size(180, 22);
            this.saveTextItem.Text = "&Save";
            this.saveTextItem.Click += new System.EventHandler(this.SaveTextItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algorithmsToolStripMenuItem,
            this.networkConfigurationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // algorithmsToolStripMenuItem
            // 
            this.algorithmsToolStripMenuItem.Name = "algorithmsToolStripMenuItem";
            this.algorithmsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.algorithmsToolStripMenuItem.Text = "&Algorithms";
            // 
            // networkConfigurationToolStripMenuItem
            // 
            this.networkConfigurationToolStripMenuItem.Name = "networkConfigurationToolStripMenuItem";
            this.networkConfigurationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.networkConfigurationToolStripMenuItem.Text = "&Network Configuration";
            // 
            // resultGrpBox
            // 
            this.resultGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGrpBox.Controls.Add(this.resTextBox);
            this.resultGrpBox.Location = new System.Drawing.Point(12, 110);
            this.resultGrpBox.Name = "resultGrpBox";
            this.resultGrpBox.Size = new System.Drawing.Size(776, 328);
            this.resultGrpBox.TabIndex = 2;
            this.resultGrpBox.TabStop = false;
            this.resultGrpBox.Text = "Resulting Matches";
            // 
            // resTextBox
            // 
            this.resTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resTextBox.Location = new System.Drawing.Point(3, 16);
            this.resTextBox.Name = "resTextBox";
            this.resTextBox.Size = new System.Drawing.Size(770, 309);
            this.resTextBox.TabIndex = 0;
            this.resTextBox.Text = "";
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.fileLabel);
            this.grpBox.Controls.Add(this.fileTxtBox);
            this.grpBox.Controls.Add(this.runBtn);
            this.grpBox.Controls.Add(this.ResetBtn);
            this.grpBox.Location = new System.Drawing.Point(12, 27);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(776, 77);
            this.grpBox.TabIndex = 6;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Controls";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(24, 29);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(83, 13);
            this.fileLabel.TabIndex = 7;
            this.fileLabel.Text = "Connection File:";
            // 
            // fileTxtBox
            // 
            this.fileTxtBox.Location = new System.Drawing.Point(27, 48);
            this.fileTxtBox.Name = "fileTxtBox";
            this.fileTxtBox.Size = new System.Drawing.Size(517, 20);
            this.fileTxtBox.TabIndex = 6;
            // 
            // PacketMatchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.resultGrpBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PacketMatchingForm";
            this.Text = "PacketMatchingForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.resultGrpBox.ResumeLayout(false);
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox resultGrpBox;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTextItem;
        private System.Windows.Forms.RichTextBox resTextBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkConfigurationToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTxtBox;
    }
}