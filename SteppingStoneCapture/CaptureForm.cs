using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel.Design;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Icmp;

namespace SteppingStoneCapture
{   
    public partial class CaptureForm : Form
    {
        private int deviceIndex;
        private IList<LivePacketDevice> allDevices;
        private string defaultFilterField;
        private string filter;
        private IDictionary<Int32, byte[]> packetBytes;
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
        private int initialWindowHeight, initialWindowWidth;
        private List<int> initComponentHeights, initComponentWidths;

        public CaptureForm()
        {
            InitializeComponent();
            rawPacketViewItem.Checked = true;
            rand = new Random();
            deviceIndex = 0;
            defaultFilterField = "";
            filter = "";
            packetBytes = new Dictionary<Int32, byte[]>();
            packets = new List<Packet>();
            packetNumber = 0;
            captFlag = true;
            numThreads = 0;
            protocolRequested = false;
            attributeRequested = false;
            captureAndDumpRequested = captureAndDumpMenuItem.Checked;
            multiWindowDisplay = multiWindowDisplayMenuItem.Checked;
            rawPacketViewDesired = rawPacketViewItem.Checked;
            cfb = new CougarFilterBuilder();
            bvf = new ByteViewerForm();
            initialWindowHeight = this.Height;
            initialWindowWidth = this.Width;
            initComponentHeights = new List<int>();
            initComponentWidths = new List<int>();
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
                if (c is CheckBox chk)
                {
                    if (chk.Checked)
                    {
                        protocolRequested = true;
                        if (chk.Name != "chkAutoScroll")
                            cfb.AddToProtocolList(chk.Text);

                    }
                }
                else if (c is TextBox tb)
                {
                    if (tb.Text != "" && tb != txtFilterField)
                    {
                        attributeRequested = true;
                        switch (tb.Name)
                        {
                            case "txtSrcIP":
                                cfb.AddToAttributeList("src host " + tb.Text.ToLower());
                                break;
                            case "txtDestIP":
                                cfb.AddToAttributeList("dst host " + tb.Text.ToLower());
                                break;
                            case "txtSrcPort":
                                cfb.AddToAttributeList("src port " + tb.Text);
                                break;
                            case "txtDestPort":
                                cfb.AddToAttributeList("dst port " + tb.Text);
                                break;
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

        private void DumpCapturedPackets(string fileName)
        {
            if (packetBytes.Values.Count > 0)
            {

                foreach (byte[] barr in packetBytes.Values)
                {
                    File.AppendAllText(fileName, Encoding.ASCII.GetString(barr));
                }
            }
        }

        private void FlipFilterFieldVisibility()
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
        }

        private CougarPacket DetermineCorrectPacketFormat(Packet packet, IpV4Datagram ipv4, IpV4Protocol protocol)
        {
            CougarPacket cp;
            switch (protocol.ToString().ToLower())
            {
                case "tcp":
                    //tcp packet received
                    TcpDatagram tcp = ipv4.Tcp;
                    cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                               packetNumber,
                                               packet.Length,
                                               ipv4.Source.ToString(),
                                               ipv4.Destination.ToString(),
                                               tcp.SourcePort,
                                               tcp.DestinationPort,
                                               tcp.Checksum,
                                               tcp.SequenceNumber,
                                               tcp.AcknowledgmentNumber,
                                               tcp.ControlBits.ToString())
                    {
                        Payload = tcp.Payload                        
                    };
                    cp.getPayload();
                    
                    break;
                case "udp":
                    //udp packet received
                    UdpDatagram udp = ipv4.Udp;
                    cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                               packetNumber,
                                               packet.Length,
                                               ipv4.Source.ToString(),
                                               ipv4.Destination.ToString(),
                                               udp.SourcePort,
                                               udp.DestinationPort)
                    {
                        Payload = udp.Payload
                    };
                    cp.getPayload();
                    
                    break;
                case "internetcontrolmessageprotocol":
                    IcmpDatagram icmp = ipv4.Icmp;
                    cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                               packetNumber,
                                               packet.Length,
                                               ipv4.Source.ToString(),
                                               ipv4.Destination.ToString())
                    {
                        Payload = icmp.Payload
                    };
                    cp.getPayload();
                    break;
                default:
                    throw new Exception("not udp, tcp, or icmp packet; protocol: " + protocol);

            }

            return cp;
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
        }

        private void LoadDumpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clf = new CustomLoadForm();
            clf.ShowDialog();

            string loadPath = clf.DumpFileNameRequested;
            if (loadPath != "")
            {
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
                    communicator.ReceivePackets(0, HandleLoadedPacket);

                }
            }

        }

        private void HandleLoadedPacket(Packet packet)
        {            
            int prevInd = 0;

            IpV4Datagram ipv4 = packet.Ethernet.IpV4;
            if (ipv4.IsValid)
            {
                IpV4Protocol protocol = ipv4.Protocol;
                CougarPacket cp;

                ++packetNumber;
                cp = DetermineCorrectPacketFormat(packet, ipv4, protocol);

                packets.Add(packet);
                this.Invoke((MethodInvoker)(() =>
                {
                    packetView.Items.Add(new ListViewItem(cp.ToPropertyArray));
                    packetBytes.Add(packetNumber, Encoding.ASCII.GetBytes(cp.ToString() + "\n"));

                    ++prevInd;
                    if (chkAutoScroll.Checked /*&& prevInd > 12*/)
                    {
                        packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                        prevInd = 0;
                    }
                }));
            }
        }       

        private void CapturePackets()
        {
            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[this.deviceIndex];
            int prevInd = 0;

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

                Console.WriteLine(filter);
                while (captFlag)
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out Packet packet);
                  
                    
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            // Timeout elapsed
                            break;
                        case PacketCommunicatorReceiveResult.Ok:
                            IpV4Datagram ipv4 = packet.Ethernet.IpV4;
                            

                            if (ipv4.IsValid)
                            {
                                IpV4Protocol protocol = ipv4.Protocol;

                                CougarPacket cp;
                                ++packetNumber;
                                cp = DetermineCorrectPacketFormat(packet, ipv4, protocol);                                

                                packetBytes.Add(packetNumber, Encoding.ASCII.GetBytes(cp.ToString() + "\n"));

                                this.Invoke((MethodInvoker)(() =>
                                {
                                    packets.Add(packet);
                                    packetView.Items.Add(new ListViewItem(cp.ToPropertyArray));

                                    //++prevInd;
                                    if (chkAutoScroll.Checked/* && prevInd > 12*/)
                                    {
                                        packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                                        //prevInd = 0;
                                    }
                                }));
                                                                   
                            }
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

        private void DumpPackets(PacketCommunicator communicator, string dumpFileName)
        {
            using (PacketDumpFile pdf = communicator.OpenDump(dumpFileName))
                foreach (Packet p in packets)
                    pdf.Dump(p);
        }

        private string DetermineFilePath(PacketCommunicator pc = null)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            };
            
            sfd.Filter = "Dump Files (*.pcap)| *.pcap| Text File (*.txt)| *.txt |All files (*.*)|*.*";
            sfd.FilterIndex = 0;


            string dumpFileName = sfd.FileName;
            
            switch (sfd.ShowDialog())
            {
                case DialogResult.OK:
                    MessageBox.Show(sfd.FilterIndex.ToString());
                    if (sfd.FileName != "")
                    {
                        dumpFileName = sfd.FileName;  
                        if (sfd.FilterIndex == 1)
                        {

                            using (PacketCommunicator communicator =
                allDevices[1].Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))
                                DumpPackets(communicator, dumpFileName+".pcap");
                        }
                        else if(sfd.FilterIndex == 2)
                        {
                            DumpCapturedPackets(dumpFileName+".txt");
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
        /// <summary>
        /// Signals for program to cease capture
        /// </summary>
        /// <remarks>
        /// Additionally, decreases number of running threads by one
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                else if (c is TextBox tb) tb.Text = "";                
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

        private void UpdateHexEditor()
        {
            if (packetView.FocusedItem != null)
            {
                if (bvf.IsDisposed || multiWindowDisplay)
                    bvf = new ByteViewerForm();
                if (rawPacketViewDesired)
                    bvf.setBytes(packets[packetView.FocusedItem.Index + 1].Buffer);
                else
                    bvf.setBytes(packetBytes[packetView.FocusedItem.Index + 1]);

                bvf.Show();
                bvf.TopMost = true;
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

        private void CaptureForm_ResizeBegin(object sender, EventArgs e)
        {
            initialWindowHeight = this.Height;
            initialWindowWidth = this.Width;

            foreach (Control c in this.Controls)
            {
                initComponentHeights.Add(c.Height);
                initComponentWidths.Add(c.Width);
            }
        }

        private void CaptureForm_ResizeEnd(object sender, EventArgs e)
        {
            int finalWindowHeight = this.Height;
            int finalWindowWidth = this.Width;



            foreach (Control c in this.Controls)
            {

            }
        }

        private void rawPacketViewItem_Click(object sender, EventArgs e)
        {
            rawPacketViewDesired = !rawPacketViewDesired;
            rawPacketViewItem.Checked = rawPacketViewDesired;
            lastSelectedIndex = -1;
        }

        private void MultiWindowDisplayMenuItem_Click(object sender, EventArgs e)
        {
            multiWindowDisplay = !multiWindowDisplay;
            multiWindowDisplayMenuItem.Checked = multiWindowDisplay;
        }

        private void CaptureForm_Load(object sender, EventArgs e) => DetermineNetworkInterface();
    }
}
