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
        //private ByteViewerForm bvf;
        //private ByteViewerForm newbvf;
        private Int32 packetNumber;
        private bool captFlag;
        private int numThreads;
        private Boolean protocolRequested, attributeRequested;
        private volatile Boolean captureAndDumpRequested;
        private CougarFilterBuilder cfb;
        private Random rand;

        


        public CaptureForm()
        {
            InitializeComponent();
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
            captureAndDumpRequested = false;
            cfb = new CougarFilterBuilder();
            //bvf = new ByteViewerForm();
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

        private void DumpCapturedPackets()
        {
            string fileName = string.Format(@"C:\Users\[0}\Documents\{1}_captureFile.txt",
                                                        Environment.UserName,
                                                        DateTime.Now.ToString("dd-MM-yyyy_hhmmssffff"));

            foreach (byte[] barr in packetBytes.Values)
            {
                File.AppendAllText(fileName, Encoding.ASCII.GetString(barr));
            }

            packetBytes.Clear();
        }

        private void FlipFilterFieldVisibility()
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
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

        private void HandleLoadedPacket(Packet packet)
        {
            CougarPacket cp;
            int prevInd = 0;

            IpV4Datagram ipv4 = packet.Ethernet.IpV4;
            if (ipv4.IsValid)
            {
                IpV4Protocol i = ipv4.Protocol;
                cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                                                   ++packetNumber,
                                                                   packet.Length,
                                                                   ipv4.Source.ToString(),
                                                                   ipv4.Destination.ToString());
                packets.Add(packet);
                this.Invoke((MethodInvoker)(() =>
                {
                    packetView.Items.Add(new ListViewItem(cp.ToPropertyArray));
                    packetBytes.Add(packetNumber, Encoding.ASCII.GetBytes(cp.ToString() + "\n"));

                    ++prevInd;
                    if (chkAutoScroll.Checked && prevInd > 12)
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
                communicator.SetFilter(filter);
                string dumpFileName = String.Format("C:\\Users\\{0}\\Documents\\{1}.pcap",
                                                     Environment.UserName,
                                                     DateTime.Now.ToString("dd-MM-yyyy_hhmmssffff"));
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
                                IpV4Protocol i = ipv4.Protocol;
                                Console.WriteLine(i);

                                CougarPacket cp = new CougarPacket(packet.Timestamp.ToString("hh:mm:ss.fff"),
                                                                   packetNumber,
                                                                   packet.Length,
                                                                   ipv4.Source.ToString(),
                                                                   ipv4.Destination.ToString());
                                packetNumber++;

                                //packetInfo = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                                packetBytes.Add(packetNumber, Encoding.ASCII.GetBytes(cp.ToString() + "\n"));

                                this.Invoke((MethodInvoker)(() =>
                                {
                                    packetView.Items.Add(new ListViewItem(cp.ToPropertyArray));

                                    ++prevInd;
                                    if (chkAutoScroll.Checked && prevInd > 12)
                                    {
                                        packetView.Items[packetView.Items.Count - 1].EnsureVisible();
                                        prevInd = 0;
                                    }
                                }));
                                if (captureAndDumpRequested)
                                {
                                    packets.Add(packet);
                                }
                            }
                            break;
                        default:
                            throw new InvalidOperationException("The result " + result + " should never be reached here");
                    }
                }
                if (captureAndDumpRequested)
                {
                    using (PacketDumpFile pdf = communicator.OpenDump(dumpFileName))
                        foreach (Packet p in packets)
                            pdf.Dump(p);
                }
                    
            }
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
       
        private void BtnSave_Click(object sender, EventArgs e) => DumpCapturedPackets();

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void SaveMenuItem_Click(object sender, EventArgs e) => DumpCapturedPackets();

        private void ExitMenuItem_Click(object sender, EventArgs e) => Close();

        private void FilterVisibilityItem_Click(object sender, EventArgs e) => FlipFilterFieldVisibility();

        private void dumpPacketsDuringCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            captureAndDumpRequested = !captureAndDumpRequested;
        }

        /*private void packetView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ByteViewerForm newbvf = new ByteViewerForm();
            newbvf.setBytes(packetBytes[packetView.FocusedItem.Index + 1]);
            newbvf.Show();
            newbvf.TopMost = true;            
            //bvf.Visible = true;
            //bvf.Activate();
            //int index = packetView.FocusedItem.Index + 1;
            //bvf.setBytes(packetBytes[index]);            
        } */

        private void btnShowData_Click(object sender, EventArgs e)
        {
            ByteViewerForm newbvf = new ByteViewerForm();
            newbvf.setBytes(packetBytes[packetView.FocusedItem.Index + 1]);
            newbvf.Show();
            newbvf.TopMost = true;
        }

        private void CaptureForm_Load(object sender, EventArgs e) => DetermineNetworkInterface();
    }
}
