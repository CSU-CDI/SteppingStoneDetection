using System;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// Enumeration of available algortihms
    /// </summary>
    public enum MatchingAlgorithm
    {
        FIRST_PAIR,
        CONSERVATIVE,
        GREEDY_HEURISTIC,
        // Add Algorithms Elements above this comment
        NBR_ALGORITHMS,
        // Replace these if different Max/Min values are wanted for the form's NumericUpDowm
        FIRST = FIRST_PAIR,
        LAST=GREEDY_HEURISTIC
    }

    /// <summary>
    /// Form used to display the results of using a selected packet matching algorithm on
    /// a connection file
    /// </summary>
    /// 
    /// <remarks> 
    /// Author: Andrew Lesh
    /// </remarks>
    public partial class PacketMatchingForm : Form
    {
        private PacketMatcher matcher;

        /// <summary>
        /// Initializes the form to use the First-Match algorihm
        /// </summary>
        /// <remarks>
        /// The term First-Pair is merely used to circumvent using First-Match Matching Algorithm
        /// </remarks>
        public PacketMatchingForm()
        {
            InitializeComponent();
            matcher = new FirstPairMatcher();
            this.Visible = true;
        }

        /// <summary>
        /// Initializes the form with necessary data input, depending on specified algorithm
        /// </summary>
        /// <param name="algo">
        /// MatchingAlgortihm Enumeration element detailing the algorithm to be used
        /// </param>
        public PacketMatchingForm(MatchingAlgorithm algo)
        {
            // Initializes the controls on the form
            InitializeComponent();

            // determine which algorithm is to be used
            switch (algo)
            {
                // initialize a First-Pair Packet Matcher
                case MatchingAlgorithm.FIRST_PAIR:
                    matcher = new FirstPairMatcher();
                    break;
                // Determine and initialize a Conservative/Greedy-Heuristic Packet Matcher
                case MatchingAlgorithm.CONSERVATIVE:
                case MatchingAlgorithm.GREEDY_HEURISTIC:
                    {
                        string input = "";
                        bool validInput = false;
                        double tg = 0;
                        do
                        {// Ask user for time gap allowed between Send Packets
                            Tools.TextInput ti = new Tools.TextInput("Enter acceptable send packet time difference[in milliseconds]: ");
                            // Set the form's title
                            ti.Text = "Set Time Difference Threshold";
                            // show the form to user
                            ti.ShowDialog();

                            // gather their inputted value
                            input = ti.InputtedText;
                            if (Double.TryParse(input, out tg)) validInput = true;
                            // Try to parse the value into a doubleConsole.WriteLine(input);
                        } while (!validInput);
                        matcher = (algo == MatchingAlgorithm.CONSERVATIVE) ? new ConservativeMatcher(tg) : new GreedyHeuristicPacketMatcher(tg);
                    }
                    break;
            }
            this.Visible = true;
        }

        /// <summary>
        /// Event Handler for when the Run Button is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunBtn_Click(object sender, EventArgs e)
        {            
            // run the packet matching algorithm
            matcher.MatchPackets();

            // gather data on the results
            var numSend = matcher.SendPackets.Count;
            var numEcho = matcher.EchoPackets.Count;
            var numTot = matcher.ConnectionPackets.Count;

            // Print the matches to the results' text box
            foreach (string s in matcher.PairedMatches.Values)
            {
                resTextBox.Text += String.Format("{0}\n", s);
            }

            // Print the numerical details describing the results
            resTextBox.Text += $"Total Number Packets: {(numSend + numEcho)}\n";
            resTextBox.Text += "Number Send Packets: " + numSend;
            resTextBox.Text += " Number Echo Packets: " + numEcho;
            resTextBox.Text += "\n";
            resTextBox.Text += $"Number of Matches: {matcher.PairedMatches.Count}\n";
            resTextBox.Text += String.Format("Percentage matched of all possible pairs: {0:F}%", (100 * matcher.PairedMatches.Count / Math.Min(numSend, numEcho)));// numTot));
        
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            matcher.ResetMatcher();
            resTextBox.Text = "";
            fileTxtBox.Text = "";
        }
        
        private void ConnectionFileItem_Click(object sender, EventArgs e)
        {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
                fileTxtBox.Text = clf.FileNameRequested;
                
                matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }

        private void SaveTextItem_Click(object sender, EventArgs e)
        {
            if (matcher.PairedMatches.Values.Count > 0)
            {
                var sfd = new SaveFileDialog()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
                };
                sfd.ShowDialog();

                var file = new System.IO.StreamWriter(sfd.FileName);

                foreach (String s in matcher.PairedMatches.Values)
                {
                    file.WriteLine(s);
                }
            }
            else
                MessageBox.Show("Error! No Matches detected?");


        }
    }
}