using System;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    public enum MatchingAlgorithm
    {
        FIRST_PAIR,
        CONSERVATIVE,
        GREEDY_HEURISTIC,
        NBR_ALGORITHMS,
        FIRST = FIRST_PAIR,
        LAST=GREEDY_HEURISTIC
    }

    public partial class PacketMatchingForm : Form
    {
        private PacketMatcher pm;

        public PacketMatchingForm()
        {
            InitializeComponent();
            pm = new FirstPairMatcher();
            this.Visible = true;
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
                    {
                        Tools.TextInput ti = new Tools.TextInput("Enter acceptable send packet time difference[in milliseconds]: ");
                        ti.Text = "Set Time Difference Threshold";
                        ti.ShowDialog();

                        var input = ti.InputtedText;

                        Console.WriteLine(input);
                        Double.TryParse(input, out double tg);
                        pm = new ConservativeMatcher(tg);
                    }
                    break;
                case MatchingAlgorithm.GREEDY_HEURISTIC:
                    {
                        Tools.TextInput ti = new Tools.TextInput("Enter acceptable send packet time difference[in milliseconds]: ");
                        ti.Text = "Set Time Difference Threshold";
                        ti.ShowDialog();

                        var input = ti.InputtedText;

                        Console.WriteLine(input);
                        Double.TryParse(input, out double tg);
                        pm = new GreedyHeuristicPacketMatcher(tg);
                        break;
                    }
            }
            this.Visible = true;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {            
            pm.MatchPackets();

            var numSend = pm.SendPackets.Count;
            var numEcho = pm.EchoPackets.Count;
            var numTot = pm.ConnectionPackets.Count;

            foreach (string s in pm.PairedMatches.Values)
            {
                resTextBox.Text += String.Format("{0}\n", s);
            }

            resTextBox.Text += $"Total Number Packets: {(numSend + numEcho)}\n";
            resTextBox.Text += "Number Send Packets: " + numSend;
            resTextBox.Text += " Number Echo Packets: " + numEcho;
            resTextBox.Text += "\n";
            resTextBox.Text += $"Number of Matches: {pm.PairedMatches.Count}\n";
            resTextBox.Text += String.Format("Percentage matched of all possible pairs: {0:F}%", (100 * pm.PairedMatches.Count / numTot));// Math.Min(numSend, numEcho)));
        
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            pm.ResetMatcher();
            resTextBox.Text = "";
            fileTxtBox.Text = "";
        }
        
        private void connectionFileItem_Click(object sender, EventArgs e)
        {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                fileTxtBox.Text = clf.FileNameRequested;
                
                pm.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }

    }
}