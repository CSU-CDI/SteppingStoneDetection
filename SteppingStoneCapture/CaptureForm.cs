using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Icmp;
using PcapDotNet.Packets.Arp;

namespace SteppingStoneCapture
{
    public partial class CaptureForm : Form
    {
        // probably needs a buffer to count so many packets and then force print to file when full
        private int deviceIndex;
        private IList<LivePacketDevice> allDevices;
        private string defaultFilterField;
        private string filter;
        private List<byte[]> packetBytes;
        private List<Packet> packets;
        private ByteViewerForm bvf;
        private Int32 packetNumber;
        private bool captFlag;
        private int numThreads;
        private Boolean protocolRequested, attributeRequested;
        private volatile Boolean captureAndDumpRequested, multiWindowDisplay, rawPacketViewDesired;
        private CougarFilterBuilder cfb;
        private Random rand;
        private int lastSelectedIndex = 0;
        private Boolean adjusted = false;

        public CaptureForm()
        {
            InitializeComponent();
            rawPacketViewItem.Checked = true;
            rand = new Random();
            deviceIndex = 0;
            defaultFilterField = "";
            filter = "";
            packetBytes = new List< byte[]>();
            packets = new List<Packet>();
            packetNumber = 0;
            captFlag = true;
            numThreads = 0;
            protocolRequested = false;
            attributeRequested = false;
            captureAndDumpRequested = captureAndDumpMenuItem.Checked;
            multiWindowDisplay = multiWindowDisplayMenuItem.Checked;
            rawPacketViewDesired = rawPacketViewItem.Checked;
            cfb = new CougarFilterBuilder("or", "or");
            bvf = new ByteViewerForm();
        }

        private void DetermineNetworkInterface(int numTries = 5)
        {
            //Detect all interfaces
            allDevices = LivePacketDevice.AllLocalMachine;

            //Try the allotted number of times if no interfaces detected
            if (allDevices.Count == 0)
            {
                if (numTries > 0)
                    DetermineNetworkInterface(--numTries);
            }

            //list available interfaces in ComboBox
            else if (allDevices.Count > 0)
            {
                for (int i = 0; i != allDevices.Count; ++i)
                {
                    int offsetForWindowsMachines = 16;
                    LivePacketDevice device = allDevices[i];
                    DescribeInterfaceDevice(offsetForWindowsMachines, device);
                }
            }
        }

        private void DescribeInterfaceDevice(int offsetForWindowsMachines, LivePacketDevice device)
        {
            if (device.Description != null)
                if (device.Description.ToLower().Contains("\'microsoft\'"))
                    cmbInterfaces.Items.Add("Wireless Connector");
                else if (device.Description.ToLower().Contains("ethernet"))
                    cmbInterfaces.Items.Add("Ethernet Connector");
                else
                    cmbInterfaces.Items.Add(device.Description.Substring(offsetForWindowsMachines));
            else
                cmbInterfaces.Items.Add("*** (No description available)");
        }

        private void SearchFormProperties()
        {
            foreach (Control c in Controls)
            {
                
                if (c is GroupBox gb)
                {
                    foreach (Control c1 in gb.Controls) {
                        if (c1 is CheckBox chk)
                        {
                            if (chk.Checked)
                            {
                                protocolRequested = true;
                                if (chk.Name != "chkAutoScroll")
                                    cfb.AddToProtocolList(chk.Text);
                            }
                        }
                        if (c1 is GroupBox gb2)
                            foreach (Control c2 in gb2.Controls)
                            {
                                if (c2 is TextBox tb)
                                {
                                    if (tb.Text != "" && tb != txtFilterField)
                                    {
                                        attributeRequested = true;
                                        switch (tb.Name)
                                        {
                                            case "txtIpOne":
                                                if (chkDstIP1.Checked)
                                                {
                                                    if (!chkIPNOT.Checked)
                                                        cfb.AddIP("dst host " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddIP("not dst host " + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    if (!chkIPNOT.Checked)
                                                        cfb.AddIP("src host " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddIP("not src host " + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtIpTwo":
                                                if (chkDstIP2.Checked)
                                                {
                                                    if (!chkIPNOT2.Checked)
                                                        cfb.AddIP("dst host " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddIP("not dst host " + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    if (!chkIPNOT2.Checked)
                                                        cfb.AddIP("src host " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddIP("not src host " + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtPortOne":
                                                if (chkDstPort1.Checked)
                                                {
                                                    if (!chkPortNOT.Checked)
                                                        cfb.AddPort("dst port " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddPort("not dst port " + tb.Text.ToLower());
                                                }
                                                else 
                                                {
                                                    if (!chkPortNOT.Checked)
                                                        cfb.AddPort("src port " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddPort("not src port " + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtPortTwo":
                                                if (chkDstPort2.Checked)
                                                {
                                                    if (!chkNotPort2.Checked)
                                                        cfb.AddPort("dst port " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddPort("not dst port " + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    if (!chkNotPort2.Checked)
                                                        cfb.AddPort("src port " + tb.Text.ToLower());
                                                    else
                                                        cfb.AddPort("not src port " + tb.Text.ToLower());
                                                }
                                                break;
                                        }
                                    }
                                }

                                else if (c2 is CheckBox cb)
                                {
                                    if (cb.Checked)
                                        switch (cb.Name)
                                        {
                                            case "chkIPAND":
                                                cfb.IpConjunction = "and";
                                                break;
                                            case "chkIPOR":
                                                cfb.IpConjunction = "or";
                                                break;
                                            case "chkPortAND":
                                                cfb.PortConjunction = "and";
                                                break;
                                            case "chkPortOR":
                                                cfb.PortConjunction = "or";
                                                break;
                                        }
                                }
                            }
                    }
                }
            }
        }

        private string TapFilterStringSource()
        {
            string tapped;

            if (protocolRequested || attributeRequested)
            {
                tapped = cfb.FilterString;

            }
            else if (txtFilterField.Text != "")
            {
                tapped = txtFilterField.Text;
            }
            else
            {
                tapped = "ip";
            }
            return tapped;
        }

        private void DumpCapturedPackets(string[] fileName) // dumps to text file
        {
            if (packetBytes.Count > 0)
            {
                using (FileStream fs = File.OpenWrite(fileName[0]+fileName[1]))
                    for (int i = 0; i < packetBytes.Count; ++i)
                    {
                        fs.Write(packetBytes[i], 0, packetBytes[i].Length);
                    }
            }
        }

        private void DumpAllPacketsFromConnection(string fileName, string addressOne, string addressTwo, int desiredPort)
        {

            string[] fileNameParts = fileName.Split('.');
            // open a file to store packets from a desired connection
            if (fileNameParts[1] == "txt")
                using (FileStream fs = File.OpenWrite(fileName))
                    for (int i = 0; i < packetBytes.Count; ++i)
                    {
                        // check if ip
                        if (packets[i].Ethernet.IpV4.IsValid)
                        {
                            IpV4Datagram ipv4 = packets[i].Ethernet.IpV4;

                            // for all tcp or udp packets
                            if (ipv4.Tcp.IsValid)
                            {
                                bool ipComp1 = (ipv4.Destination.ToString() == addressOne && ipv4.Source.ToString() == addressTwo);
                                bool ipComp2 = (ipv4.Source.ToString() == addressOne && ipv4.Destination.ToString() == addressTwo);
                                bool portComp = (ipv4.Tcp.SourcePort == desiredPort || ipv4.Tcp.DestinationPort == desiredPort);

                                if ((ipComp1 || ipComp2) && portComp)
                                {
                                    fs.Write(packetBytes[i], 0, packetBytes[i].Length);
                                }
                            }
                            else if (ipv4.Udp.IsValid)
                            {
                                bool ipComp1 = (ipv4.Destination.ToString() == addressOne && ipv4.Source.ToString() == addressTwo);
                                bool ipComp2 = (ipv4.Source.ToString() == addressOne && ipv4.Destination.ToString() == addressTwo);
                                bool portComp = (ipv4.Udp.SourcePort == desiredPort || ipv4.Udp.DestinationPort == desiredPort);

                                if ((ipComp1 || ipComp2) && portComp)
                                {
                                    fs.Write(packetBytes[i], 0, packetBytes[i].Length);
                                }
                            }
                        }
                        else if (packets[i].Ethernet.Arp.IsValid)
                        {
                            ArpDatagram arp = packets[i].Ethernet.Arp;

                            bool ipComp1 = (arp.TargetProtocolIpV4Address.ToString() == addressOne && arp.SenderProtocolIpV4Address.ToString() == addressTwo);
                            bool ipComp2 = (arp.TargetProtocolIpV4Address.ToString() == addressTwo && arp.SenderProtocolIpV4Address.ToString() == addressOne);
                            if (ipComp1 || ipComp2)
                            {
                                fs.Write(packetBytes[i], 0, packetBytes[i].Length);
                            }
                        }
                    }

            else if(fileNameParts[1] == "pcap")
            {

                using (PacketCommunicator communicator =
                allDevices[1].Open(65536,                                  // portion of the packet to capture
                                                                           // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))
                using (PacketDumpFile pdf = communicator.OpenDump(fileName))
                    for (int i = 0; i < packetBytes.Count; ++i)
                    {
                        // check if ip
                        if (packets[i].Ethernet.IpV4.IsValid)
                        {
                            IpV4Datagram ipv4 = packets[i].Ethernet.IpV4;

                            // for all tcp or udp packets
                            if (ipv4.Tcp.IsValid)
                            {
                                bool ipComp1 = (ipv4.Destination.ToString() == addressOne && ipv4.Source.ToString() == addressTwo);
                                bool ipComp2 = (ipv4.Source.ToString() == addressOne && ipv4.Destination.ToString() == addressTwo);
                                bool portComp = (ipv4.Tcp.SourcePort == desiredPort || ipv4.Tcp.DestinationPort == desiredPort);

                                if ((ipComp1 || ipComp2) && portComp)
                                {
                                    pdf.Dump(packets[i]);
                                }
                            }
                            else if (ipv4.Udp.IsValid)
                            {
                                bool ipComp1 = (ipv4.Destination.ToString() == addressOne && ipv4.Source.ToString() == addressTwo);
                                bool ipComp2 = (ipv4.Source.ToString() == addressOne && ipv4.Destination.ToString() == addressTwo);
                                bool portComp = (ipv4.Udp.SourcePort == desiredPort || ipv4.Udp.DestinationPort == desiredPort);

                                if ((ipComp1 || ipComp2) && portComp)
                                {
                                    pdf.Dump(packets[i]);
                                }
                            }
                        }
                        else if (packets[i].Ethernet.Arp.IsValid)
                        {
                            ArpDatagram arp = packets[i].Ethernet.Arp;

                            bool ipComp1 = (arp.TargetProtocolIpV4Address.ToString() == addressOne && arp.SenderProtocolIpV4Address.ToString() == addressTwo);
                            bool ipComp2 = (arp.TargetProtocolIpV4Address.ToString() == addressTwo && arp.SenderProtocolIpV4Address.ToString() == addressOne);
                            if (ipComp1 || ipComp2)
                            {
                                pdf.Dump(packets[i]);
                            }
                        }
                    }
            }
        }

        private void FlipFilterFieldVisibility() // show or hide filter textbox
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
        }

        private CougarPacket DetermineCorrectPacketFormat(Packet packet) // looks at the most recent packet and determines what protocol it carries
        {            
            CougarPacket cp = new CougarPacket();
            if (packet.Ethernet.IpV4.IsValid) {
                IpV4Datagram ipv4 = packet.Ethernet.IpV4;
                switch (ipv4.Protocol.ToString().ToLower())
                {
                    case "tcp":  // tcp packet received
                        TcpDatagram tcp = ipv4.Tcp;
                        cp.TimeStamp = packet.Timestamp.ToString("hh:mm:ss.fff");
                        cp.PacketNumber = packetNumber;
                        cp.Length = packet.Length;
                        cp.SourceAddress = ipv4.Source;
                        cp.DestAddress = ipv4.Destination;
                        cp.SrcPort = tcp.SourcePort;
                        cp.DstPort = tcp.DestinationPort;
                        cp.ChkSum = tcp.Checksum;
                        cp.AckNum = tcp.AcknowledgmentNumber;
                        cp.SeqNum = tcp.SequenceNumber;
                        cp.Payload = tcp.Payload;
                        cp.TCPFlags = tcp.ControlBits.ToString();
                        cp.getPayload();
                        
                        break;
                    case "udp":  // udp packet received
                        UdpDatagram udp = ipv4.Udp;
                        cp.TimeStamp = packet.Timestamp.ToString("hh:mm:ss.fff");
                        cp.PacketNumber = packetNumber;
                        cp.Length = packet.Length;
                        cp.SourceAddress = ipv4.Source;
                        cp.DestAddress = ipv4.Destination;
                        cp.SrcPort = udp.SourcePort;
                        cp.DstPort = udp.DestinationPort;
                        cp.Payload = udp.Payload;
                        cp.getPayload();

                        break;
                    case "internetcontrolmessageprotocol":  // icmp packet received
                        IcmpDatagram icmp = ipv4.Icmp;
                        cp.TimeStamp = packet.Timestamp.ToString("hh:mm:ss.fff");
                        cp.PacketNumber = packetNumber;
                        cp.Length = packet.Length;
                        cp.SourceAddress = ipv4.Source;
                        cp.DestAddress = ipv4.Destination;
                        cp.Payload = icmp.Payload;
                        cp.getPayload();
                        break;
                    default:
                        break;
                }
            }

            else if (packet.Ethernet.Arp.IsValid) // arp packet received
            {
                ArpDatagram arp = packet.Ethernet.Arp;
                cp.TimeStamp = packet.Timestamp.ToString("hh:mm:ss.fff");
                cp.PacketNumber = packetNumber;
                cp.Length = packet.Length;
                cp.SourceAddress = arp.SenderProtocolIpV4Address;
                cp.DestAddress = arp.TargetProtocolIpV4Address;
            }
        

            return cp;
        }

        private void PrintPacket(Packet packet) // main packet handler method (should probably be renamed to the original HandleLoadedPacket name to make more sense)
        {
            if (packet.Ethernet.IsValid)
            {
                ++packetNumber;
                CougarPacket cp = DetermineCorrectPacketFormat(packet);  // create new cougarpacket wtih proper protocol information related to this particular packet
                packets.Add(packet);
                if (cp.SourceAddress.ToString() != "0.0.0.0") 
                    this.Invoke((MethodInvoker)(() => // this is used to access the main form from within a separate thread (i.e. this capture thread)
                {
                    packetView.Items.Add(new ListViewItem(cp.ToPropertyArray)); // add packet info to listview (must be string array)
                    packetBytes.Add( Encoding.ASCII.GetBytes(cp.ToString() + "\n"));  
                    if (adjusted == false) // these next few lines are for resizing the listview items.  should only be called once after 10 packets have shown up
                    if ((packetNumber % 10 == 0))
                    {
                        packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                        adjusted = true;
                    }
                    if (chkAutoScroll.Checked)
                    {
                        packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                    }
                }));
            }
        }

        private void UpdateHexEditor()
        {
            if (/*packetView.SelectedIndices[0] < packetView.Items.Count &&*/ packetView.FocusedItem != null)
            {
                if (bvf.IsDisposed || multiWindowDisplay)
                    bvf = new ByteViewerForm();
                if (rawPacketViewDesired && packets.Count > 0)
                    bvf.setBytes(packets[packetView.FocusedItem.Index + 1].Buffer);
                else
                    bvf.setBytes(packetBytes[packetView.FocusedItem.Index + 1]);

                bvf.Show();
                bvf.TopMost = true;
            }
        }

        private void ResetNecessaryProperties()
        {
            txtFilterField.Text = defaultFilterField;
            packetNumber = 0;
            captFlag = true;
            packetView.Items.Clear();
            cfb.ClearFilterLists();
            packetBytes.Clear();
            protocolRequested = false;
            attributeRequested = false;
            packetNumber = 0;
            packets.Clear();
        }

        private void CapturePackets() // captures live packets coming OTA or OTW
        {
            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[this.deviceIndex];

            // Open the device
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                if (communicator.DataLink.Kind != DataLinkKind.Ethernet)
                {
                    Console.WriteLine("This program works only on Ethernet networks.");
                    return;
                }
                communicator.SetFilter(filter);

                while (captFlag)
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out Packet packet);
                  
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            break;
                        case PacketCommunicatorReceiveResult.Ok:
                            PrintPacket(packet); // call the main packet handler                        
                            break;
                        default:
                            throw new InvalidOperationException("The result " + result + " should never be reached here");
                    }
                }

                if (captureAndDumpRequested)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        string dumpFileName = DetermineFilePath(communicator);
                    }));
                }

            }
        }

        private void DumpPackets(PacketCommunicator communicator, string dumpFileName) // write pakets to dump file
        {
            using (PacketDumpFile pdf = communicator.OpenDump(dumpFileName))
                foreach (Packet p in packets)
                    pdf.Dump(p);
        }

        private string DetermineFilePath(PacketCommunicator pc = null)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Dump Files (*.pcap)| *.pcap| Text File (*.txt)| *.txt |All files (*.*)|*.*",
                FilterIndex = 0
            };

            string dumpFileName = "";
            
            switch (sfd.ShowDialog())
            {
                case DialogResult.OK:
                    if (sfd.FileName != "")
                    {
                        dumpFileName = sfd.FileName;  
                        if (sfd.FilterIndex == 1)
                        {

                            using (PacketCommunicator communicator = 
                                    allDevices[1].Open(65536,               // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                       PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                       1000))
                                DumpPackets(communicator, dumpFileName);
                        }
                        else if(sfd.FilterIndex == 2)
                        {
                            string[] filename = dumpFileName.Split('.');
                            DumpCapturedPackets(filename);
                        }                    
                    }

                    break;
                default:
                    MessageBox.Show("No File Path Found...");
                    dumpFileName = DetermineFilePath();
                    break;
            }

            return dumpFileName;
        }
       
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!captFlag) captFlag = true;

            SearchFormProperties();
            filter = TapFilterStringSource();
            txtFilterField.Text = filter;
            packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //capture packets     
            if ((numThreads < 1) && (deviceIndex != 0))
            {
                ++numThreads;
                new Thread(new ThreadStart(CapturePackets))
                {
                    IsBackground = true
                }.Start();
            }
        }

        //Signals for cease of capture function        
        /// Additionally, decreases number of running threads by one        
        private void BtnStop_Click(object sender, EventArgs e)
        {
            captFlag = false;
            if (numThreads > 0) --numThreads;
            filter = "";
            cfb.ClearFilterLists();
        }       
       
        private void BtnReset_Click(object sender, EventArgs e)
        {         
            //reset every control in the form to its default value
            foreach (Control c in Controls)
            {
                if (c is CheckBox ck) ck.Checked = false;   
                if (c is TextBox tb) tb.Text = "";  
                if (c is GroupBox gb1)
                {
                    foreach (Control subC1 in gb1.Controls)
                    {
                        if (subC1 is CheckBox subCk) subCk.Checked = false;
                        if (subC1 is TextBox subTb) subTb.Text = "";
                        if (subC1 is GroupBox gb2)
                        {
                            foreach (Control subC2 in gb2.Controls)
                            {
                                if (subC2 is CheckBox sub2Ck) sub2Ck.Checked = false;
                                if (subC2 is TextBox sub2Tb) sub2Tb.Text = "";                                
                            }
                        }
                    }
                }
            }
            
            ResetNecessaryProperties();
        }

        //Captures the selection of desired network interface       
        private void CmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInterfaces.Items != null)
            {
                deviceIndex = cmbInterfaces.SelectedIndex;
            }
        }              
       
        private void BtnSave_Click(object sender, EventArgs e) => DetermineFilePath();

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void SaveMenuItem_Click(object sender, EventArgs e) =>  DetermineFilePath();

        private void ExitMenuItem_Click(object sender, EventArgs e) => Close();

        private void FilterVisibilityItem_Click(object sender, EventArgs e)
        {
            FlipFilterFieldVisibility();
            filterVisibilityItem.Checked = txtFilterField.Visible;
        }

        private void PacketView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = packetView.FocusedItem.Index + 1;
            if (selected != lastSelectedIndex)
            {
                UpdateHexEditor();
                lastSelectedIndex = selected;
            }
        }

        private void btnShowData_Click(object sender, EventArgs e) => UpdateHexEditor();

        private void ShowFilterFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlipFilterFieldVisibility();
            showFilterFieldItem.Checked = txtFilterField.Visible;
        }

        private void CaptureAndDumpMenuItem_Click(object sender, EventArgs e)
        {
            captureAndDumpRequested = !captureAndDumpRequested;
            captureAndDumpMenuItem.Checked = captureAndDumpRequested;
        }

        private void RawPacketViewItem_Click(object sender, EventArgs e)
        {
            rawPacketViewDesired = !rawPacketViewDesired;
            rawPacketViewItem.Checked = rawPacketViewDesired;
            lastSelectedIndex = -1;
        }

        private void chkSrcIP1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSrcIP1.Checked) chkDstIP1.Checked = false;
        }

        private void chkDstIP1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDstIP1.Checked) chkSrcIP1.Checked = false;
        }

        private void chkSrcIP2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSrcIP2.Checked) chkDstIP2.Checked = false;
        }

        private void chkDstIP2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDstIP2.Checked) chkSrcIP2.Checked = false;
        }

        private void chkSrcPort1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSrcPort1.Checked) chkDstPort1.Checked = false;
        }

        private void chkDstPort1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDstPort1.Checked) chkSrcPort1.Checked = false;
        }

        private void chkSrcPort2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSrcPort2.Checked) chkDstPort2.Checked = false;
        }

        private void chkDstPort2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDstPort2.Checked) chkSrcPort2.Checked = false;
        }

        private void chkIPAND_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIPAND.Checked) chkIPOR.Checked = false;
        }

        private void chkIPOR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIPOR.Checked) chkIPAND.Checked = false;
        }

        private void chkPortAND_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPortAND.Checked) chkPortOR.Checked = false;
        }

        private void chkPortOR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPortOR.Checked) chkPortAND.Checked = false;
        }

        private void MultiWindowDisplayMenuItem_Click(object sender, EventArgs e)
        {
            multiWindowDisplay = !multiWindowDisplay;
            multiWindowDisplayMenuItem.Checked = multiWindowDisplay;
        }

        private void LoadDumpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clf = new CustomLoadForm();
            clf.ShowDialog();

            string loadPath = clf.DumpFileNameRequested;
            if (loadPath != "" && File.Exists(loadPath))
            {
                ResetNecessaryProperties();

                switch (Path.GetExtension(loadPath))
                {
                    case (".pcap"):
                        // Create the offline device
                        OfflinePacketDevice selectedDevice = new OfflinePacketDevice(loadPath);

                        // Open the capture file
                        using (PacketCommunicator communicator =
                            selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                                        // 65536 guarantees that the whole packet will be captured on all the link layers
                                                PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                1000))                                  // read timeout
                        {
                            // Read and dispatch packets until EOF is reached
                            communicator.ReceivePackets(0, PrintPacket);

                        }
                        break;

                    case (".txt"):
                        string currentPacket;
                        using (StreamReader reader = new StreamReader(loadPath))
                            while ((currentPacket = reader.ReadLine()) != null)
                            {
                                String[] packetAttributes = currentPacket.Split(',');
                                string timeStamp = "-";
                                int packetNumber = 0;
                                int length = 0;
                                string sourceIp = "0.0.0.0";
                                string destinationIp = "0.0.0.0";
                                int srcPort = 0;
                                int dstPort = 0;
                                int chkSum = 0;
                                uint seqNum = 0;
                                uint ackNum = 0;
                                string tcpFlags = "";
                                byte[] payloadBytes = new byte[400];

                                for (int i = 0; i < packetAttributes.Length; ++i)
                                {

                                    switch (i)
                                    {
                                        case 0:
                                            packetNumber = Convert.ToInt32(packetAttributes[i]);
                                            break;
                                        case 1:
                                            timeStamp = packetAttributes[i];
                                            break;
                                        case 2:
                                            length = Convert.ToInt32(packetAttributes[i]);
                                            break;
                                        case 3:
                                            sourceIp = packetAttributes[i];
                                            break;
                                        case 4:
                                            destinationIp = packetAttributes[i];
                                            break;
                                        case 5:
                                            srcPort = Convert.ToInt32(packetAttributes[i]);
                                            break;
                                        case 6:
                                            dstPort = Convert.ToInt32(packetAttributes[i]);
                                            break;
                                        case 7:
                                            chkSum = Convert.ToInt32(packetAttributes[i]);
                                            break;
                                        case 8:
                                            seqNum = Convert.ToUInt32(packetAttributes[i]);
                                            break;
                                        case 9:
                                            ackNum = Convert.ToUInt32(packetAttributes[i]);
                                            break;
                                        case 10:
                                            tcpFlags = packetAttributes[i];
                                            break;
                                        case 11:
                                            payloadBytes = ConvertHexStringToByteArray(packetAttributes[i]);
                                            break;
                                    }
                                }
                                CougarPacket cp = new CougarPacket(timeStamp, packetNumber, length, sourceIp,
                                                                    destinationIp, srcPort, dstPort, chkSum,
                                                                    seqNum, ackNum, tcpFlags, payloadData: payloadBytes);

                                packetView.Items.Add(new ListViewItem(cp.ToPropertyArray));
                                packetBytes.Add(Encoding.ASCII.GetBytes(cp.ToString() + "\n"));

                                if (chkAutoScroll.Checked && packetView.Items.Count > 0)
                                {
                                    packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                                }
                            }
                        break;
                }
            }
        }

        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            /*if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format( "The binary key cannot have an odd number of digits: {0}", hexString));
            }*/
            //Console.WriteLine("converting "+hexString);
            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber);
            }
            Console.WriteLine(HexAsBytes.Length);
            return HexAsBytes;
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            DetermineNetworkInterface();
            packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);    
           
        }
            
    }
}
