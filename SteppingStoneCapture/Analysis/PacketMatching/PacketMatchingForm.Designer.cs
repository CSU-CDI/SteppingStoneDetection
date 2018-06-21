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
            this.inputGrpBox = new System.Windows.Forms.GroupBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.echoLabel = new System.Windows.Forms.Label();
            this.sendLabel = new System.Windows.Forms.Label();
            this.echoTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.echoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultGrpBox = new System.Windows.Forms.GroupBox();
            this.resTextBox = new System.Windows.Forms.RichTextBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputGrpBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.resultGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGrpBox
            // 
            this.inputGrpBox.Controls.Add(this.ResetBtn);
            this.inputGrpBox.Controls.Add(this.runBtn);
            this.inputGrpBox.Controls.Add(this.echoLabel);
            this.inputGrpBox.Controls.Add(this.sendLabel);
            this.inputGrpBox.Controls.Add(this.echoTextBox);
            this.inputGrpBox.Controls.Add(this.sendTextBox);
            this.inputGrpBox.Location = new System.Drawing.Point(12, 27);
            this.inputGrpBox.Name = "inputGrpBox";
            this.inputGrpBox.Size = new System.Drawing.Size(776, 77);
            this.inputGrpBox.TabIndex = 0;
            this.inputGrpBox.TabStop = false;
            this.inputGrpBox.Text = "Input";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(636, 48);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(134, 23);
            this.ResetBtn.TabIndex = 5;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(636, 13);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(134, 23);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // echoLabel
            // 
            this.echoLabel.AutoSize = true;
            this.echoLabel.Location = new System.Drawing.Point(332, 22);
            this.echoLabel.Name = "echoLabel";
            this.echoLabel.Size = new System.Drawing.Size(54, 13);
            this.echoLabel.TabIndex = 3;
            this.echoLabel.Text = "Echo File:";
            // 
            // sendLabel
            // 
            this.sendLabel.AutoSize = true;
            this.sendLabel.Location = new System.Drawing.Point(28, 22);
            this.sendLabel.Name = "sendLabel";
            this.sendLabel.Size = new System.Drawing.Size(54, 13);
            this.sendLabel.TabIndex = 2;
            this.sendLabel.Text = "Send File:";
            // 
            // echoTextBox
            // 
            this.echoTextBox.Location = new System.Drawing.Point(332, 41);
            this.echoTextBox.Name = "echoTextBox";
            this.echoTextBox.Size = new System.Drawing.Size(275, 20);
            this.echoTextBox.TabIndex = 1;
            this.echoTextBox.TextChanged += new System.EventHandler(this.LoadEchoPackets);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(28, 41);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(275, 20);
            this.sendTextBox.TabIndex = 0;
            this.sendTextBox.TextChanged += new System.EventHandler(this.LoadSendPackets);
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
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "&Menu";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToolStripMenuItem,
            this.echoFileToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendFileToolStripMenuItem.Text = "&Send File";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.LoadSendPackets);
            // 
            // echoFileToolStripMenuItem
            // 
            this.echoFileToolStripMenuItem.Name = "echoFileToolStripMenuItem";
            this.echoFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.echoFileToolStripMenuItem.Text = "&Echo File";
            this.echoFileToolStripMenuItem.Click += new System.EventHandler(this.LoadEchoPackets);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // resultGrpBox
            // 
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
            this.resTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resTextBox.Location = new System.Drawing.Point(3, 16);
            this.resTextBox.Name = "resTextBox";
            this.resTextBox.Size = new System.Drawing.Size(770, 309);
            this.resTextBox.TabIndex = 0;
            this.resTextBox.Text = "";
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
            // PacketMatchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultGrpBox);
            this.Controls.Add(this.inputGrpBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PacketMatchingForm";
            this.Text = "PacketMatchingForm";
            this.inputGrpBox.ResumeLayout(false);
            this.inputGrpBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.resultGrpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputGrpBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox resultGrpBox;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label echoLabel;
        private System.Windows.Forms.Label sendLabel;
        private System.Windows.Forms.TextBox echoTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem echoFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RichTextBox resTextBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkConfigurationToolStripMenuItem;
    }
}