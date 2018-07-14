using System;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// Logical Controller of the PacketMatchingForm
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
    class PacketMatchingFormController
    {
        private PacketMatcher matcher;

        public PacketMatchingFormController()
        {
            Matcher = new FirstPairMatcher();
        }

        public PacketMatchingFormController(MatchingAlgorithm algo)
        {
            var tuple = VerifyMatchingAlgorithm(null, algo);
            if (tuple.Item1)
            {
                Matcher = tuple.Item2;
            }
            
        }
        /// <summary>
        /// Validates that the correct algorithm will be applied
        /// </summary>
        /// <param name="matcher">
        /// The Current Instance of the Packet Matcher
        /// </param>
        /// <param name="algo">
        /// The Desired Algorithm Enumeral
        /// </param>
        /// <returns>
        /// A tuple:
        /// - Bool declaring whether the correct algorithm is selected
        /// - The new instance of the packetmatcher
        /// </returns>
        public Tuple<bool, PacketMatcher> VerifyMatchingAlgorithm(PacketMatcher matcher, MatchingAlgorithm algo = MatchingAlgorithm.FIRST)
        {
            // initialize the flag
            bool algorithmWasChanged;

            // if the algorithm doesn't match or the matcher hasn't been initialized
            if (matcher == null || matcher.Algorithm != algo)
            {
                algorithmWasChanged = false;
                // Check the desired algorithm
                switch (algo)
                {
                    // initialize a First-Pair Packet Matcher
                    case MatchingAlgorithm.FIRST_PAIR:
                        algorithmWasChanged = true;
                        matcher = new FirstPairMatcher();
                        break;
                    // Determine and initialize a Conservative/Greedy-Heuristic Packet Matcher
                    case MatchingAlgorithm.CONSERVATIVE:
                    case MatchingAlgorithm.GREEDY_HEURISTIC:
                        {
                            algorithmWasChanged = true;
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
            
        }

            else algorithmWasChanged = false;
            // return the boolean and packet matcher
            return Tuple.Create(algorithmWasChanged, matcher);
        }

        public string RunAlgorithm()
        {
            Matcher.MatchPackets();
            return Matcher.ParseResults();
        }

        public void ResetController()
        {
            Matcher.ResetMatcher();
        }

        /// <summary>
        /// Loads the file containing packets from a connection
        /// </summary>
        /// <returns>
        /// String containing specified flename 
        /// </returns>
        public string LoadConnectionFile()
        {
            // call up the load form
            var clf = new Tools.CustomLoadForm();

            // while an invalid file name is input
            do
            {
                
                clf.ShowDialog();

                // if the inputted file exists
                if (System.IO.File.Exists(clf.FileNameRequested))
                {
                    // load the packets into the file handler
                    var fh = new Tools.FileHandler();
                    fh.LoadPacketsFromFiles(clf.FileNameRequested);

                    // assign the loaded packets to the awaiting matcher
                    Matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
                }
            } while (!System.IO.File.Exists(clf.FileNameRequested));

            // return the file's name
            return clf.FileNameRequested;
        }

        /// <summary>
        /// Saves the results of the algoritm to a text file
        /// </summary>
        public void SaveResults()
        {
            // if there were any matches
            if (Matcher.PairedMatches.Values.Count > 0)
            {
                // open a dialog to the document's directory
                var sfd = new SaveFileDialog()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
                };

                sfd.ShowDialog();

                // Create a stream for the data to written to
                var file = new System.IO.StreamWriter(sfd.FileName);

                // write the results to the stream
                file.Write(Matcher.ParseResults());

                // close the file when finished
                file.Close();
            }
            else
                MessageBox.Show("Error! No Matches detected?");
        }

        internal PacketMatcher Matcher { get => matcher; set => matcher = value; }
    }
}
