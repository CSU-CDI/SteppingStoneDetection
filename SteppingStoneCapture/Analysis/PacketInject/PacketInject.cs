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


namespace SteppingStoneCapture.Analysis
{
    public partial class PacketInject : Form
    {
        PacketDevice selectedDevice;
        int count;
        public PacketInject()
        {
            InitializeComponent();
            Visible = true;
            //btnOk.Enabled = false;
            //lblResult.Text = "EMPTY";
            count = 0;
        }

        public PacketInject(PacketDevice selectedDevice)
        {
            InitializeComponent();
            Visible = true;
            //btnOk.Enabled = false;
            //lblResult.Text = "EMPTY";
            this.selectedDevice = selectedDevice;
            count = 0;
            if (selectedDevice == null)
            {
                MessageBox.Show("Must select a network interface first!");
                Close();
            }
            radPSH.Checked = true;
        }

        private void radPSH_CheckedChanged(object sender, EventArgs e)
        {
            if (radPSH.Checked)
            {
                radACK.Checked = false;
                radRST.Checked = false;
                radFIN.Checked = false;
            }
        }

        private void radACK_CheckedChanged(object sender, EventArgs e)
        {
            if (radACK.Checked)
            {
                radPSH.Checked = false;
                radRST.Checked = false;
                radFIN.Checked = false;
            }
        }

        private void radRST_CheckedChanged(object sender, EventArgs e)
        {
            if (radRST.Checked)
            {
                radPSH.Checked = false;
                radACK.Checked = false;
                radFIN.Checked = false;
            }
        }

        private void radFIN_CheckedChanged(object sender, EventArgs e)
        {
            if (radFIN.Checked)
            {
                radPSH.Checked = false;
                radACK.Checked = false;
                radRST.Checked = false;
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
            //count = 0;

            if (srcPortFlag && dstPortFlag && srcPort <= 65535 && srcPort > 0 && dstPort <= 65535 && dstPort > 0)
            {
                try
                {
                    EthernetLayer ethernetLayer =
                        new EthernetLayer
                        {
                            Source = new MacAddress("01:01:01:01:01:01"),
                            Destination = new MacAddress("02:02:02:02:02:02"),
                            EtherType = EthernetType.None, // Will be filled automatically.
                        };

                    IpV4Layer ipV4Layer =
                    new IpV4Layer
                    {
                        Source = new IpV4Address(txtSrcIP.Text),
                        CurrentDestination = new IpV4Address(txtDestIP.Text),
                        Fragmentation = IpV4Fragmentation.None,
                        HeaderChecksum = null, // Will be filled automatically.
                        Identification = 123,
                        Options = IpV4Options.None,
                        Protocol = null, // Will be filled automatically.
                        Ttl = 100,
                        TypeOfService = 0,
                    };

                    TcpLayer tcpLayer =
                        new TcpLayer
                        {
                            SourcePort = (ushort)srcPort,
                            DestinationPort = (ushort)dstPort,
                            Checksum = null, // Will be filled automatically.
                            SequenceNumber = 100,
                            AcknowledgmentNumber = 50,
                            //ControlBits = TcpControlBits.Acknowledgment,
                            ControlBits = (radPSH.Checked) ? TcpControlBits.Push : (radACK.Checked) ? TcpControlBits.Acknowledgment : (radRST.Checked) ? TcpControlBits.Reset : TcpControlBits.Fin,
                            Window = 100,
                            UrgentPointer = 0,
                            Options = TcpOptions.None,
                        };

                    PayloadLayer payloadLayer =
                        new PayloadLayer
                        {
                            Data = new Datagram(Encoding.ASCII.GetBytes(txtInput.Text)),
                        };

                    PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, payloadLayer);
                    PacketCommunicator communicator = selectedDevice.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000);

                    bool flag = Int32.TryParse(txtNumPackets.Text, out int repeat);
                    if (repeat > 1000)
                        repeat = 1000;
                    else if (repeat < 1)
                        repeat = 1;

                    btnOk.Enabled = false;
                    btnReset.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    
                    if (flag)
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

        private void txtInput_Enter(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals("Message to Send..."))
            {
                txtInput.Text = "";
            }            
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals(""))
            {
                txtInput.Text = "Message to Send...";
            }            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSrcIP.Text = txtDestIP.Text = txtSrcPort.Text = txtDestPort.Text = txtNumPackets.Text = txtInput.Text = "";
            radPSH.Checked = true;
            lblResult.Text = "";

        }
    }
}
