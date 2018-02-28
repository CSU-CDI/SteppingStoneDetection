namespace SteppingStoneCapture
{
    partial class CaptureForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDumpFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterVisibilityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFilterFieldItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpPacketsDuringCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureAndDumpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiWindowDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawPacketViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.chkTCP = new System.Windows.Forms.CheckBox();
            this.chkUDP = new System.Windows.Forms.CheckBox();
            this.chkICMP = new System.Windows.Forms.CheckBox();
            this.chkARP = new System.Windows.Forms.CheckBox();
            this.chkDNS = new System.Windows.Forms.CheckBox();
            this.txtFilterField = new System.Windows.Forms.TextBox();
            this.lblSrcIP = new System.Windows.Forms.Label();
            this.lblDestIP = new System.Windows.Forms.Label();
            this.lblSrcPort = new System.Windows.Forms.Label();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.txtSrcIP = new System.Windows.Forms.TextBox();
            this.txtDestIP = new System.Windows.Forms.TextBox();
            this.txtSrcPort = new System.Windows.Forms.TextBox();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFilterField = new System.Windows.Forms.Label();
            this.lblInterfaceList = new System.Windows.Forms.Label();
            this.lblCaptureInfo = new System.Windows.Forms.Label();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.packetView = new System.Windows.Forms.ListView();
            this.packNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srcPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dstPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ackNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Flags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShowData = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(739, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDumpFileToolStripMenuItem,
            this.SaveMenuItem,
            this.ExitMenuItem,
            this.toolStripSeparator1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // loadDumpFileToolStripMenuItem
            // 
            this.loadDumpFileToolStripMenuItem.Name = "loadDumpFileToolStripMenuItem";
            this.loadDumpFileToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.loadDumpFileToolStripMenuItem.Text = "&Load Dump File";
            this.loadDumpFileToolStripMenuItem.Click += new System.EventHandler(this.LoadDumpFileToolStripMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.CheckOnClick = true;
            this.SaveMenuItem.DoubleClickEnabled = true;
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(189, 26);
            this.SaveMenuItem.Text = "Sa&ve";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.CheckOnClick = true;
            this.ExitMenuItem.DoubleClickEnabled = true;
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(189, 26);
            this.ExitMenuItem.Text = "Exi&t";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterVisibilityItem,
            this.dumpPacketsDuringCaptureToolStripMenuItem,
            this.hexEditorToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // filterVisibilityItem
            // 
            this.filterVisibilityItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFilterFieldItem});
            this.filterVisibilityItem.Name = "filterVisibilityItem";
            this.filterVisibilityItem.Size = new System.Drawing.Size(154, 26);
            this.filterVisibilityItem.Text = "&Visual";
            // 
            // showFilterFieldItem
            // 
            this.showFilterFieldItem.Name = "showFilterFieldItem";
            this.showFilterFieldItem.Size = new System.Drawing.Size(231, 26);
            this.showFilterFieldItem.Text = "Show/Hide &Filter Field";
            this.showFilterFieldItem.Click += new System.EventHandler(this.ShowFilterFieldToolStripMenuItem_Click);
            // 
            // dumpPacketsDuringCaptureToolStripMenuItem
            // 
            this.dumpPacketsDuringCaptureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureAndDumpMenuItem});
            this.dumpPacketsDuringCaptureToolStripMenuItem.Name = "dumpPacketsDuringCaptureToolStripMenuItem";
            this.dumpPacketsDuringCaptureToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.dumpPacketsDuringCaptureToolStripMenuItem.Text = "&Capture";
            // 
            // captureAndDumpMenuItem
            // 
            this.captureAndDumpMenuItem.Name = "captureAndDumpMenuItem";
            this.captureAndDumpMenuItem.Size = new System.Drawing.Size(294, 26);
            this.captureAndDumpMenuItem.Text = "&Dump Packets During Capture....";
            this.captureAndDumpMenuItem.Click += new System.EventHandler(this.CaptureAndDumpMenuItem_Click);
            // 
            // hexEditorToolStripMenuItem
            // 
            this.hexEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiWindowDisplayMenuItem,
            this.rawPacketViewItem});
            this.hexEditorToolStripMenuItem.Name = "hexEditorToolStripMenuItem";
            this.hexEditorToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.hexEditorToolStripMenuItem.Text = "&Hex Editor";
            // 
            // multiWindowDisplayMenuItem
            // 
            this.multiWindowDisplayMenuItem.Name = "multiWindowDisplayMenuItem";
            this.multiWindowDisplayMenuItem.Size = new System.Drawing.Size(349, 26);
            this.multiWindowDisplayMenuItem.Text = "&Display Selected Packet in New Window";
            this.multiWindowDisplayMenuItem.Click += new System.EventHandler(this.MultiWindowDisplayMenuItem_Click);
            // 
            // rawPacketViewItem
            // 
            this.rawPacketViewItem.Checked = true;
            this.rawPacketViewItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rawPacketViewItem.Name = "rawPacketViewItem";
            this.rawPacketViewItem.Size = new System.Drawing.Size(349, 26);
            this.rawPacketViewItem.Text = "&Raw Packet View";
            this.rawPacketViewItem.Click += new System.EventHandler(this.rawPacketViewItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(12, 46);
            this.cmbInterfaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(275, 24);
            this.cmbInterfaces.TabIndex = 2;
            this.cmbInterfaces.SelectedIndexChanged += new System.EventHandler(this.CmbInterfaces_SelectedIndexChanged);
            // 
            // chkTCP
            // 
            this.chkTCP.AutoSize = true;
            this.chkTCP.Location = new System.Drawing.Point(29, 78);
            this.chkTCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkTCP.Name = "chkTCP";
            this.chkTCP.Size = new System.Drawing.Size(57, 21);
            this.chkTCP.TabIndex = 3;
            this.chkTCP.Text = "TCP";
            this.chkTCP.UseVisualStyleBackColor = true;
            // 
            // chkUDP
            // 
            this.chkUDP.AutoSize = true;
            this.chkUDP.Location = new System.Drawing.Point(111, 78);
            this.chkUDP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUDP.Name = "chkUDP";
            this.chkUDP.Size = new System.Drawing.Size(59, 21);
            this.chkUDP.TabIndex = 4;
            this.chkUDP.Text = "UDP";
            this.chkUDP.UseVisualStyleBackColor = true;
            // 
            // chkICMP
            // 
            this.chkICMP.AutoSize = true;
            this.chkICMP.Location = new System.Drawing.Point(201, 78);
            this.chkICMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkICMP.Name = "chkICMP";
            this.chkICMP.Size = new System.Drawing.Size(62, 21);
            this.chkICMP.TabIndex = 5;
            this.chkICMP.Text = "ICMP";
            this.chkICMP.UseVisualStyleBackColor = true;
            // 
            // chkARP
            // 
            this.chkARP.AutoSize = true;
            this.chkARP.Location = new System.Drawing.Point(67, 100);
            this.chkARP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkARP.Name = "chkARP";
            this.chkARP.Size = new System.Drawing.Size(58, 21);
            this.chkARP.TabIndex = 6;
            this.chkARP.Text = "ARP";
            this.chkARP.UseVisualStyleBackColor = true;
            // 
            // chkDNS
            // 
            this.chkDNS.AutoSize = true;
            this.chkDNS.Location = new System.Drawing.Point(148, 100);
            this.chkDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDNS.Name = "chkDNS";
            this.chkDNS.Size = new System.Drawing.Size(59, 21);
            this.chkDNS.TabIndex = 7;
            this.chkDNS.Text = "DNS";
            this.chkDNS.UseVisualStyleBackColor = true;
            // 
            // txtFilterField
            // 
            this.txtFilterField.Location = new System.Drawing.Point(12, 145);
            this.txtFilterField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterField.Name = "txtFilterField";
            this.txtFilterField.Size = new System.Drawing.Size(564, 22);
            this.txtFilterField.TabIndex = 8;
            this.txtFilterField.Visible = false;
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(308, 38);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSrcIP.Size = new System.Drawing.Size(73, 17);
            this.lblSrcIP.TabIndex = 9;
            this.lblSrcIP.Text = "Source IP:";
            // 
            // lblDestIP
            // 
            this.lblDestIP.AutoSize = true;
            this.lblDestIP.Location = new System.Drawing.Point(308, 63);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(57, 17);
            this.lblDestIP.TabIndex = 10;
            this.lblDestIP.Text = "Dest IP:";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(308, 90);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(87, 17);
            this.lblSrcPort.TabIndex = 11;
            this.lblSrcPort.Text = "Source Port:";
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(308, 116);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(71, 17);
            this.lblDestPort.TabIndex = 12;
            this.lblDestPort.Text = "Dest Port:";
            // 
            // txtSrcIP
            // 
            this.txtSrcIP.Location = new System.Drawing.Point(401, 37);
            this.txtSrcIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSrcIP.Name = "txtSrcIP";
            this.txtSrcIP.Size = new System.Drawing.Size(175, 22);
            this.txtSrcIP.TabIndex = 13;
            // 
            // txtDestIP
            // 
            this.txtDestIP.Location = new System.Drawing.Point(401, 63);
            this.txtDestIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestIP.Name = "txtDestIP";
            this.txtDestIP.Size = new System.Drawing.Size(175, 22);
            this.txtDestIP.TabIndex = 14;
            // 
            // txtSrcPort
            // 
            this.txtSrcPort.Location = new System.Drawing.Point(401, 90);
            this.txtSrcPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSrcPort.Name = "txtSrcPort";
            this.txtSrcPort.Size = new System.Drawing.Size(175, 22);
            this.txtSrcPort.TabIndex = 15;
            // 
            // txtDestPort
            // 
            this.txtDestPort.Location = new System.Drawing.Point(401, 116);
            this.txtDestPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(175, 22);
            this.txtDestPort.TabIndex = 16;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(597, 39);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 36);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(597, 82);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 38);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(597, 127);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(125, 38);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(603, 516);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 38);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(471, 516);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 38);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Sav&e";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblFilterField
            // 
            this.lblFilterField.AutoSize = true;
            this.lblFilterField.Location = new System.Drawing.Point(12, 127);
            this.lblFilterField.Name = "lblFilterField";
            this.lblFilterField.Size = new System.Drawing.Size(77, 17);
            this.lblFilterField.TabIndex = 23;
            this.lblFilterField.Text = "Filter Field:";
            this.lblFilterField.Visible = false;
            // 
            // lblInterfaceList
            // 
            this.lblInterfaceList.AutoSize = true;
            this.lblInterfaceList.Location = new System.Drawing.Point(12, 28);
            this.lblInterfaceList.Name = "lblInterfaceList";
            this.lblInterfaceList.Size = new System.Drawing.Size(93, 17);
            this.lblInterfaceList.TabIndex = 24;
            this.lblInterfaceList.Text = "Interface List:";
            // 
            // lblCaptureInfo
            // 
            this.lblCaptureInfo.AutoSize = true;
            this.lblCaptureInfo.Location = new System.Drawing.Point(12, 176);
            this.lblCaptureInfo.Name = "lblCaptureInfo";
            this.lblCaptureInfo.Size = new System.Drawing.Size(89, 17);
            this.lblCaptureInfo.TabIndex = 25;
            this.lblCaptureInfo.Text = "Capture Info:";
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(15, 510);
            this.chkAutoScroll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(92, 21);
            this.chkAutoScroll.TabIndex = 27;
            this.chkAutoScroll.Text = "&Autoscroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // packetView
            // 
            this.packetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.packNum,
            this.TimeStamp,
            this.SourceIP,
            this.DestIP,
            this.Length,
            this.srcPort,
            this.dstPort,
            this.chkSum,
            this.seqNum,
            this.ackNum,
            this.Flags});
            this.packetView.FullRowSelect = true;
            this.packetView.GridLines = true;
            this.packetView.Location = new System.Drawing.Point(12, 196);
            this.packetView.Margin = new System.Windows.Forms.Padding(5);
            this.packetView.Name = "packetView";
            this.packetView.Size = new System.Drawing.Size(709, 307);
            this.packetView.TabIndex = 28;
            this.packetView.UseCompatibleStateImageBehavior = false;
            this.packetView.View = System.Windows.Forms.View.Details;
            this.packetView.SelectedIndexChanged += new System.EventHandler(this.PacketView_SelectedIndexChanged);
            // 
            // packNum
            // 
            this.packNum.Text = "Packet #";
            // 
            // TimeStamp
            // 
            this.TimeStamp.Text = "Time Stamp";
            this.TimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeStamp.Width = 80;
            // 
            // SourceIP
            // 
            this.SourceIP.Text = "Source IP";
            this.SourceIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SourceIP.Width = 100;
            // 
            // DestIP
            // 
            this.DestIP.Text = "Destination IP";
            this.DestIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DestIP.Width = 100;
            // 
            // Length
            // 
            this.Length.Text = "Length";
            this.Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // srcPort
            // 
            this.srcPort.Text = "Src Port";
            // 
            // dstPort
            // 
            this.dstPort.Text = "Dst Port";
            // 
            // chkSum
            // 
            this.chkSum.Text = "ChkSum";
            // 
            // seqNum
            // 
            this.seqNum.Text = "Seq #";
            // 
            // ackNum
            // 
            this.ackNum.Text = "Ack #";
            // 
            // Flags
            // 
            this.Flags.Text = "Flags";
            this.Flags.Width = 100;
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(340, 516);
            this.btnShowData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(125, 38);
            this.btnShowData.TabIndex = 29;
            this.btnShowData.Text = "Show &Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 564);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.packetView);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.lblCaptureInfo);
            this.Controls.Add(this.lblInterfaceList);
            this.Controls.Add(this.lblFilterField);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtDestPort);
            this.Controls.Add(this.txtSrcPort);
            this.Controls.Add(this.txtDestIP);
            this.Controls.Add(this.txtSrcIP);
            this.Controls.Add(this.lblDestPort);
            this.Controls.Add(this.lblSrcPort);
            this.Controls.Add(this.lblDestIP);
            this.Controls.Add(this.lblSrcIP);
            this.Controls.Add(this.txtFilterField);
            this.Controls.Add(this.chkDNS);
            this.Controls.Add(this.chkARP);
            this.Controls.Add(this.chkICMP);
            this.Controls.Add(this.chkUDP);
            this.Controls.Add(this.chkTCP);
            this.Controls.Add(this.cmbInterfaces);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CaptureForm";
            this.Text = "Capture Window";
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.CheckBox chkTCP;
        private System.Windows.Forms.CheckBox chkUDP;
        private System.Windows.Forms.CheckBox chkICMP;
        private System.Windows.Forms.CheckBox chkARP;
        private System.Windows.Forms.CheckBox chkDNS;
        private System.Windows.Forms.TextBox txtFilterField;
        private System.Windows.Forms.Label lblSrcIP;
        private System.Windows.Forms.Label lblDestIP;
        private System.Windows.Forms.Label lblSrcPort;
        private System.Windows.Forms.Label lblDestPort;
        private System.Windows.Forms.TextBox txtSrcIP;
        private System.Windows.Forms.TextBox txtDestIP;
        private System.Windows.Forms.TextBox txtSrcPort;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFilterField;
        private System.Windows.Forms.Label lblInterfaceList;
        private System.Windows.Forms.Label lblCaptureInfo;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.ListView packetView;
        private System.Windows.Forms.ColumnHeader packNum;
        private System.Windows.Forms.ColumnHeader TimeStamp;
        private System.Windows.Forms.ColumnHeader SourceIP;
        private System.Windows.Forms.ColumnHeader DestIP;
        private System.Windows.Forms.ColumnHeader Length;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDumpFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterVisibilityItem;
        private System.Windows.Forms.ToolStripMenuItem dumpPacketsDuringCaptureToolStripMenuItem;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showFilterFieldItem;
        private System.Windows.Forms.ToolStripMenuItem captureAndDumpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiWindowDisplayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawPacketViewItem;
        private System.Windows.Forms.ColumnHeader srcPort;
        private System.Windows.Forms.ColumnHeader dstPort;
        private System.Windows.Forms.ColumnHeader chkSum;
        private System.Windows.Forms.ColumnHeader seqNum;
        private System.Windows.Forms.ColumnHeader ackNum;
        private System.Windows.Forms.ColumnHeader Flags;
    }
}

