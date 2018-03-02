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
            this.txtFilterField = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.lblFilterField = new System.Windows.Forms.Label();
            this.grpFilterParams = new System.Windows.Forms.GroupBox();
            this.grpPorts = new System.Windows.Forms.GroupBox();
            this.chkPortNOT = new System.Windows.Forms.CheckBox();
            this.chkPortOR = new System.Windows.Forms.CheckBox();
            this.chkDstPort2 = new System.Windows.Forms.CheckBox();
            this.chkPortAND = new System.Windows.Forms.CheckBox();
            this.txtSrcPort = new System.Windows.Forms.TextBox();
            this.chkSrcPort2 = new System.Windows.Forms.CheckBox();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.chkDstPort1 = new System.Windows.Forms.CheckBox();
            this.lblPort2 = new System.Windows.Forms.Label();
            this.chkSrcPort1 = new System.Windows.Forms.CheckBox();
            this.lblPort1 = new System.Windows.Forms.Label();
            this.grpIPAddress = new System.Windows.Forms.GroupBox();
            this.chkIPNOT = new System.Windows.Forms.CheckBox();
            this.chkIPOR = new System.Windows.Forms.CheckBox();
            this.chkIPAND = new System.Windows.Forms.CheckBox();
            this.txtSrcIP = new System.Windows.Forms.TextBox();
            this.chkSrcIP1 = new System.Windows.Forms.CheckBox();
            this.lblIP1 = new System.Windows.Forms.Label();
            this.chkDstIP1 = new System.Windows.Forms.CheckBox();
            this.lblIP2 = new System.Windows.Forms.Label();
            this.txtDestIP = new System.Windows.Forms.TextBox();
            this.chkDstIP2 = new System.Windows.Forms.CheckBox();
            this.chkSrcIP2 = new System.Windows.Forms.CheckBox();
            this.grpFilterProtocols = new System.Windows.Forms.GroupBox();
            this.chkDNS = new System.Windows.Forms.CheckBox();
            this.chkARP = new System.Windows.Forms.CheckBox();
            this.chkICMP = new System.Windows.Forms.CheckBox();
            this.chkUDP = new System.Windows.Forms.CheckBox();
            this.chkTCP = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.grpFilterParams.SuspendLayout();
            this.grpPorts.SuspendLayout();
            this.grpIPAddress.SuspendLayout();
            this.grpFilterProtocols.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(117, 28);
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
            this.rawPacketViewItem.Click += new System.EventHandler(this.RawPacketViewItem_Click);
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
            this.cmbInterfaces.Size = new System.Drawing.Size(265, 24);
            this.cmbInterfaces.TabIndex = 2;
            this.cmbInterfaces.SelectedIndexChanged += new System.EventHandler(this.CmbInterfaces_SelectedIndexChanged);
            // 
            // txtFilterField
            // 
            this.txtFilterField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterField.Location = new System.Drawing.Point(12, 368);
            this.txtFilterField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilterField.Name = "txtFilterField";
            this.txtFilterField.Size = new System.Drawing.Size(837, 22);
            this.txtFilterField.TabIndex = 8;
            this.txtFilterField.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(870, 39);
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
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(870, 82);
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
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(870, 127);
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
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(876, 675);
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
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(744, 675);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 38);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Sav&e";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblInterfaceList
            // 
            this.lblInterfaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInterfaceList.AutoSize = true;
            this.lblInterfaceList.Location = new System.Drawing.Point(12, 28);
            this.lblInterfaceList.Name = "lblInterfaceList";
            this.lblInterfaceList.Size = new System.Drawing.Size(93, 17);
            this.lblInterfaceList.TabIndex = 24;
            this.lblInterfaceList.Text = "Interface List:";
            // 
            // lblCaptureInfo
            // 
            this.lblCaptureInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaptureInfo.AutoSize = true;
            this.lblCaptureInfo.Location = new System.Drawing.Point(9, 392);
            this.lblCaptureInfo.Name = "lblCaptureInfo";
            this.lblCaptureInfo.Size = new System.Drawing.Size(89, 17);
            this.lblCaptureInfo.TabIndex = 25;
            this.lblCaptureInfo.Text = "Capture Info:";
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(15, 669);
            this.chkAutoScroll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(92, 21);
            this.chkAutoScroll.TabIndex = 27;
            this.chkAutoScroll.Text = "&Autoscroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // packetView
            // 
            this.packetView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.packetView.Location = new System.Drawing.Point(12, 414);
            this.packetView.Margin = new System.Windows.Forms.Padding(5);
            this.packetView.Name = "packetView";
            this.packetView.Size = new System.Drawing.Size(982, 248);
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
            this.btnShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowData.Location = new System.Drawing.Point(613, 675);
            this.btnShowData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(125, 38);
            this.btnShowData.TabIndex = 29;
            this.btnShowData.Text = "Show &Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // lblFilterField
            // 
            this.lblFilterField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterField.AutoSize = true;
            this.lblFilterField.Location = new System.Drawing.Point(9, 349);
            this.lblFilterField.Name = "lblFilterField";
            this.lblFilterField.Size = new System.Drawing.Size(77, 17);
            this.lblFilterField.TabIndex = 23;
            this.lblFilterField.Text = "Filter Field:";
            this.lblFilterField.Visible = false;
            // 
            // grpFilterParams
            // 
            this.grpFilterParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilterParams.Controls.Add(this.grpPorts);
            this.grpFilterParams.Controls.Add(this.grpIPAddress);
            this.grpFilterParams.Location = new System.Drawing.Point(293, 39);
            this.grpFilterParams.Name = "grpFilterParams";
            this.grpFilterParams.Size = new System.Drawing.Size(556, 324);
            this.grpFilterParams.TabIndex = 30;
            this.grpFilterParams.TabStop = false;
            this.grpFilterParams.Text = "Filter Parameters";
            // 
            // grpPorts
            // 
            this.grpPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPorts.Controls.Add(this.chkPortNOT);
            this.grpPorts.Controls.Add(this.chkPortOR);
            this.grpPorts.Controls.Add(this.chkDstPort2);
            this.grpPorts.Controls.Add(this.chkPortAND);
            this.grpPorts.Controls.Add(this.txtSrcPort);
            this.grpPorts.Controls.Add(this.chkSrcPort2);
            this.grpPorts.Controls.Add(this.txtDestPort);
            this.grpPorts.Controls.Add(this.chkDstPort1);
            this.grpPorts.Controls.Add(this.lblPort2);
            this.grpPorts.Controls.Add(this.chkSrcPort1);
            this.grpPorts.Controls.Add(this.lblPort1);
            this.grpPorts.Location = new System.Drawing.Point(17, 162);
            this.grpPorts.Name = "grpPorts";
            this.grpPorts.Size = new System.Drawing.Size(523, 142);
            this.grpPorts.TabIndex = 55;
            this.grpPorts.TabStop = false;
            this.grpPorts.Text = "Ports";
            // 
            // chkPortNOT
            // 
            this.chkPortNOT.AutoSize = true;
            this.chkPortNOT.Location = new System.Drawing.Point(28, 85);
            this.chkPortNOT.Name = "chkPortNOT";
            this.chkPortNOT.Size = new System.Drawing.Size(52, 21);
            this.chkPortNOT.TabIndex = 63;
            this.chkPortNOT.Text = "Not";
            this.chkPortNOT.UseVisualStyleBackColor = true;
            // 
            // chkPortOR
            // 
            this.chkPortOR.AutoSize = true;
            this.chkPortOR.Location = new System.Drawing.Point(28, 59);
            this.chkPortOR.Name = "chkPortOR";
            this.chkPortOR.Size = new System.Drawing.Size(46, 21);
            this.chkPortOR.TabIndex = 62;
            this.chkPortOR.Text = "Or";
            this.chkPortOR.UseVisualStyleBackColor = true;
            // 
            // chkDstPort2
            // 
            this.chkDstPort2.AutoSize = true;
            this.chkDstPort2.Location = new System.Drawing.Point(95, 109);
            this.chkDstPort2.Name = "chkDstPort2";
            this.chkDstPort2.Size = new System.Drawing.Size(51, 21);
            this.chkDstPort2.TabIndex = 61;
            this.chkDstPort2.Text = "Dst";
            this.chkDstPort2.UseVisualStyleBackColor = true;
            // 
            // chkPortAND
            // 
            this.chkPortAND.AutoSize = true;
            this.chkPortAND.Location = new System.Drawing.Point(28, 32);
            this.chkPortAND.Name = "chkPortAND";
            this.chkPortAND.Size = new System.Drawing.Size(55, 21);
            this.chkPortAND.TabIndex = 61;
            this.chkPortAND.Text = "And";
            this.chkPortAND.UseVisualStyleBackColor = true;
            // 
            // txtSrcPort
            // 
            this.txtSrcPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcPort.Location = new System.Drawing.Point(207, 40);
            this.txtSrcPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSrcPort.Name = "txtSrcPort";
            this.txtSrcPort.Size = new System.Drawing.Size(302, 22);
            this.txtSrcPort.TabIndex = 56;
            // 
            // chkSrcPort2
            // 
            this.chkSrcPort2.AutoSize = true;
            this.chkSrcPort2.Location = new System.Drawing.Point(95, 85);
            this.chkSrcPort2.Name = "chkSrcPort2";
            this.chkSrcPort2.Size = new System.Drawing.Size(51, 21);
            this.chkSrcPort2.TabIndex = 60;
            this.chkSrcPort2.Text = "Src";
            this.chkSrcPort2.UseVisualStyleBackColor = true;
            // 
            // txtDestPort
            // 
            this.txtDestPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestPort.Location = new System.Drawing.Point(207, 101);
            this.txtDestPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(302, 22);
            this.txtDestPort.TabIndex = 57;
            // 
            // chkDstPort1
            // 
            this.chkDstPort1.AutoSize = true;
            this.chkDstPort1.Location = new System.Drawing.Point(95, 47);
            this.chkDstPort1.Name = "chkDstPort1";
            this.chkDstPort1.Size = new System.Drawing.Size(51, 21);
            this.chkDstPort1.TabIndex = 59;
            this.chkDstPort1.Text = "Dst";
            this.chkDstPort1.UseVisualStyleBackColor = true;
            // 
            // lblPort2
            // 
            this.lblPort2.AutoSize = true;
            this.lblPort2.Location = new System.Drawing.Point(150, 104);
            this.lblPort2.Name = "lblPort2";
            this.lblPort2.Size = new System.Drawing.Size(51, 17);
            this.lblPort2.TabIndex = 55;
            this.lblPort2.Text = "Port-2:";
            // 
            // chkSrcPort1
            // 
            this.chkSrcPort1.AutoSize = true;
            this.chkSrcPort1.Location = new System.Drawing.Point(95, 23);
            this.chkSrcPort1.Name = "chkSrcPort1";
            this.chkSrcPort1.Size = new System.Drawing.Size(51, 21);
            this.chkSrcPort1.TabIndex = 58;
            this.chkSrcPort1.Text = "Src";
            this.chkSrcPort1.UseVisualStyleBackColor = true;
            // 
            // lblPort1
            // 
            this.lblPort1.AutoSize = true;
            this.lblPort1.Location = new System.Drawing.Point(150, 40);
            this.lblPort1.Name = "lblPort1";
            this.lblPort1.Size = new System.Drawing.Size(51, 17);
            this.lblPort1.TabIndex = 54;
            this.lblPort1.Text = "Port-1:";
            // 
            // grpIPAddress
            // 
            this.grpIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIPAddress.Controls.Add(this.chkIPNOT);
            this.grpIPAddress.Controls.Add(this.chkIPOR);
            this.grpIPAddress.Controls.Add(this.chkIPAND);
            this.grpIPAddress.Controls.Add(this.txtSrcIP);
            this.grpIPAddress.Controls.Add(this.chkSrcIP1);
            this.grpIPAddress.Controls.Add(this.lblIP1);
            this.grpIPAddress.Controls.Add(this.chkDstIP1);
            this.grpIPAddress.Controls.Add(this.lblIP2);
            this.grpIPAddress.Controls.Add(this.txtDestIP);
            this.grpIPAddress.Controls.Add(this.chkDstIP2);
            this.grpIPAddress.Controls.Add(this.chkSrcIP2);
            this.grpIPAddress.Location = new System.Drawing.Point(17, 21);
            this.grpIPAddress.Name = "grpIPAddress";
            this.grpIPAddress.Size = new System.Drawing.Size(523, 135);
            this.grpIPAddress.TabIndex = 54;
            this.grpIPAddress.TabStop = false;
            this.grpIPAddress.Text = "IP Addresses";
            // 
            // chkIPNOT
            // 
            this.chkIPNOT.AutoSize = true;
            this.chkIPNOT.Location = new System.Drawing.Point(25, 84);
            this.chkIPNOT.Name = "chkIPNOT";
            this.chkIPNOT.Size = new System.Drawing.Size(52, 21);
            this.chkIPNOT.TabIndex = 60;
            this.chkIPNOT.Text = "Not";
            this.chkIPNOT.UseVisualStyleBackColor = true;
            // 
            // chkIPOR
            // 
            this.chkIPOR.AutoSize = true;
            this.chkIPOR.Location = new System.Drawing.Point(25, 58);
            this.chkIPOR.Name = "chkIPOR";
            this.chkIPOR.Size = new System.Drawing.Size(46, 21);
            this.chkIPOR.TabIndex = 59;
            this.chkIPOR.Text = "Or";
            this.chkIPOR.UseVisualStyleBackColor = true;
            // 
            // chkIPAND
            // 
            this.chkIPAND.AutoSize = true;
            this.chkIPAND.Location = new System.Drawing.Point(25, 31);
            this.chkIPAND.Name = "chkIPAND";
            this.chkIPAND.Size = new System.Drawing.Size(55, 21);
            this.chkIPAND.TabIndex = 58;
            this.chkIPAND.Text = "And";
            this.chkIPAND.UseVisualStyleBackColor = true;
            // 
            // txtSrcIP
            // 
            this.txtSrcIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcIP.Location = new System.Drawing.Point(207, 33);
            this.txtSrcIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSrcIP.Name = "txtSrcIP";
            this.txtSrcIP.Size = new System.Drawing.Size(302, 22);
            this.txtSrcIP.TabIndex = 52;
            // 
            // chkSrcIP1
            // 
            this.chkSrcIP1.AutoSize = true;
            this.chkSrcIP1.Location = new System.Drawing.Point(95, 18);
            this.chkSrcIP1.Name = "chkSrcIP1";
            this.chkSrcIP1.Size = new System.Drawing.Size(51, 21);
            this.chkSrcIP1.TabIndex = 54;
            this.chkSrcIP1.Text = "Src";
            this.chkSrcIP1.UseVisualStyleBackColor = true;
            // 
            // lblIP1
            // 
            this.lblIP1.AutoSize = true;
            this.lblIP1.Location = new System.Drawing.Point(164, 36);
            this.lblIP1.Name = "lblIP1";
            this.lblIP1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIP1.Size = new System.Drawing.Size(37, 17);
            this.lblIP1.TabIndex = 50;
            this.lblIP1.Text = "IP-1:";
            // 
            // chkDstIP1
            // 
            this.chkDstIP1.AutoSize = true;
            this.chkDstIP1.Location = new System.Drawing.Point(95, 42);
            this.chkDstIP1.Name = "chkDstIP1";
            this.chkDstIP1.Size = new System.Drawing.Size(51, 21);
            this.chkDstIP1.TabIndex = 55;
            this.chkDstIP1.Text = "Dst";
            this.chkDstIP1.UseVisualStyleBackColor = true;
            // 
            // lblIP2
            // 
            this.lblIP2.AutoSize = true;
            this.lblIP2.Location = new System.Drawing.Point(164, 96);
            this.lblIP2.Name = "lblIP2";
            this.lblIP2.Size = new System.Drawing.Size(37, 17);
            this.lblIP2.TabIndex = 51;
            this.lblIP2.Text = "IP-2:";
            // 
            // txtDestIP
            // 
            this.txtDestIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestIP.Location = new System.Drawing.Point(207, 94);
            this.txtDestIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestIP.Name = "txtDestIP";
            this.txtDestIP.Size = new System.Drawing.Size(302, 22);
            this.txtDestIP.TabIndex = 53;
            // 
            // chkDstIP2
            // 
            this.chkDstIP2.AutoSize = true;
            this.chkDstIP2.Location = new System.Drawing.Point(95, 102);
            this.chkDstIP2.Name = "chkDstIP2";
            this.chkDstIP2.Size = new System.Drawing.Size(51, 21);
            this.chkDstIP2.TabIndex = 57;
            this.chkDstIP2.Text = "Dst";
            this.chkDstIP2.UseVisualStyleBackColor = true;
            // 
            // chkSrcIP2
            // 
            this.chkSrcIP2.AutoSize = true;
            this.chkSrcIP2.Location = new System.Drawing.Point(95, 78);
            this.chkSrcIP2.Name = "chkSrcIP2";
            this.chkSrcIP2.Size = new System.Drawing.Size(51, 21);
            this.chkSrcIP2.TabIndex = 56;
            this.chkSrcIP2.Text = "Src";
            this.chkSrcIP2.UseVisualStyleBackColor = true;
            // 
            // grpFilterProtocols
            // 
            this.grpFilterProtocols.Controls.Add(this.chkDNS);
            this.grpFilterProtocols.Controls.Add(this.chkTCP);
            this.grpFilterProtocols.Controls.Add(this.chkARP);
            this.grpFilterProtocols.Controls.Add(this.chkUDP);
            this.grpFilterProtocols.Controls.Add(this.chkICMP);
            this.grpFilterProtocols.Location = new System.Drawing.Point(15, 82);
            this.grpFilterProtocols.Name = "grpFilterProtocols";
            this.grpFilterProtocols.Size = new System.Drawing.Size(262, 101);
            this.grpFilterProtocols.TabIndex = 64;
            this.grpFilterProtocols.TabStop = false;
            this.grpFilterProtocols.Text = "Filter Protocols";
            // 
            // chkDNS
            // 
            this.chkDNS.AutoSize = true;
            this.chkDNS.Location = new System.Drawing.Point(133, 58);
            this.chkDNS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDNS.Name = "chkDNS";
            this.chkDNS.Size = new System.Drawing.Size(59, 21);
            this.chkDNS.TabIndex = 69;
            this.chkDNS.Text = "DNS";
            this.chkDNS.UseVisualStyleBackColor = true;
            // 
            // chkARP
            // 
            this.chkARP.AutoSize = true;
            this.chkARP.Location = new System.Drawing.Point(52, 58);
            this.chkARP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkARP.Name = "chkARP";
            this.chkARP.Size = new System.Drawing.Size(58, 21);
            this.chkARP.TabIndex = 68;
            this.chkARP.Text = "ARP";
            this.chkARP.UseVisualStyleBackColor = true;
            // 
            // chkICMP
            // 
            this.chkICMP.AutoSize = true;
            this.chkICMP.Location = new System.Drawing.Point(186, 36);
            this.chkICMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkICMP.Name = "chkICMP";
            this.chkICMP.Size = new System.Drawing.Size(62, 21);
            this.chkICMP.TabIndex = 67;
            this.chkICMP.Text = "ICMP";
            this.chkICMP.UseVisualStyleBackColor = true;
            // 
            // chkUDP
            // 
            this.chkUDP.AutoSize = true;
            this.chkUDP.Location = new System.Drawing.Point(96, 36);
            this.chkUDP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUDP.Name = "chkUDP";
            this.chkUDP.Size = new System.Drawing.Size(59, 21);
            this.chkUDP.TabIndex = 66;
            this.chkUDP.Text = "UDP";
            this.chkUDP.UseVisualStyleBackColor = true;
            // 
            // chkTCP
            // 
            this.chkTCP.AutoSize = true;
            this.chkTCP.Location = new System.Drawing.Point(14, 36);
            this.chkTCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkTCP.Name = "chkTCP";
            this.chkTCP.Size = new System.Drawing.Size(57, 21);
            this.chkTCP.TabIndex = 65;
            this.chkTCP.Text = "TCP";
            this.chkTCP.UseVisualStyleBackColor = true;
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 723);
            this.Controls.Add(this.grpFilterProtocols);
            this.Controls.Add(this.grpFilterParams);
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
            this.Controls.Add(this.txtFilterField);
            this.Controls.Add(this.cmbInterfaces);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(845, 600);
            this.Name = "CaptureForm";
            this.Text = "Capture Window";
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            //this.ResizeBegin += new System.EventHandler(this.CaptureForm_ResizeBegin);
            //this.ResizeEnd += new System.EventHandler(this.CaptureForm_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpFilterParams.ResumeLayout(false);
            this.grpPorts.ResumeLayout(false);
            this.grpPorts.PerformLayout();
            this.grpIPAddress.ResumeLayout(false);
            this.grpIPAddress.PerformLayout();
            this.grpFilterProtocols.ResumeLayout(false);
            this.grpFilterProtocols.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.TextBox txtFilterField;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.Label lblFilterField;
        private System.Windows.Forms.GroupBox grpFilterParams;
        private System.Windows.Forms.GroupBox grpIPAddress;
        private System.Windows.Forms.CheckBox chkIPNOT;
        private System.Windows.Forms.CheckBox chkIPOR;
        private System.Windows.Forms.CheckBox chkIPAND;
        private System.Windows.Forms.TextBox txtSrcIP;
        private System.Windows.Forms.CheckBox chkSrcIP1;
        private System.Windows.Forms.Label lblIP1;
        private System.Windows.Forms.CheckBox chkDstIP1;
        private System.Windows.Forms.Label lblIP2;
        private System.Windows.Forms.TextBox txtDestIP;
        private System.Windows.Forms.CheckBox chkDstIP2;
        private System.Windows.Forms.CheckBox chkSrcIP2;
        private System.Windows.Forms.GroupBox grpPorts;
        private System.Windows.Forms.CheckBox chkPortNOT;
        private System.Windows.Forms.CheckBox chkPortOR;
        private System.Windows.Forms.CheckBox chkDstPort2;
        private System.Windows.Forms.CheckBox chkPortAND;
        private System.Windows.Forms.TextBox txtSrcPort;
        private System.Windows.Forms.CheckBox chkSrcPort2;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.CheckBox chkDstPort1;
        private System.Windows.Forms.Label lblPort2;
        private System.Windows.Forms.CheckBox chkSrcPort1;
        private System.Windows.Forms.Label lblPort1;
        private System.Windows.Forms.GroupBox grpFilterProtocols;
        private System.Windows.Forms.CheckBox chkDNS;
        private System.Windows.Forms.CheckBox chkTCP;
        private System.Windows.Forms.CheckBox chkARP;
        private System.Windows.Forms.CheckBox chkUDP;
        private System.Windows.Forms.CheckBox chkICMP;
    }
}

