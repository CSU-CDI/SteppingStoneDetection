using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System.IO;

namespace SteppingStoneCapture // !!!!!!!!!!!!!!!!! need to make sure that we check for the source port to identify a specific connection !!!!!!!!!!!!!!!!!!!!!!!!!!!
{
    public partial class IOConnection : Form
    {
        //private bool applyPort = false;
        private List<CougarPacket> cougarpackets;
        private List<Packet> packets;
        private List<CougarPacket> filteredCougarPackets; // needs to be dictionary; use ContainsKey() to eliminate duplicates
        private List<Packet> filteredRawPackets; // needs to be dictionary  ^^^
        private bool incomingConnection; 
        private Dictionary<String, Packet> dropdownListItems;

        public bool IncomingConnection { get => incomingConnection; set => incomingConnection = value; }        

        public IOConnection()
        {
            InitializeComponent();
            txtIpOne.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(); // need to get rid of this and use selected device ip address
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
        }

        private void applyBtn_Click(object sender, EventArgs e) // this button filters connections on port# as well as filters on tcp flags
        {            
            bool result = int.TryParse(txtPort.Text, out int port);            
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

                            if (filterStream(j, incomingConnection, port))
                                continue;

                            key = cougarpackets[j].SourceAddress + " - " + cougarpackets[j].SrcPort;
                            if (!dropdownListItems.ContainsKey(key))
                            {
                                dropdownListItems.Add(key, packets[j]);
                                ConnectionCombo.Items.Add(key);
                            }
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

                            if (filterStream(j, incomingConnection, port))
                                continue;

                            key = cougarpackets[j].DestAddress + " - " + cougarpackets[j].SrcPort;
                            if (!dropdownListItems.ContainsKey(key))
                            {
                                dropdownListItems.Add(key, packets[j]);
                                ConnectionCombo.Items.Add(key);
                            }
                        } // end outgoing filter if statement
                    } // end for loop
                }
                btnOk.Enabled = true;
                ConnectionCombo.Enabled = true;                
            }
            else
            {
                MessageBox.Show("Must enter a valid port number!", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private Boolean filterStream(int j, Boolean incoming, int port)
        {
            if (AckChk.Checked)
            {
                if (!cougarpackets[j].TCPFlags.Contains("Acknowledgment") || cougarpackets[j].TCPFlags.Contains("Push"))
                {
                    filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
                    filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);
                    return true;
                }
            }
            else if (sendChk.Checked) 
            {
                if (!cougarpackets[j].TCPFlags.Contains("Push") || cougarpackets[j].TCPFlags.Contains("Acknowledgment"))
                {
                    filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
                    filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);
                    return true;
                }                
            }
            else if (EchoChk.Checked)
            {
                if (!cougarpackets[j].TCPFlags.Contains("Push"))
                {
                    filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
                    filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);
                    return true;
                }
                else if (incoming)
                {
                    if (cougarpackets[j].SrcPort != port || !cougarpackets[j].SourceAddress.ToString().Equals(txtIpOne.Text))
                    {
                        filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
                        filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);
                        return true;
                    }
                }
                else if (!incoming)
                {
                    if (cougarpackets[j].SrcPort != port || !cougarpackets[j].DestAddress.ToString().Equals(txtIpOne.Text))
                    {
                        filteredCougarPackets.RemoveAt(filteredCougarPackets.Count - 1);
                        filteredRawPackets.RemoveAt(filteredRawPackets.Count - 1);
                        return true;
                    }
                }
            }
            return false;
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
                    DialogResult res = MessageBox.Show("No File Path Found...Try Again?", "Error!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        dumpFileName = DetermineFilePath();
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


    }
}
