using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Linq;
using System.Drawing;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;

namespace SteppingStoneCapture
{
    public partial class CaptureForm : Form
    {
        private int deviceIndex;
        private IList<LivePacketDevice> allLivePacketDevices;
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
        private Tools.CougarFilterBuilder cfb;
        private int lastSelectedIndex = 0;
        private Boolean adjusted = false;
        private int maxFilePackets;
        private PacketDevice selectedDevice;
        private string sensorAddress;

        public CaptureForm()
        {
            //checkFirst();
            InitializeComponent();
            this.packetView.DoubleBuffered(true);
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
            cfb = new Tools.CougarFilterBuilder("or", "or");
            bvf = new ByteViewerForm();

            System.IO.StreamReader readingFile = new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\default.txt");
            string readingLine = readingFile.ReadLine();
            string[] values = readingLine.Split('=');
            maxFilePackets = Int32.Parse(values[1].Replace("\n", ""));

            readingLine = readingFile.ReadLine();
            values = readingLine.Split('=');
            sensorAddress = values[1].Replace("\n", "");
            selectedDevice = null;
        }

        private void checkFirst()
        {   ///////////////////////////////////////////////////////////////////
            /// check .Net framework version and other dependencies here... ///
            ///////////////////////////////////////////////////////////////////
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }

            MessageBox.Show("Checking for dependencies");
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
                                                    string ipString = (!chkIPNOT.Checked) ? "dst host " : "not dst host ";                                                    
                                                    cfb.AddIP(ipString + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    string ipString = (!chkIPNOT.Checked) ? "src host " : "not src host ";
                                                    cfb.AddIP(ipString + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtIpTwo":
                                                if (chkDstIP2.Checked)
                                                {
                                                    string ipString = (!chkIPNOT2.Checked) ? "dst host " : "not dst host ";
                                                    cfb.AddIP(ipString + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    string ipString = (!chkIPNOT2.Checked) ? "src host " : "not src host ";
                                                    cfb.AddIP(ipString + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtPortOne":
                                                if (chkDstPort1.Checked)
                                                {
                                                    string portString = (!chkPortNOT.Checked) ? "dst port " : "not dst port ";
                                                    cfb.AddPort(portString + tb.Text.ToLower());
                                                }
                                                else
                                                {
                                                    string portString = (!chkPortNOT.Checked) ? "src port " : "not src port ";
                                                    cfb.AddPort(portString + tb.Text.ToLower());
                                                }
                                                break;
                                            case "txtPortTwo":
                                                if (chkDstPort2.Checked)
                                                {
                                                    string portString = (!chkPort2NOT.Checked) ? "dst port " : "not dst port ";
                                                    cfb.AddPort(portString + tb.Text.ToLower());
                                                   
                                                }
                                                else
                                                {
                                                    string portString = (!chkPort2NOT.Checked) ? "src port " : "not src port ";
                                                    cfb.AddPort(portString + tb.Text.ToLower());
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

         ///<summary>
         /// Taps the correct source to create desired live capture filter 
         ///</summary>
         ///
        private string TapFilterStringSource()
        {
            string tapped;

            // if a protocol (TCP, UDP, IP...) or attribute (Ip Address/Port Number) was specified
            if (protocolRequested || attributeRequested)
            {
                tapped = cfb.FilterString;

            }
            // if a filter was supplied in the text area
            else if (txtFilterField.Text != "")
            {
                tapped = txtFilterField.Text;
            }
            // default to ip
            else
            {
                tapped = "ip";
            }
            return tapped;
        }

        //private void DumpCapturedPacketsToMotherTextFiles(string fileName) // dumps to text file
        //{
        //    Tools.FileHandler.SavePacketsToTextFile(fileName,packets,packetBytes,maxFilePackets,sensorAddress);
        //}

        private void FlipFilterFieldVisibility() // show or hide filter textbox
        {
            txtFilterField.Visible = !txtFilterField.Visible;
            lblFilterField.Visible = !lblFilterField.Visible;
        }

        private void PrintPacket(Packet packet) // main packet handler method (should probably be renamed to the original HandleLoadedPacket name to make more sense)
        {
            /*if (packet.DataLink.Kind.ToString().Equals("Ethernet"))
            {
                //Console.WriteLine(packet.Ethernet.EtherType);
                if (packet.Ethernet.EtherType.ToString().Equals("IpV4"))
                {
                    Console.WriteLine(packet.Ethernet.IpV4.Protocol);
                }
            }*/

            
            // if (packet.Ethernet.IsValid)
            {
                ++packetNumber;
                CougarPacket cp = CougarPacket.DetermineCorrectPacketFormat(packet, sensorAddress, packetNumber);  // create new cougarpacket wtih proper protocol information related to this particular packet
                packets.Add(packet);
                cougarpackets.Add(cp);
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
           // if (packet.Ethernet.IsValid)
            {
                ++packetNumber;

                Console.WriteLine("packet " + packetNumber);
                Console.WriteLine("time " + packet.Timestamp.ToLongTimeString());
                Console.WriteLine(packet.Ethernet.IsValid);
                Console.WriteLine(packet.IsValid);
                CougarPacket cp = CougarPacket.DetermineCorrectPacketFormat(packet, sensorAddress, packetNumber);  // create new cougarpacket wtih proper protocol information related to this particular packet
                cp.SensorIP = new IpV4Address(sensorIP);// create new cougarpacket wtih proper protocol information related to this particular packet
                packets.Add(packet);
                cougarpackets.Add(cp);
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
            catch (Exception) { }
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
            selectedDevice = allLivePacketDevices[this.deviceIndex];

            // Detect the correct sensor address
            foreach (DeviceAddress address in selectedDevice.Addresses)
            {
                if (!address.Address.ToString().Contains("Internet6"))
                {
                    string[] ipv4addy = address.Address.ToString().Split();
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
                    // Try to set the capture filter
                    communicator.SetFilter(filter);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Improper filter syntax!\nError info:\n" + e.Message, "Error!");
                    this.Invoke((MethodInvoker)(() =>
                    {
                        txtFilterField.Text = "";
                        txtIpOne.Text = "";
                        txtIpTwo.Text = "";
                        txtPortOne.Text = "";
                        txtPortTwo.Text = "";
                    }));
                    ResetNecessaryProperties();
                    captFlag = false;
                }

                // Capture Loop
                while (captFlag)
                {
                    // Try to get the next packet
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out Packet packet);

                    // Determine the result
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

                // save packets after capture if requested
                if (captureAndDumpRequested)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Tools.FileHandler.SavePackets(packets,packetBytes,maxFilePackets,sensorAddress);
                    }));
                }

            }
        }

        /// <summary>
        /// Click handler for start button. Initializes fields for capture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!captFlag) captFlag = true;

            SearchFormProperties();
            filter = TapFilterStringSource();
            txtFilterField.Text = filter;
            packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //capture packets     
            if ((numThreads < 1) && (deviceIndex >= 0))
            {
                ++numThreads;
                new Thread(new ThreadStart(CapturePackets))
                {
                    IsBackground = true
                }.Start();
            }
        }

        /// <summary>
        /// Signals for cease of capture function.        
        /// Additionally, decreases number of running threads by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            captFlag = false;
            if (numThreads > 0) --numThreads;
            filter = "";
            cfb.ClearFilterLists();
        }

        /// <summary>
        /// Signals reset of Capture Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset this capture?", "Reset?", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
               // Console.WriteLine(cmbInterfaces.SelectedIndex);
                deviceIndex = cmbInterfaces.SelectedIndex;
            }
            selectedDevice = allLivePacketDevices[cmbInterfaces.SelectedIndex];
        }

        private void BtnSave_Click(object sender, EventArgs e) => Tools.FileHandler.SavePackets(packets, packetBytes, maxFilePackets, sensorAddress);

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e) => Tools.FileHandler.SavePackets(packets, packetBytes, maxFilePackets, sensorAddress);

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
            Tools.TextInput nf = new Tools.TextInput(maxFilePackets.ToString());
            // nf.Show();
            nf.ShowDialog();
            Int32.TryParse(nf.InputtedText, out maxFilePackets);
        }

        private void MultiWindowDisplayMenuItem_Click(object sender, EventArgs e)
        {
            multiWindowDisplay = !multiWindowDisplay;
            multiWindowDisplayMenuItem.Checked = multiWindowDisplay;
        }

        private void incomingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sensor = "";
            if (cougarpackets.Count > 0)
                sensor = cougarpackets[0].SensorIP.ToString();
            // Console.WriteLine("This is the supposed sensor ip: "+cougarpackets[0].SensorIP.ToString());
            IOConnection ioc = new IOConnection(sensor, cougarpackets, packets, true);
            ioc.Text = "Save Incoming Connection....";
            foreach (Control c in ioc.Controls)
            {
                if (c is Label l && l.Name == "lblDescription")
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

        /*
         * Signals for program to load packets from user-selected file 
         */
        private void LoadPacketsFromFile_Click(object sender, EventArgs e)
        {
            Tools.FileHandler fileHandler = new Tools.FileHandler()
            {
                SensorIP = sensorAddress
            };

            fileHandler.LoadPacketsFromFiles();
            for (int i = 0; i < fileHandler.PacketsReadFromFile.Count; i++)
            {
                Packet p = fileHandler.PacketsReadFromFile[i];
                PrintPacket(p, fileHandler.SensorIP);
            }
        }

        /*
         *  Resizes the ComboBox Dropdown Menu To Fit Longest Interface Description
         * 
         */
        private void DynamicResizeInterfaceDropDown(object sender, EventArgs e)
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
            senderComboBox.MaximumSize = new Size(width + 20, senderComboBox.Height);
        }

        private void sensorAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.TextInput nf = new Tools.TextInput(sensorAddress);
            // nf.Show();
            nf.ShowDialog();
            sensorAddress = nf.InputtedText;
        }        

        private void contentThumbrprintToolStripMenuItem_Click(object sender, EventArgs e) => new Analysis.ContentThumbprint();

        private void crossoverToolStripMenuItem_Click(object sender, EventArgs e) => new Analysis.CrossOverPacket();

        private void lengthEstimationToolStripMenuItem_Click(object sender, EventArgs e) => new Analysis.ClusterPartition();

        private void MatchingAlgorithm_Click(object sender, EventArgs e)
        {
            var culture = new System.Globalization.CultureInfo("en-US");
            var algo = ((ToolStripMenuItem)sender).Name;
            Console.WriteLine(algo);
            if (culture.CompareInfo.IndexOf(algo,"first", System.Globalization.CompareOptions.IgnoreCase) >= 0)
            {
                new Analysis.PacketMatching.PacketMatchingForm(Analysis.PacketMatching.MatchingAlgorithm.FIRST_PAIR);
            }
            else if (culture.CompareInfo.IndexOf(algo, "conser", System.Globalization.CompareOptions.IgnoreCase) >= 0)
            {
                Console.WriteLine("con");
                new Analysis.PacketMatching.PacketMatchingForm(Analysis.PacketMatching.MatchingAlgorithm.CONSERVATIVE);
            }
            else if (culture.CompareInfo.IndexOf(algo, "greed", System.Globalization.CompareOptions.IgnoreCase) >= 0)
            {
                new Analysis.PacketMatching.PacketMatchingForm(Analysis.PacketMatching.MatchingAlgorithm.GREEDY_HEURISTIC);
            }
        }

        private void chkARP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timeThumbprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.TimeThumbprint.SessionTimeThumbprint tt = new Analysis.TimeThumbprint.SessionTimeThumbprint();
            tt.Show();
        }

        private void rAndomWalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis.RandomWalkDetection.RandomWalk randomWalk = new Analysis.RandomWalkDetection.RandomWalk();
            randomWalk.Show();
        }

        private void injectPacketToolStripMenuItem_Click(object sender, EventArgs e) => new Analysis.PacketInject(selectedDevice);        

        /*
* Loads the Step Function in a LAN program 
*/
        private void StepFunction_Click(object sender, EventArgs e) => new Analysis.StepFunctionForm();        

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            ListNetworkInterfaces();
            packetView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        /*
         * Function that will list network interface descriptions in the combo box drop down
         * 
         */
        private void ListNetworkInterfaces(int numTries = 5)
        {
            //Detect all interfaces
            allLivePacketDevices = LivePacketDevice.AllLocalMachine;
            string descript = "";
            
            string inactiveFormat = "{0,27} | {1}"; // format for interfaces that are not currently active
            string activeFormat = "* {0,17} | {1}"; // format for interfaces that are actively transmitting packets
            string Format = inactiveFormat;

            //Try the allotted number of times if no interfaces detected
            if (allLivePacketDevices.Count == 0)
            {
                if (numTries > 0)
                    ListNetworkInterfaces(--numTries);
            }

            // Describe each network interface
            for (int i = 0; i < allLivePacketDevices.Count; ++i)
            {
                // Determine the network interface for this interface
                LivePacketDevice livePacketDevice = allLivePacketDevices[i];
                NetworkInterface nic = LivePacketDeviceExtensions.GetNetworkInterface(livePacketDevice);

                string address = "";
                // Query system for description
                descript = nic.Description;
               
                if (nic != null)
                {
                    // Gather the unique ip properties of this interface
                    IPInterfaceProperties ipprops = nic.GetIPProperties();
                    UnicastIPAddressInformationCollection unicast = ipprops.UnicastAddresses;
                    
                    string lpdAddr = "";
                    string nicAddr = "";

                    // search the interfaces IP addresses for it's IPv4 address
                    foreach (UnicastIPAddressInformation uni in unicast)
                    {                        
                        nicAddr = uni.Address.ToString();

                        foreach (DeviceAddress addr in livePacketDevice.Addresses)
                        {
                            if (!addr.Address.ToString().Contains("Internet6"))
                            {
                                string[] ipv4addy = addr.Address.ToString().Split();
                                lpdAddr = ipv4addy[1];
                            }

                            if (nicAddr == lpdAddr)
                            {
                                address = nicAddr;
                                //needs tuning so active device will be default shown
                                                        
                                
                                // Format the description according to activity level
                                Format = inactiveFormat;                               
                                if (nic.OperationalStatus == OperationalStatus.Up)
                                {
                                    Format = activeFormat;
                                    //  ++activeIndex;
                                }                                
                            }
                        }
                    }                    
                }

                descript = String.Format(Format, address, descript);
                cmbInterfaces.Items.Add(descript);
            }
        }
    }
}


