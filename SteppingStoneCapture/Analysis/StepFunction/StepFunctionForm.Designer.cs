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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EchoStreamBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.echoStreamLabel = new System.Windows.Forms.Label();
            this.sendStreamLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadStreamFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStreamFIlesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.graphingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstMatchPacketMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepFunctionInALANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(247, 20);
            this.textBox1.TabIndex = 0;
            // 
            // EchoStreamBox
            // 
            this.EchoStreamBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EchoStreamBox.Location = new System.Drawing.Point(281, 31);
            this.EchoStreamBox.Name = "EchoStreamBox";
            this.EchoStreamBox.ReadOnly = true;
            this.EchoStreamBox.Size = new System.Drawing.Size(260, 20);
            this.EchoStreamBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.echoStreamLabel);
            this.groupBox1.Controls.Add(this.sendStreamLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.EchoStreamBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // echoStreamLabel
            // 
            this.echoStreamLabel.AutoSize = true;
            this.echoStreamLabel.Location = new System.Drawing.Point(278, 13);
            this.echoStreamLabel.Name = "echoStreamLabel";
            this.echoStreamLabel.Size = new System.Drawing.Size(90, 13);
            this.echoStreamLabel.TabIndex = 4;
            this.echoStreamLabel.Text = "Echo Stream File:";
            // 
            // sendStreamLabel
            // 
            this.sendStreamLabel.AutoSize = true;
            this.sendStreamLabel.Location = new System.Drawing.Point(3, 13);
            this.sendStreamLabel.Name = "sendStreamLabel";
            this.sendStreamLabel.Size = new System.Drawing.Size(90, 13);
            this.sendStreamLabel.TabIndex = 3;
            this.sendStreamLabel.Text = "Send Stream File:";
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
            this.aboutToolStripMenuItem});
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
            // GraphButton
            // 
            this.GraphButton.Location = new System.Drawing.Point(587, 47);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(85, 30);
            this.GraphButton.TabIndex = 5;
            this.GraphButton.Text = "Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(687, 47);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(85, 30);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Reset";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // graphingChart
            // 
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
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstMatchPacketMatchingToolStripMenuItem,
            this.stepFunctionInALANToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // firstMatchPacketMatchingToolStripMenuItem
            // 
            this.firstMatchPacketMatchingToolStripMenuItem.Name = "firstMatchPacketMatchingToolStripMenuItem";
            this.firstMatchPacketMatchingToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.firstMatchPacketMatchingToolStripMenuItem.Text = "&First-Match Packet Matching";
            // 
            // stepFunctionInALANToolStripMenuItem
            // 
            this.stepFunctionInALANToolStripMenuItem.Name = "stepFunctionInALANToolStripMenuItem";
            this.stepFunctionInALANToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.stepFunctionInALANToolStripMenuItem.Text = "&Step-Function in a LAN";
            // 
            // StepFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.graphingChart);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StepFunctionForm";
            this.Text = "StepFunctionForm";
            this.Load += new System.EventHandler(this.StepFunctionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).EndInit();
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
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphingChart;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstMatchPacketMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepFunctionInALANToolStripMenuItem;
    }
}