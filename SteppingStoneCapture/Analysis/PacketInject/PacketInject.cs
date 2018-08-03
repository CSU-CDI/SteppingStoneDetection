using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using System.Net.NetworkInformation;
using System.Net;
using PcapDotNet.Packets.Arp;


namespace SteppingStoneCapture.Analysis
{
    public partial class PacketInject : Form
    {
        LivePacketDevice selectedDevice;
        int count;
        Timer timer;
        MacAddress sourceMac;
        MacAddress destMac;
        IPAddress gatewayAddy;
        public PacketInject()
        {
            InitializeComponent();
            Visible = true;            
            count = 0;
            timer = new Timer();            
        }

        public PacketInject(LivePacketDevice selectedDevice)
        {            
            InitializeComponent();            
            this.sourceMac = selectedDevice.GetMacAddress();
            this.destMac = new MacAddress(GetMacAddress(gatewayAddy).ToString());
            this.gatewayAddy = selectedDevice.GetNetworkInterface().GetIPProperties().GatewayAddresses[0].Address;            
            this.selectedDevice = selectedDevice;
            count = 0;
            if (selectedDevice == null)
            {
                Visible = false;
                MessageBox.Show("Must select a network interface first!");
                Close();
            }
            else
                Visible = true;

            radPSH.Checked = true;            
        }

        [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(uint destIP, uint srcIP, byte[] macAddress, ref uint macAddressLength);

        public static MacAddress GetMacAddress(IPAddress address)
        {
            byte[] mac = new byte[6];
            uint len = (uint)mac.Length;
            byte[] addressBytes = address.GetAddressBytes();
            uint dest = ((uint)addressBytes[3] << 24)
              + ((uint)addressBytes[2] << 16)
              + ((uint)addressBytes[1] << 8)
              + ((uint)addressBytes[0]);
            if (SendARP(dest, 0, mac, ref len) != 0)
            {
                throw new Exception("The ARP request failed.");
            }
            return new MacAddress(BitConverter.ToString(mac).Replace("-", ":"));
        }

        private void radPSH_CheckedChanged(object sender, EventArgs e)
        {
            if (radPSH.Checked)
            {
                radACK.Checked = false;
                radRST.Checked = false;
                radFIN.Checked = false;
                radSYN.Checked = false;
            }
        }

        private void radACK_CheckedChanged(object sender, EventArgs e)
        {
            if (radACK.Checked)
            {
                radPSH.Checked = false;
                radRST.Checked = false;
                radFIN.Checked = false;
                radSYN.Checked = false;
            }
        }

        private void radRST_CheckedChanged(object sender, EventArgs e)
        {
            if (radRST.Checked)
            {
                radPSH.Checked = false;
                radACK.Checked = false;
                radFIN.Checked = false;
                radSYN.Checked = false;
            }
        }

        private void radFIN_CheckedChanged(object sender, EventArgs e)
        {
            if (radFIN.Checked)
            {
                radPSH.Checked = false;
                radACK.Checked = false;
                radRST.Checked = false;
                radSYN.Checked = false;
            }
        }

        private void radSYN_CheckedChanged(object sender, EventArgs e)
        {
            if (radSYN.Checked)
            {
                radPSH.Checked = false;
                radACK.Checked = false;
                radRST.Checked = false;
                radFIN.Checked = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        /// <summary>
        /// Begins packet injection with user defined parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {           
            bool srcPortFlag = Int32.TryParse(txtSrcPort.Text, out int srcPort);
            bool dstPortFlag = Int32.TryParse(txtDestPort.Text, out int dstPort);
            //Console.WriteLine(sourceMac);
            //Console.WriteLine(GetMacAddress(gatewayAddy).ToString());
            
            // if condtions are met, attempt to build the packet from lower layer up, using user input
            if (srcPortFlag && dstPortFlag && srcPort <= 65535 && srcPort > 0 && dstPort <= 65535 && dstPort > 0)
            {
                try
                {   
                    EthernetLayer ethernetLayer =
                        new EthernetLayer
                        {
                            Source = sourceMac,
                            //Destination = new MacAddress("02:02:02:02:02:02"),
                            Destination = destMac,
                            EtherType = EthernetType.None, // Will be filled automatically.
                        };

                    IpV4Layer ipV4Layer =
                    new IpV4Layer
                    {
                        Source = new IpV4Address(txtSrcIP.Text),
                        CurrentDestination = new IpV4Address(txtDestIP.Text),
                        Fragmentation = IpV4Fragmentation.None,
                        HeaderChecksum = null, // Will be filled automatically.
                        Identification = (txtID.Text.Equals("")) ? (ushort)123 : ushort.Parse(txtID.Text),
                        Options = IpV4Options.None,
                        Protocol = null, // Will be filled automatically.
                        Ttl = txtTTL.Text.Equals("") ? (byte)100 : byte.Parse(txtTTL.Text) > 255 ? (byte)255 : byte.Parse(txtTTL.Text) < 1 ? (byte)1 : byte.Parse(txtTTL.Text),
                        TypeOfService = 0,                        
                    };

                    TcpLayer tcpLayer =
                        new TcpLayer
                        {
                            SourcePort = (ushort)srcPort,
                            DestinationPort = (ushort)dstPort,
                            Checksum = null, // Will be filled automatically.
                            SequenceNumber = txtSequence.Text.Equals("") ? 100 : uint.Parse(txtSequence.Text),
                            AcknowledgmentNumber = txtACK.Text.Equals("") ? 50 : uint.Parse(txtACK.Text),                           
                            ControlBits = (radPSH.Checked) ? TcpControlBits.Push : (radACK.Checked) ? TcpControlBits.Acknowledgment : (radRST.Checked) ? TcpControlBits.Reset : (radFIN.Checked) ? TcpControlBits.Fin : TcpControlBits.Synchronize,
                            Window = txtWindow.Text.Equals("") ? (ushort)100 : ushort.Parse(txtWindow.Text),
                            UrgentPointer = 0,
                            Options = TcpOptions.None,                            
                        };

                    PayloadLayer payloadLayer =
                        new PayloadLayer
                        {
                            Data = new Datagram(Encoding.ASCII.GetBytes(txtInput.Text)),
                        };

                    // build packet and initiate communicator
                    PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, payloadLayer);
                    PacketCommunicator communicator = selectedDevice.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000);                    

                    // send packet
                    bool repeatFlag = Int32.TryParse(txtNumPackets.Text, out int repeat);
                    bool intervalFlag = Int32.TryParse(txtInterval.Text, out int interval);
                    if (intervalFlag)
                    {
                        timer = new Timer();
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = interval;
                        timer.Enabled = true;
                        timer.Start();
                    }

                    if (repeatFlag && !intervalFlag && repeat > 1000)
                    {
                        repeat = 1000;
                        txtNumPackets.Text = repeat.ToString();
                    }                        
                    else if (repeatFlag && !intervalFlag && repeat < 1)
                    {
                        repeat = 1;
                        txtNumPackets.Text = repeat.ToString();
                    }                        

                    btnOk.Enabled = false;
                    btnReset.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    
                    if (repeatFlag && !intervalFlag)
                    {
                        for (int i = 0; i < repeat; i++)
                        {
                            communicator.SendPacket(builder.Build(DateTime.Now));
                            count++;
                            lblResult.Text = "SUCCESS!: " + count;
                        }
                        count = 0;
                    }                      
                    else
                    {
                        communicator.SendPacket(builder.Build(DateTime.Now));
                        count++;
                        lblResult.Text = "SUCCESS!: " + count;
                    }
                    Cursor = Cursors.Default;
                    btnOk.Enabled = true;
                    btnReset.Enabled = true;                    
                }
                catch (Exception)
                {
                    lblResult.Text = "FAIL!";
                    MessageBox.Show("Invalid Input!");                    
                    count = 0;
                    btnOk.Enabled = true;
                    btnReset.Enabled = true;
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            bool srcPortFlag = Int32.TryParse(txtSrcPort.Text, out int srcPort);
            bool dstPortFlag = Int32.TryParse(txtDestPort.Text, out int dstPort);

            // if condtions are met, attempt to build the packet from lower layer up, using user input
            if (srcPortFlag && dstPortFlag && srcPort <= 65535 && srcPort > 0 && dstPort <= 65535 && dstPort > 0)
            {
                try
                {
                    EthernetLayer ethernetLayer =
                        new EthernetLayer
                        {
                            Source = sourceMac,
                            Destination = destMac,
                            EtherType = EthernetType.None, // Will be filled automatically.
                        };

                    IpV4Layer ipV4Layer =
                    new IpV4Layer
                    {
                        Source = new IpV4Address(txtSrcIP.Text),
                        CurrentDestination = new IpV4Address(txtDestIP.Text),
                        Fragmentation = IpV4Fragmentation.None,
                        HeaderChecksum = null, // Will be filled automatically.
                        Identification = (txtID.Text.Equals("")) ? (ushort)123 : ushort.Parse(txtID.Text),
                        Options = IpV4Options.None,
                        Protocol = null, // Will be filled automatically.
                        Ttl = txtTTL.Text.Equals("") ? (byte)100 : byte.Parse(txtTTL.Text) > 255 ? (byte)255 : byte.Parse(txtTTL.Text) < 1 ? (byte)1 : byte.Parse(txtTTL.Text),
                        TypeOfService = 0,
                    };

                    TcpLayer tcpLayer =
                        new TcpLayer
                        {
                            SourcePort = (ushort)srcPort,
                            DestinationPort = (ushort)dstPort,
                            Checksum = null, // Will be filled automatically.
                            SequenceNumber = txtSequence.Text.Equals("") ? 100 : uint.Parse(txtSequence.Text),
                            AcknowledgmentNumber = txtACK.Text.Equals("") ? 50 : uint.Parse(txtACK.Text),
                            ControlBits = (radPSH.Checked) ? TcpControlBits.Push : (radACK.Checked) ? TcpControlBits.Acknowledgment : (radRST.Checked) ? TcpControlBits.Reset : (radFIN.Checked) ? TcpControlBits.Fin : TcpControlBits.Synchronize,
                            Window = txtWindow.Text.Equals("") ? (ushort)100 : ushort.Parse(txtWindow.Text),
                            UrgentPointer = 0,
                            Options = TcpOptions.None,
                        };

                    PayloadLayer payloadLayer =
                        new PayloadLayer
                        {
                            Data = new Datagram(Encoding.ASCII.GetBytes(txtInput.Text)),
                        };

                    // build packet and initiate communicator
                    PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, payloadLayer);
                    PacketCommunicator communicator = selectedDevice.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000);
                    communicator.SendPacket(builder.Build(DateTime.Now));
                }
                catch (Exception)
                {                    
                    timer.Dispose();
                }
            }
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals("Message / Payload to Send..."))
            {
                txtInput.Text = "";
            }            
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals(""))
            {
                txtInput.Text = "Message / Payload to Send...";
            }            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSrcIP.Text = txtDestIP.Text = txtSrcPort.Text = txtDestPort.Text = txtNumPackets.Text = txtWindow.Text = txtTTL.Text = txtSequence.Text = txtID.Text = txtACK.Text = txtInterval.Text = lblResult.Text = "";
            txtInput.Text = "Message / Payload to Send...";            
            radPSH.Checked = true;            
            timer.Dispose();

        }

        
    }
}
