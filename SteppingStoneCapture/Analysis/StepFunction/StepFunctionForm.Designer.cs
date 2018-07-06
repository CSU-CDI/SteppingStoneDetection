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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StepFunctionForm));
            this.fileTxtBox = new System.Windows.Forms.TextBox();
            this.fileGrpBox = new System.Windows.Forms.GroupBox();
            this.AlgorithmUpDown = new System.Windows.Forms.NumericUpDown();
            this.sendStreamLabel = new System.Windows.Forms.Label();
            this.GraphButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadStreamFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstMatchPacketMatchingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepFunctionInALANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkConfigurationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AlgorithmToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SaveGraphItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlgorithmUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // fileTxtBox
            // 
            this.fileTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTxtBox.Location = new System.Drawing.Point(6, 36);
            this.fileTxtBox.Name = "fileTxtBox";
            this.fileTxtBox.ReadOnly = true;
            this.fileTxtBox.Size = new System.Drawing.Size(564, 20);
            this.fileTxtBox.TabIndex = 0;
            this.fileTxtBox.Click += new System.EventHandler(this.LoadFileItem_Click);
            // 
            // fileGrpBox
            // 
            this.fileGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileGrpBox.Controls.Add(this.AlgorithmUpDown);
            this.fileGrpBox.Controls.Add(this.sendStreamLabel);
            this.fileGrpBox.Controls.Add(this.fileTxtBox);
            this.fileGrpBox.Controls.Add(this.GraphButton);
            this.fileGrpBox.Controls.Add(this.ClearButton);
            this.fileGrpBox.Location = new System.Drawing.Point(12, 27);
            this.fileGrpBox.Name = "fileGrpBox";
            this.fileGrpBox.Size = new System.Drawing.Size(776, 64);
            this.fileGrpBox.TabIndex = 3;
            this.fileGrpBox.TabStop = false;
            // 
            // AlgorithmUpDown
            // 
            this.AlgorithmUpDown.Location = new System.Drawing.Point(587, 11);
            this.AlgorithmUpDown.Name = "AlgorithmUpDown";
            this.AlgorithmUpDown.Size = new System.Drawing.Size(176, 20);
            this.AlgorithmUpDown.TabIndex = 10;
            this.AlgorithmToolTip.SetToolTip(this.AlgorithmUpDown, "Enables user to select different packet matching algorithm\r\nfor use \r\n\r\n0 - First" +
        " Match\r\n1 - Conservative\r\n2 - Greedy - Heuristic");
            // 
            // sendStreamLabel
            // 
            this.sendStreamLabel.AutoSize = true;
            this.sendStreamLabel.Location = new System.Drawing.Point(3, 13);
            this.sendStreamLabel.Name = "sendStreamLabel";
            this.sendStreamLabel.Size = new System.Drawing.Size(83, 13);
            this.sendStreamLabel.TabIndex = 3;
            this.sendStreamLabel.Text = "Connection File:";
            // 
            // GraphButton
            // 
            this.GraphButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphButton.Location = new System.Drawing.Point(587, 33);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(85, 25);
            this.GraphButton.TabIndex = 5;
            this.GraphButton.Text = "&Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(678, 33);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(85, 25);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "&Reset";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
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
            this.loadItem,
            this.saveToolStripMenuItem});
            this.loadStreamFilesToolStripMenuItem.Name = "loadStreamFilesToolStripMenuItem";
            this.loadStreamFilesToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.loadStreamFilesToolStripMenuItem.Text = "&Menu";
            // 
            // loadItem
            // 
            this.loadItem.Name = "loadItem";
            this.loadItem.Size = new System.Drawing.Size(180, 22);
            this.loadItem.Text = "&Load";
            this.loadItem.Click += new System.EventHandler(this.LoadFileItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveGraphItem,
            this.SaveTextItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
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
            // graphingChart
            // 
            this.graphingChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphingChart.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.Title = "Number of Matched Packets";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked;
            chartArea1.AxisY.Title = "RTT";
            chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.graphingChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.graphingChart.Legends.Add(legend1);
            this.graphingChart.Location = new System.Drawing.Point(12, 97);
            this.graphingChart.Name = "graphingChart";
            this.graphingChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
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
            // AlgorithmToolTip
            // 
            this.AlgorithmToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // SaveGraphItem
            // 
            this.SaveGraphItem.Name = "SaveGraphItem";
            this.SaveGraphItem.Size = new System.Drawing.Size(180, 22);
            this.SaveGraphItem.Text = "&Graph";
            this.SaveGraphItem.Click += new System.EventHandler(this.SaveGraphItem_Click);
            // 
            // SaveTextItem
            // 
            this.SaveTextItem.Name = "SaveTextItem";
            this.SaveTextItem.Size = new System.Drawing.Size(180, 22);
            this.SaveTextItem.Text = "&Text";
            this.SaveTextItem.Click += new System.EventHandler(this.SaveTextItem_Click);
            // 
            // StepFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.graphingChart);
            this.Controls.Add(this.fileGrpBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StepFunctionForm";
            this.Text = "Step-Function Graphing Tool";
            this.fileGrpBox.ResumeLayout(false);
            this.fileGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlgorithmUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTxtBox;
        private System.Windows.Forms.GroupBox fileGrpBox;
        private System.Windows.Forms.Label sendStreamLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadStreamFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadItem;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphingChart;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem firstMatchPacketMatchingItem;
        private System.Windows.Forms.ToolStripMenuItem stepFunctionInALANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkConfigurationItem;
        private System.Windows.Forms.NumericUpDown AlgorithmUpDown;
        private System.Windows.Forms.ToolTip AlgorithmToolTip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGraphItem;
        private System.Windows.Forms.ToolStripMenuItem SaveTextItem;
    }
}