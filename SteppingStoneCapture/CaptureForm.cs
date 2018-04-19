using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
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
        private int deviceIndex;
        private IList<LivePacketDevice> allDevices;
        private string defaultFilterField;
        private string filter;
        private IList<byte[]> packetBytes;
        private List<CougarPacket> cougarpackets;
        private List<Packet> packets;
        private ByteViewerForm bvf;
        private Int32 packetNumber;
        private bool captFlag;
        private int numThreads;
        private Boolean protocolRequested, attributeRequested;
        private volatile Boolean captureAndDumpRequested, multiWindowDisplay, rawPacketViewDesired;
        private CougarFilterBuilder cfb;
        private int lastSelectedIndex = 0;
        private Boolean adjusted = false;
        private int maxFilePackets;
        private PacketDevice selectedDevice;
        private string sensorAddress;

        public CaptureForm()
        {
            InitializeComponent();
            rawPacketViewItem.Checked = true;
            deviceIndex = 0;
            defaultFilterField = "";
            sensorAddress = "0.0.0.0";
            filter = "";
            packetBytes = new List<byte[]>();
            packets = new List<Packet>();
            cougarpackets = new List<CougarPacket>();
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

            System.IO.StreamReader readingFile = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\default.txt");
            string readingLine = readingFile.ReadLine();
            string[] values = readingLine.Split('=');
            maxFilePackets = Int32.Parse(values[1].Replace("\n", ""));

        }        

        private void DescribeInterfaceDevice(int offsetForWindowsMachines, LivePacketDevice device)
        {
            string ipAddress = "";
            foreach (DeviceAddress address in device.Addresses)
            {
                if (!address.Address.ToString().Contains("Internet6"))
                {
                    string temp = address.Address.ToString();
                    string[] ipv4addy = temp.Split();
                    ipAddress = ipv4addy[1];
                }
            }

            if (device.Description != null)
                if (device.Description.ToLower().Contains("\'microsoft\'"))
                    cmbInterfaces.Items.Add(ipAddress + " - Wireless Connector");
                else if (device.Description.ToLower().Contains("ethernet"))
                    cmbInterfaces.Items.Add(ipAddress + " - Ethernet Connector");
                else
                    cmbInterfaces.Items.Add(ipAddress + " - " + device.Description.Substring(offsetForWindowsMachines));
            else
                cmbInterfaces.Items.Add(ipAddress + " - Description Unavailable");
        }

        private void SearchFormProperties()
        {
            foreach (Control c in Controls)
            {

                if (c is GroupBox gb)
                {
                    foreach (Control c1 in gb.Controls)
                    {
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

        private void DumpCapturedPacketsToMotherTextFiles(string fileName) // dumps to text file
        {
            int indexF = 0;
            int countP = 0;
            string[] file = fileName.Split('.');
            //fileName.
            if (packetBytes.Count > 0)
            {
                //open file stream for mother file and raw mother file
                FileStream fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                StreamWriter fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);

                int i = 0;
                foreach (byte[] barr in packetBytes)
                {
                    if (countP % maxFilePackets == 0 && countP != 0)
                    {
                        indexF++;
                        fs.Close();
                        fsRaw.Close();
                        fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                        fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);
                    }
                    countP++;
                    fs.Write(barr, 0, barr.Length);
                    fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(packets[i].Buffer).Replace("-",""), packets[i].Timestamp.ToString("hh:mm:ss.fff"), packets[i].DataLink,packets[i].OriginalLength));
                    ++i;
                }

                fs.Close();
                fsRaw.Close();
            }

        }

        private void FlipFilterFieldVisibility() // show or hide filter textbox
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
        }

        private CougarPacket DetermineCorrectPacketFormat(Packet packet) // looks at the most recent packet and determines what protocol it carries
        {
            CougarPacket cp = new CougarPacket
            {
                TimeStamp = packet.Timestamp.ToString("hh:mm:ss.fff"),
                PacketNumber = packetNumber,
                Length = packet.Length,
                SensorIP = new IpV4Address(sensorAddress)
            };

            if (packet.Ethernet.IpV4.IsValid)
            {
                IpV4Datagram ipv4 = packet.Ethernet.IpV4;
                cp.SourceAddress = ipv4.Source;
                cp.DestAddress = ipv4.Destination;

                switch (ipv4.Protocol.ToString().ToLower())
                {
                    case "tcp":  // tcp packet received
                        TcpDatagram tcp = ipv4.Tcp;
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
                        cp.SrcPort = udp.SourcePort;
                        cp.DstPort = udp.DestinationPort;
                        cp.Payload = udp.Payload;
                        cp.getPayload();
                        break;

                    case "internetcontrolmessageprotocol":  // icmp packet received
                        IcmpDatagram icmp = ipv4.Icmp;
                        cp.Payload = icmp.Payload;
                        cp.getPayload();
                        break;
                    default:
                        //throw new Exception("not udp, tcp, or icmp packet; protocol: " + ipv4.Protocol);
                        break;
                }
            }

            else if (packet.Ethernet.Arp.IsValid) // arp packet received
            {
                ArpDatagram arp = packet.Ethernet.Arp;                
                cp.SourceAddress = arp.SenderProtocolIpV4Address;
                cp.DestAddress = arp.TargetProtocolIpV4Address;
            }

            cougarpackets.Add(cp);

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
                    packetBytes.Add(Encoding.ASCII.GetBytes(cp.ToString() + "\n"));
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

        private void PrintPacket(Packet packet, string sensorIP) // main packet handler method (should probably be renamed to the original HandleLoadedPacket name to make more sense)
        {
            if (packet.Ethernet.IsValid)
            {
                ++packetNumber;
                CougarPacket cp = DetermineCorrectPacketFormat(packet);
                cp.SensorIP = new IpV4Address(sensorIP);// create new cougarpacket wtih proper protocol information related to this particular packet
                packets.Add(packet);
                if (cp.SourceAddress.ToString() != "0.0.0.0")
                    this.Invoke((MethodInvoker)(() => // this is used to access the , main form from within a separate thread (i.e. this capture thread)
                    {
                        packetView.Items.Add(new ListViewItem(cp.ToPropertyArray)); // add packet info to listview (must be string array)
                        packetBytes.Add(Encoding.ASCII.GetBytes(cp.ToString() + "\n"));
                        if (!adjusted) // these next few lines are for resizing the listview items.  only called once after 10 packets have shown up
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
            try
            {
                if (packetView.FocusedItem.Index >= 0 && packetView.FocusedItem.Index < packetView.Items.Count && packetView.FocusedItem != null)
                {
                    if (bvf.IsDisposed || multiWindowDisplay)
                        bvf = new ByteViewerForm();
                    if (rawPacketViewDesired && packets.Count > 0)
                        bvf.setBytes(packets[packetView.FocusedItem.Index].Buffer);
                    else
                        bvf.setBytes(packetBytes[packetView.FocusedItem.Index]);

                    bvf.Show();
                    bvf.TopMost = true;
                }
            }
            catch (Exception e) { }
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
            packets.Clear();
            cougarpackets.Clear();
        }

        private void CapturePackets() // captures live packets coming OTA or OTW
        {

            // Take the selected adapter
            selectedDevice = allDevices[this.deviceIndex];
        
            foreach (DeviceAddress address in selectedDevice.Addresses)
            {                
                if (!address.Address.ToString().Contains("Internet6"))
                {                   
                    string[] ipv4addy = address.Address.ToString().Split();
                    //Console.WriteLine(ipv4addy[1]);
                    sensorAddress = ipv4addy[1];
                }                     
            }

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
                try
                {
                    //Console.WriteLine("Filter: " + filter);
                    communicator.SetFilter(filter);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Improper filter syntax!\nError info:\n" + e);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        txtFilterField.Text = "";
                        txtIpOne.Text = "";
                        txtIpTwo.Text = "";
                        txtPortOne.Text = "";
                        txtPortTwo.Text = "";
                    }));                    
                }
                

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

            string dumpFileName = sfd.FileName;

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
                        else if (sfd.FilterIndex == 2)
                        {
                            DumpCapturedPacketsToMotherTextFiles(dumpFileName);
                        }
                    }

                    break;
                default:
                    DialogResult res = MessageBox.Show("No File Path Found...Try Again?", "Error!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
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
            if (MessageBox.Show("Are you sure you want to reset this capture?","Reset?", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?","Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e) => DetermineFilePath();

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void FilterVisibilityItem_Click(object sender, EventArgs e)
        {
            FlipFilterFieldVisibility();
            filterVisibilityItem.Checked = txtFilterField.Visible;
        }

        private void PacketView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = packetView.FocusedItem.Index;
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

        private void numberOfPactketsPerFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberPacketsForm nf = new NumberPacketsForm(maxFilePackets);
            // nf.Show();
            nf.ShowDialog();
            maxFilePackets = nf.NumPackets;
        }

        private void MultiWindowDisplayMenuItem_Click(object sender, EventArgs e)
        {
            multiWindowDisplay = !multiWindowDisplay;
            multiWindowDisplayMenuItem.Checked = multiWindowDisplay;
        }       

        private void filterStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOStream ios = new IOStream();
            ios.Show();
        }

        private void incomingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sensor = "";
            if (cougarpackets.Count > 0)
                sensor = cougarpackets[0].SensorIP.ToString();
            else
                sensor = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            // Console.WriteLine("This is the supposed sensor ip: "+cougarpackets[0].SensorIP.ToString());
            IOConnection ioc = new IOConnection(sensor, cougarpackets,packets,true);
            ioc.Text = "Save Incoming Connection....";
            foreach (Control c in ioc.Controls)
            {
                if (c is Label l && l.Name=="lblDescription")
                {
                    l.Text = "Filter Capture for Incoming Connection...";
                }
            }

            ioc.IncomingConnection = true;
            ioc.Show();           
        }

        private void outgoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sensor = "";
            if (cougarpackets.Count > 0)
                sensor = cougarpackets[0].SensorIP.ToString();
            else
                sensor = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            // Console.WriteLine("This is the supposed sensor ip: " + cougarpackets[0].SensorIP.ToString());
            IOConnection ioc = new IOConnection(sensor, cougarpackets, packets);
            ioc.Text = "Save Outgoing Connection....";
            foreach (Control c in ioc.Controls)
            {
                if (c is Label l && l.Name == "lblDescription")
                {
                    l.Text = "Filter Capture for Outgoing Connection...";
                }
            }
            ioc.Show();           
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
                        string rawLoadPath = "";
                        string[] path = loadPath.Split('.');
                        if (!loadPath.Contains("_raw"))
                            rawLoadPath = path[0] + "_raw." + path[1];
                        else
                        {
                            rawLoadPath = loadPath;
                            loadPath = loadPath.Replace("_raw", "");
                        }

                        using (StreamReader raw_reader = new StreamReader(rawLoadPath))
                            using (StreamReader fs = new StreamReader(File.OpenRead(loadPath)))
                            {
//int currentIndex = 0;

                                while ((currentPacket = raw_reader.ReadLine()) != null)
                                {
                                    string[] packetInformation = currentPacket.Split(',');
                                    DateTime dt;
                                    dt = DateTime.Parse(packetInformation[1]);
                                    DataLink dl = new DataLink(DataLinkKind.Ethernet);
                                    UInt32.TryParse(packetInformation[3], out uint x);
                                    byte[] packetData = ConvertHexStringToByteArray(packetInformation[0].Replace("-", ""));
                                    if ((currentPacket = fs.ReadLine()) != null)
                                    {
                                        Packet p = new Packet(packetData, dt, dl, x);
                                                                          
                                        string[] packetInfo = currentPacket.Split(',');
                                        PrintPacket(p, packetInfo[packetInfo.Length - 1]);
                                       // ++currentIndex;
                                    }
                                }
                            };
                            break;
                }
            }
        }

        private void cmbInterfaces_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void newCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureForm ncf = new CaptureForm();
            ncf.Show();

        }

        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
            }
            return HexAsBytes;
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            DetermineNetworkInterface();
            packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                    int offsetForWindowsMachines = 0;
                    LivePacketDevice device = allDevices[i];
                    DescribeInterfaceDevice(offsetForWindowsMachines, device);
                }
            }
        }

    }
}
