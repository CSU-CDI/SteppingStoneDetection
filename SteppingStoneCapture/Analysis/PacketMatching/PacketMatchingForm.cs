using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    public enum MatchingAlgorithm
    {
        FIRST_PAIR,
        CONSERVATIVE,
        GREEDY_HEURISTIC,
        NBR_ALGORITHMS,
        DEFAULT = FIRST_PAIR
    }

    public partial class PacketMatchingForm : Form
    {
        private PacketMatcher pm;

        public PacketMatchingForm()
        {
            InitializeComponent();
            pm = new FirstPairMatcher();
        }

        public PacketMatchingForm(MatchingAlgorithm algo)
        {
            InitializeComponent();
            switch (algo)
            {
                case MatchingAlgorithm.FIRST_PAIR:
                    pm = new FirstPairMatcher();
                    break;
                case MatchingAlgorithm.CONSERVATIVE:
                    pm = new ConservativeMatcher();
                    break;
            }
            this.Visible = true;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {

            var numSend = pm.SendPackets.Count;
            var numEcho = pm.EchoPackets.Count;
            pm.MatchPackets();

            foreach (string s in pm.PairedMatches.Values)
            {
                resTextBox.Text += String.Format("{0}\n", s);
            }

            resTextBox.Text += $"Total Number Packets: {(numSend + numEcho)}\n";
            resTextBox.Text += "Number Send Packets: " + numSend;
            resTextBox.Text += " Number Echo Packets: " + numEcho;
            resTextBox.Text += "\n";
            resTextBox.Text += $"Number of Matches: {pm.PairedMatches.Count}\n";
            resTextBox.Text += String.Format("Percentage matched of all possible pairs: {0:F}%", (100 * pm.PairedMatches.Count / Math.Min(numSend, numEcho)));
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
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                sendTextBox.Text = clf.FileNameRequested;
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                pm.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP));
            }
        }

        private void LoadEchoPackets(object sender, EventArgs e)
        {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                echoTextBox.Text = clf.FileNameRequested;
                pm.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }
    }
}