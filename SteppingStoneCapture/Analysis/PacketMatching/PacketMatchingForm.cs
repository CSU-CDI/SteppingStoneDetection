using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    public enum MathcingAlgorithm
    {
        FIRST_PAIR,
        CONSERVATIVE,
        GREEDY_HEURISTIC,
        NBR_ALGORITHMS,
        DEFAULT=FIRST_PAIR
    }
    
    public partial class PacketMatchingForm : Form
    {
        private PacketMatcher pm;

        public PacketMatchingForm()
        {
            InitializeComponent();
            pm = new FirstPairMatcher();
        }

        public PacketMatchingForm(MathcingAlgorithm algo)
        {
            InitializeComponent();
            switch (algo)
            {
                case MathcingAlgorithm.FIRST_PAIR:
                    pm = new FirstPairMatcher();
                    break;
                case MathcingAlgorithm.CONSERVATIVE:
                    pm = new ConservativeMatcher();
                    break;
            }
        }        

        private void runBtn_Click(object sender, EventArgs e)
        {
            pm.MatchPackets();
            foreach (string s in pm.PairedMatches.Values)
            {
                resTextBox.Text += String.Format("{0}\n", s);
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            pm.ResetMatcher();
            resTextBox.Text = "";
            sendTextBox.Text = "";
            echoTextBox.Text = "";
        }

        private void LoadSendPackets(object sender, EventArgs e)
        {
            Tools.CustomLoadForm clf = new Tools.CustomLoadForm();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                pm.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP));
            }
        }

        private void LoadEchoPackets(object sender, EventArgs e)
        {
            var clf = new Tools.CustomLoadForm();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                pm.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }
    }
}
