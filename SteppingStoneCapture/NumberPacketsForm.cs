using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteppingStoneCapture
{
    public partial class NumberPacketsForm : Form
    {
        private int numPackets;
        public NumberPacketsForm(int num)
        {
            InitializeComponent();
            numPackets = num;
            NumPacketBox.Text = numPackets.ToString();
        }

        public int NumPackets { get => numPackets; set => numPackets = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(NumPacketBox.Text, out numPackets);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
