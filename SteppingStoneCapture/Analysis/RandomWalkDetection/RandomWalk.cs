using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace SteppingStoneCapture.Analysis.RandomWalkDetection
{
    public partial class RandomWalk : Form
    {
        private Analysis.PacketMatching.PacketMatcher pmI;
        private Analysis.PacketMatching.PacketMatcher pmO;
        private int upperBound;
        private int numRTTI;
        private int numRTTO;
        private int diffRTT;
        public RandomWalk()
        {
            InitializeComponent();
            pmI = new Analysis.PacketMatching.ConservativeMatcher();
            pmO = new Analysis.PacketMatching.ConservativeMatcher();
            upperBound = 0;
            numRTTI = 0;
            numRTTO = 0;
            diffRTT = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void loadEI() {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                incEBox.Text = clf.FileNameRequested;
                pmI.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }
        private void loadSI() {
            Tools.CustomLoadForm clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                incSBox.Text = clf.FileNameRequested;
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                pmI.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP));
            }
        }
        private void loadEO() {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                outEBox.Text = clf.FileNameRequested;
                pmO.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }
        private void loadSO() {
            Tools.CustomLoadForm clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                outSBox.Text = clf.FileNameRequested;
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                pmO.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP));
            }
        }

        private void incEButton_Click(object sender, EventArgs e)
        {
            loadEI();
        }

        private void incSButton_Click(object sender, EventArgs e)
        {
            loadSI();
        }

        private void outEButton_Click(object sender, EventArgs e)
        {
            loadEO();
        }

        private void outSButton_Click(object sender, EventArgs e)
        {
            loadSO();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            pmI.MatchPackets();
            pmO.MatchPackets();
            int numRTTI = pmI.RoundTripTimes.Count();
            int numRTTO = pmO.RoundTripTimes.Count();
            int diffRTT = Math.Abs(numRTTI - numRTTO);
            inRTTLabel.Text += numRTTI.ToString();
            outRTTLabel.Text += numRTTO.ToString();
            diffRTTLabel.Text += diffRTT.ToString();
            upperBound = Convert.ToInt32(numericThres.Value);
            compare();
        }

        private void compare() {
            if (diffRTT < upperBound)
            {
                MessageBox.Show("The connections are not a stepping stone pair. The difference of between the number RTTs for incoming and outgoing connection is" + diffRTT + " and it is not lower than the threshold. The host machine is not a Stepping Stone");
                MessageBox.Show("The connections are a stepping stone pair. The difference of between the number RTTs for incoming and outgoing connection is" + diffRTT + " and it is lower than the threshold. The host machine is a Stepping Stone.");
            }

            else
            {
                MessageBox.Show("The connections are not a stepping stone pair. The difference of between the number RTTs for incoming and outgoing connection is" + diffRTT + " and it is not lower than the threshold. The host machine is not a Stepping Stone");
                
            }
        }

        private void incEBox_TextChanged(object sender, EventArgs e)
        {
            incSButton.Enabled = true;
        }

        private void incSBox_TextChanged(object sender, EventArgs e)
        {
            outEButton.Enabled = true;
        }

        private void outEBox_TextChanged(object sender, EventArgs e)
        {
            outSButton.Enabled = true;
        }

        private void outSBox_TextChanged(object sender, EventArgs e)
        {
            runButton.Enabled = true;
        }
    }
}
