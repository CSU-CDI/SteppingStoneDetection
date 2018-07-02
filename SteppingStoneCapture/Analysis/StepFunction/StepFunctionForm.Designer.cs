namespace SteppingStoneCapture.Analysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StepFunctionForm));
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.echoTextBox = new System.Windows.Forms.TextBox();
            this.fileGrpBox = new System.Windows.Forms.GroupBox();
            this.echoStreamLabel = new System.Windows.Forms.Label();
            this.sendStreamLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadStreamFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStreamFIlesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.echoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstMatchPacketMatchingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepFunctionInALANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkConfigurationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.graphingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.firstMatchRadio = new System.Windows.Forms.RadioButton();
            this.conservativeRadio = new System.Windows.Forms.RadioButton();
            this.fileGrpBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // sendTextBox
            // 
            this.sendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendTextBox.Location = new System.Drawing.Point(6, 31);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ReadOnly = true;
            this.sendTextBox.Size = new System.Drawing.Size(251, 20);
            this.sendTextBox.TabIndex = 0;
            // 
            // echoTextBox
            // 
            this.echoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.echoTextBox.Location = new System.Drawing.Point(281, 31);
            this.echoTextBox.Name = "echoTextBox";
            this.echoTextBox.ReadOnly = true;
            this.echoTextBox.Size = new System.Drawing.Size(264, 20);
            this.echoTextBox.TabIndex = 1;
            // 
            // fileGrpBox
            // 
            this.fileGrpBox.Controls.Add(this.echoStreamLabel);
            this.fileGrpBox.Controls.Add(this.sendStreamLabel);
            this.fileGrpBox.Controls.Add(this.label1);
            this.fileGrpBox.Controls.Add(this.sendTextBox);
            this.fileGrpBox.Controls.Add(this.echoTextBox);
            this.fileGrpBox.Location = new System.Drawing.Point(12, 34);
            this.fileGrpBox.Name = "fileGrpBox";
            this.fileGrpBox.Size = new System.Drawing.Size(551, 57);
            this.fileGrpBox.TabIndex = 3;
            this.fileGrpBox.TabStop = false;
            // 
            // echoStreamLabel
            // 
            this.echoStreamLabel.AutoSize = true;
            this.echoStreamLabel.Location = new System.Drawing.Point(278, 13);
            this.echoStreamLabel.Name = "echoStreamLabel";
            this.echoStreamLabel.Size = new System.Drawing.Size(54, 13);
            this.echoStreamLabel.TabIndex = 4;
            this.echoStreamLabel.Text = "Echo File:";
            // 
            // sendStreamLabel
            // 
            this.sendStreamLabel.AutoSize = true;
            this.sendStreamLabel.Location = new System.Drawing.Point(3, 13);
            this.sendStreamLabel.Name = "sendStreamLabel";
            this.sendStreamLabel.Size = new System.Drawing.Size(54, 13);
            this.sendStreamLabel.TabIndex = 3;
            this.sendStreamLabel.Text = "Send File:";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(268, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadStreamFilesToolStripMenuItem,
            this.aboutItem});
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
            // 
            // loadStreamFIlesToolStripMenuItem1
            // 
            this.loadStreamFIlesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToolStripMenuItem,
            this.echoFileToolStripMenuItem});
            this.loadStreamFIlesToolStripMenuItem1.Name = "loadStreamFIlesToolStripMenuItem1";
            this.loadStreamFIlesToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.loadStreamFIlesToolStripMenuItem1.Text = "Load &Stream Files";
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.sendFileToolStripMenuItem.Text = "Send File";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.LoadSendPackets);
            // 
            // echoFileToolStripMenuItem
            // 
            this.echoFileToolStripMenuItem.Name = "echoFileToolStripMenuItem";
            this.echoFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.echoFileToolStripMenuItem.Text = "Echo File";
            this.echoFileToolStripMenuItem.Click += new System.EventHandler(this.LoadEchoPackets);
            // 
            // aboutItem
            // 
            this.aboutItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstMatchPacketMatchingItem,
            this.stepFunctionInALANToolStripMenuItem,
            this.networkConfigurationItem});
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(44, 20);
            this.aboutItem.Text = "&Help";
            // 
            // firstMatchPacketMatchingItem
            // 
            this.firstMatchPacketMatchingItem.Name = "firstMatchPacketMatchingItem";
            this.firstMatchPacketMatchingItem.Size = new System.Drawing.Size(227, 22);
            this.firstMatchPacketMatchingItem.Text = "&First-Match Packet Matching";
            // 
            // stepFunctionInALANToolStripMenuItem
            // 
            this.stepFunctionInALANToolStripMenuItem.Name = "stepFunctionInALANToolStripMenuItem";
            this.stepFunctionInALANToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.stepFunctionInALANToolStripMenuItem.Text = "&Step-Function in a LAN";
            // 
            // networkConfigurationItem
            // 
            this.networkConfigurationItem.Name = "networkConfigurationItem";
            this.networkConfigurationItem.Size = new System.Drawing.Size(227, 22);
            this.networkConfigurationItem.Text = "Network Configuration";
            this.networkConfigurationItem.Click += new System.EventHandler(this.NetworkConfigurationItem_Click);
            // 
            // GraphButton
            // 
            this.GraphButton.Location = new System.Drawing.Point(588, 61);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(85, 30);
            this.GraphButton.TabIndex = 5;
            this.GraphButton.Text = "&Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(681, 61);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(85, 30);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "&Reset";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // graphingChart
            // 
            this.graphingChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Number of Matched Packets";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked;
            chartArea1.AxisY.Title = "RTT";
            chartArea1.Name = "ChartArea1";
            this.graphingChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graphingChart.Legends.Add(legend1);
            this.graphingChart.Location = new System.Drawing.Point(12, 97);
            this.graphingChart.Name = "graphingChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Legend = "Legend1";
            series1.Name = "GraphingSeries";
            this.graphingChart.Series.Add(series1);
            this.graphingChart.Size = new System.Drawing.Size(776, 262);
            this.graphingChart.TabIndex = 7;
            this.graphingChart.Text = "chart1";
            title1.BackColor = System.Drawing.Color.White;
            title1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            title1.IsDockedInsideChartArea = false;
            title1.Name = "Title1";
            title1.Text = "RTT (ms) v. Number of matched Packets";
            this.graphingChart.Titles.Add(title1);
            // 
            // firstMatchRadio
            // 
            this.firstMatchRadio.AutoSize = true;
            this.firstMatchRadio.Checked = true;
            this.firstMatchRadio.Location = new System.Drawing.Point(596, 34);
            this.firstMatchRadio.Name = "firstMatchRadio";
            this.firstMatchRadio.Size = new System.Drawing.Size(77, 17);
            this.firstMatchRadio.TabIndex = 8;
            this.firstMatchRadio.TabStop = true;
            this.firstMatchRadio.Text = "First-Match";
            this.firstMatchRadio.UseVisualStyleBackColor = true;
            // 
            // conservativeRadio
            // 
            this.conservativeRadio.AutoSize = true;
            this.conservativeRadio.Location = new System.Drawing.Point(681, 34);
            this.conservativeRadio.Name = "conservativeRadio";
            this.conservativeRadio.Size = new System.Drawing.Size(87, 17);
            this.conservativeRadio.TabIndex = 9;
            this.conservativeRadio.Text = "Conservative";
            this.conservativeRadio.UseVisualStyleBackColor = true;
            // 
            // StepFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.conservativeRadio);
            this.Controls.Add(this.firstMatchRadio);
            this.Controls.Add(this.graphingChart);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.fileGrpBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StepFunctionForm";
            this.Text = "Step-Function Graphing Tool";
            this.fileGrpBox.ResumeLayout(false);
            this.fileGrpBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.TextBox echoTextBox;
        private System.Windows.Forms.GroupBox fileGrpBox;
        private System.Windows.Forms.Label echoStreamLabel;
        private System.Windows.Forms.Label sendStreamLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadStreamFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStreamFIlesToolStripMenuItem1;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphingChart;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem firstMatchPacketMatchingItem;
        private System.Windows.Forms.ToolStripMenuItem stepFunctionInALANToolStripMenuItem;
        private System.Windows.Forms.RadioButton firstMatchRadio;
        private System.Windows.Forms.RadioButton conservativeRadio;
        private System.Windows.Forms.ToolStripMenuItem networkConfigurationItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem echoFileToolStripMenuItem;
    }
}