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

namespace SteppingStoneCapture
{
    public partial class IOConnection : Form
    {
        private bool applyPort = false;
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
            txtIpOne.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
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
            
            /*foreach (CougarPacket cp in cougarpackets)
                Console.WriteLine(cp.ToString());*/
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {            
            bool result = int.TryParse(txtPort.Text, out int port);
            //Console.WriteLine("apply port result: "+result + " " + port + " " + incomingConnection);
            if (result && port < 65535 && port > 0)
            {
                string key = "";
                if (incomingConnection) // if the user selected to filter on incoming connection
                {
                    // write code to filter packet lists here
                    int i = 0;                    
                    foreach (CougarPacket cp in cougarpackets)
                    {
                        //Console.WriteLine(cp.ToString());
                        if (cp.DstPort == port && cp.DestAddress.ToString().Equals(txtIpOne.Text))
                        {
                            filteredCougarPackets.Add(cp);
                            filteredRawPackets.Add(packets[i]);
                            key = cp.SourceAddress + " - " + cp.SrcPort;
                            if (!dropdownListItems.ContainsKey(key))
                            {                                
                                dropdownListItems.Add(key, packets[i]);
                                ConnectionCombo.Items.Add(key);
                            }                                
                        }
                        i++;
                    }                    
                }
                else // if the user selected to filter on outgoing connection
                {
                    // write code to filter packet lists here
                    int i = 0;
                    foreach (CougarPacket cp in cougarpackets)
                    {
                        if (cp.DstPort == port && cp.SourceAddress.ToString().Equals(txtIpOne.Text))
                        {
                            filteredCougarPackets.Add(cp);
                            filteredRawPackets.Add(packets[i]);
                            key = cp.DestAddress + " - " + cp.DstPort;
                            if (!dropdownListItems.ContainsKey(key))
                            {
                                dropdownListItems.Add(key, packets[i]);
                                ConnectionCombo.Items.Add(key);
                            }                                
                        }
                        i++;
                    }                     
                }
                btnOk.Enabled = true;
                ConnectionCombo.Enabled = true;                
            }
            else
            {
                MessageBox.Show("Must enter a valid port number!", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void DumpCapturedPacketsToMotherTextFiles(string fileName) // dumps to text file
        {
            Console.WriteLine("got to DumpCapturedPacketsToMotherTextFiles");
            Console.WriteLine(fileName);
            int indexF = 0;            
            string[] file = fileName.Split('.');
            /*foreach (string poo in file)
                Console.WriteLine(poo);*/
            //fileName.
            if (filteredRawPackets.Count > 0)
            {
                //open file stream for mother file and raw mother file
                FileStream fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                StreamWriter fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);
                string[] selectedConnection = ConnectionCombo.SelectedItem.ToString().Split('-');
                //Console.WriteLine(selectedConnection[0]);
                selectedConnection[0] = selectedConnection[0].Trim();
                selectedConnection[1] = selectedConnection[1].Trim();


                int i = 0;
                Console.WriteLine("filtered cougar packet length: "+filteredCougarPackets.Count);
                foreach (CougarPacket cp in filteredCougarPackets)
                {
                    if (incomingConnection)
                    {
                        if (cp.SourceAddress.ToString().Equals(selectedConnection[0]) && cp.DstPort == Int32.Parse(selectedConnection[1]))
                        {
                            byte[] barr = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                            fs.Write(barr, 0, barr.Length);
                            fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(filteredRawPackets[i].Buffer).Replace("-", ""), filteredRawPackets[i].Timestamp.ToString("hh:mm:ss.fff"), filteredRawPackets[i].DataLink, filteredRawPackets[i].OriginalLength));
                        }
                    }
                    else
                    {
                        if (cp.DestAddress.ToString().Equals(selectedConnection[0]) && cp.DstPort == Int32.Parse(selectedConnection[1]))
                        {
                            byte[] barr = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                            fs.Write(barr, 0, barr.Length);
                            fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(filteredRawPackets[i].Buffer).Replace("-", ""), filteredRawPackets[i].Timestamp.ToString("hh:mm:ss.fff"), filteredRawPackets[i].DataLink, filteredRawPackets[i].OriginalLength));
                        }
                    }
                    ++i;
                }

                fs.Close();
                fsRaw.Close();
            }

        }

        private string DetermineFilePath()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text File (*.txt)| *.txt |All files (*.*)|*.*",
                FilterIndex = 0
            };

            string dumpFileName = "";//sfd.FileName;

            switch (sfd.ShowDialog())
            {
                case DialogResult.OK:
                    if (sfd.FileName != "")
                    {
                        dumpFileName = sfd.FileName;
                        DumpCapturedPacketsToMotherTextFiles(dumpFileName);
                        Console.WriteLine(dumpFileName);
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
        }

        private void IOConnection_Load(object sender, EventArgs e)
        {

        }
    }
}
