using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using PcapDotNet.Packets;

namespace SteppingStoneCapture 
{
    public partial class IOConnection : Form
    { 
        private List<CougarPacket> cougarpackets;
        private List<Packet> packets;
        private List<CougarPacket> filteredCougarPackets;
        private List<Packet> filteredRawPackets;
        private bool incomingConnection; 
        private Dictionary<String, Packet> dropdownListItems;

        public bool IncomingConnection { get => incomingConnection; set => incomingConnection = value; }        

        public IOConnection()
        {
            InitializeComponent();
            //txtIpOne.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(); // need to get rid of this and use selected device ip address
        }
        public IOConnection(string sensorip)
        {
            InitializeComponent();
            txtIpOne.Text = sensorip;
        }

        public IOConnection(string sensorip, List<CougarPacket> cougarpackets, List<Packet> packets, bool incomingConnection = false)
        {
            InitializeComponent();
            txtIpOne.Text = sensorip;
            filteredCougarPackets = new List<CougarPacket>();
            filteredRawPackets = new List<Packet>();
            dropdownListItems = new Dictionary<string, Packet>();
            this.cougarpackets = cougarpackets;
            this.packets = packets;
            this.incomingConnection = incomingConnection;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// filters packets based on incoming or outgoing connection. Also allows user to filter on send, echo, or ack packets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void applyBtn_Click(object sender, EventArgs e) // this button filters connections on port# as well as filters on tcp flags
        {
            dropdownListItems.Clear();
            ConnectionCombo.Items.Clear();
            filteredCougarPackets.Clear();
            filteredRawPackets.Clear();
            bool result = int.TryParse(txtPort.Text, out int port); // validate port # input            
            if (result && port < 65535 && port > 0)
            {
                string key = "";
                if (incomingConnection) // if the user selected to filter on incoming connection
                {
                    for (int j=0; j<cougarpackets.Count; ++j) // begin loop to filter each packet
                    {
                        if (cougarpackets[j].DstPort == port && cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text) ||
                            cougarpackets[j].SrcPort == port && cougarpackets[j].SourceAddress.ToString().Equals(txtIpOne.Text)) // is it an incoming packet?
                        {                            
                            filteredCougarPackets.Add(cougarpackets[j]);
                            filteredRawPackets.Add(packets[j]);

                            /*if (filterStream(j, incomingConnection, port)) // check for additional filter criteron
                                continue;*/
                            if (!filterStream(j, incomingConnection, port)) // check for additional filter criteron
                            {
                                key = cougarpackets[j].SourceAddress + " - " + cougarpackets[j].SrcPort; // add ip and source port to combobox
                                if (!dropdownListItems.ContainsKey(key))
                                {
                                    dropdownListItems.Add(key, packets[j]);
                                    ConnectionCombo.Items.Add(key);
                                }
                            }

                            /*key = cougarpackets[j].SourceAddress + " - " + cougarpackets[j].SrcPort; // add ip and source port to combobox
                            if (!dropdownListItems.ContainsKey(key))
                            {
                                dropdownListItems.Add(key, packets[j]);
                                ConnectionCombo.Items.Add(key);
                            }*/
                        } // end incoming filter if statement
                    } // end for loop      
                }
                else // if the user selected to filter on outgoing connection
                {
                    for (int j = 0; j < cougarpackets.Count; ++j) // begin loop to filter each packet
                    {                        
                        if (cougarpackets[j].DstPort == port && cougarpackets[j].SourceAddress.ToString().Equals(txtIpOne.Text) ||
                            cougarpackets[j].SrcPort == port && cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text)) // is it an outgoing packet?
                        {                            
                            filteredCougarPackets.Add(cougarpackets[j]);
                            filteredRawPackets.Add(packets[j]);

                            if (!filterStream(j, incomingConnection, port))
                            {
                                key = (cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text)) ? cougarpackets[j].DestAddress + " - " + cougarpackets[j].DstPort : cougarpackets[j].DestAddress + " - " + cougarpackets[j].SrcPort;
                                if (!dropdownListItems.ContainsKey(key))
                                {
                                    dropdownListItems.Add(key, packets[j]);
                                    ConnectionCombo.Items.Add(key);
                                }
                            }                            
                        } // end outgoing filter if statement
                    } // end for loop                                            
                }
                if (ConnectionCombo.Items.Count < 1)
                {
                    ConnectionCombo.Text = "<EMPTY>";
                }

                else
                {
                    ConnectionCombo.Text = "Results Below...";                    
                    ConnectionCombo.Enabled = true;
                }
            }
            else // error message for entering wrong number
            {
                MessageBox.Show("Must enter a valid port number!", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        /// <summary>
        /// filters packets into send, echo, or ack packets based on TCP Flags, Src and Dst IP.  
        /// Returns true if packet matches filter critera.          
        /// </summary>
        /// <param name="int"></param>
        /// <param name="Boolean"></param>
        /// <param name="int"></param>        
        private Boolean filterStream(int j, Boolean incoming, int port) // if user selects send, ack or echo, this will remove unwanted packets from the list
        {                                                               // packets are added to the list before this is called, so if the packet matches the filter
                                                                        // it will be removed as the last item on the list
            if (AckChk.Checked) // remove anything that isn't strictly an ack packet
            {
                if (!cougarpackets[j].TCPFlags.Contains("Acknowledgment") || cougarpackets[j].TCPFlags.Contains("Push"))
                {
                    removeLastPacket();
                    return true;
                }
            }
            else if (sendChk.Checked)  // remove anything that isn't strictly a send packet
            {
                if (!cougarpackets[j].TCPFlags.Contains("Push")/* || cougarpackets[j].TCPFlags.Contains("Acknowledgment")*/)
                {
                    removeLastPacket();
                    return true;
                }   
                else if (incoming)
                {
                    if (cougarpackets[j].DstPort != port || !cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text))
                    {
                        removeLastPacket();
                        return true;
                    }
                }
                else if (!incoming)
                {
                    if (cougarpackets[j].DstPort != port || !cougarpackets[j].SourceAddress.ToString().Equals(txtIpOne.Text))
                    {
                        removeLastPacket();
                        return true;
                    }
                }
            }
            else if (EchoChk.Checked) // check to make sure this is a response/echo packet dependent on incoming/outgoing connection
            {
                if (!cougarpackets[j].TCPFlags.Contains("Push"))
                {
                    removeLastPacket();
                    return true;
                }
                else if (incoming)
                {
                    if (cougarpackets[j].SrcPort != port || !cougarpackets[j].SourceAddress.ToString().Equals(txtIpOne.Text))
                    {
                        removeLastPacket();
                        return true;
                    }
                }
                else if (!incoming)
                {
                    if (cougarpackets[j].SrcPort != port || !cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text))
                    {
                        removeLastPacket();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Removes last packet added to both filtered cougar packets and filtered raw packets
        /// </summary>
        
        private void removeLastPacket()
        {
            filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
            filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);            
        }

        private void DumpCapturedPacketsToMotherTextFiles(string fileName) // dumps to text file
        {
            string[] selectedConnection = ConnectionCombo.SelectedItem.ToString().Split('-');
            string[] file = fileName.Split('.');

            Tools.FileHandler.SavePacketsFromConnection(file, selectedConnection, IncomingConnection, filteredRawPackets, filteredCougarPackets, txtIpOne.Text);            
        }

        private string DetermineFilePath()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text File (*.txt)| *.txt |All files (*.*)|*.*",
                FilterIndex = 0
            };

            string dumpFileName = "";

            switch (sfd.ShowDialog())
            {
                case DialogResult.OK:
                    if (sfd.FileName != "")
                    {
                        dumpFileName = sfd.FileName;
                        DumpCapturedPacketsToMotherTextFiles(dumpFileName);                        
                    }
                    break;
                default:                    
                    break;
            }

            return dumpFileName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DetermineFilePath();
            this.Close();            
        }

        private void IOConnection_Load(object sender, EventArgs e)
        {

        }

        private void AckChk_CheckedChanged(object sender, EventArgs e)
        {
            if (AckChk.Checked)
            {
                EchoChk.Checked = false;
                sendChk.Checked = false;
            }
            btnOk.Enabled = false;
        }

        private void EchoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (EchoChk.Checked)
            {
                sendChk.Checked = false;
                AckChk.Checked = false;
            }
            btnOk.Enabled = false;
        }

        private void sendChk_CheckedChanged(object sender, EventArgs e)
        {
            if (sendChk.Checked)
            {
                AckChk.Checked = false;
                EchoChk.Checked = false;
            }
            btnOk.Enabled = false;
        }

        private void ConnectionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }
    }
}
