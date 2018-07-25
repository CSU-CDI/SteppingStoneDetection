using SteppingStoneCapture.Analysis.PacketMatching;
using SteppingStoneCapture.Tools;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteppingStoneCapture.Analysis.StepFunction
{
    /// <summary>
    /// Logical Controller of the StepFunctionForm
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
    class StepFunctionFormController
    {
        // Global variables for the step function form
        private const string seriesName = "GraphingSeries";
        private const string chartAreaName = "ChartArea1";
        private PacketMatcher matcher;
        private Tools.FileHandler fileHandler;


        public StepFunctionFormController()
        {
            fileHandler = new FileHandler();
        }


        public string RunAlgorithm(int algo)
        { 
            var tuple = VerifyMatchingAlgorithm(algo);
            Matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(FileHandler.PacketsReadFromFile, FileHandler.SensorIP);
            Matcher.MatchPackets();
            return Matcher.ParseResults();
        }


        public Chart DisplayResults(Chart graphingChart)
        {
            // Grab the object with the graphing chart that stores the data
            var dataSeriesCollection = graphingChart.Series;
            var dataSeries = dataSeriesCollection[SeriesName];

            // if the PacketMatcher successfully matched packets
            if (Matcher.RoundTripTimes.Count > 0)
            {
                // initialize the max dimensions of the chart
                int maxX = Matcher.RoundTripTimes.Count;
                double maxY = Matcher.RoundTripTimes[0];

                // graph each round-trip time against its index
                for (int i = 1; i < Matcher.RoundTripTimes.Count; i++)
                {
                    // change to 1-based indexing
                    int index = i + 1;
                    double rtt = Matcher.RoundTripTimes[i];

                    // update the max height of the chart if the current rtt is greater than the current max
                    if (rtt > maxY) maxY = rtt;

                    // add the ordered pair (index, rtt) to the data
                    dataSeries.Points.AddXY(index, Matcher.RoundTripTimes[i]);
                }

                // Assign the max height to the y-axis control object
                graphingChart.ChartAreas.FindByName(ChartAreaName).AxisY.Maximum = maxY + 10;

                // reassign the modified series to the chart
                graphingChart.Series[SeriesName] = dataSeries;
                // enable the chart for viewing
                graphingChart.Enabled = true;

            }
            else MessageBox.Show("No Matches Detected.");
            return graphingChart;
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
        public Tuple<bool, PacketMatcher> VerifyMatchingAlgorithm(int algo)
        {
            // initialize the flag
            bool algorithmWasChanged;
            Console.WriteLine(algo);
            // if the algorithm doesn't match or the matcher hasn't been initialized
            if (Matcher == null || (int)Matcher.Algorithm != algo)
            {
                algorithmWasChanged = false;
                // Check the desired algorithm
                switch (algo)
                {
                    // initialize a First-Pair Packet Matcher
                    case (int)MatchingAlgorithm.FIRST_PAIR:
                        algorithmWasChanged = true;
                        Matcher = new FirstPairMatcher();
                        break;
                    // Determine and initialize a Conservative/Greedy-Heuristic Packet Matcher
                    case (int)MatchingAlgorithm.CONSERVATIVE:
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
                            Matcher = new ConservativeMatcher(tg);
                        }
                        break;
                    case (int)MatchingAlgorithm.GREEDY_HEURISTIC:
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
                            Matcher = new GreedyHeuristicPacketMatcher(tg);
                        }
                        break;
                }

            }

            else algorithmWasChanged = false;
            // return the boolean and packet matcher
            Console.WriteLine("algo: "+Matcher.Algorithm);
            return Tuple.Create(algorithmWasChanged, Matcher);
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
                    FileHandler.LoadPacketsFromFiles(clf.FileNameRequested);
                    
                }
            } while (!System.IO.File.Exists(clf.FileNameRequested));

            // return the file's name
            return clf.FileNameRequested;
        }

        /// <summary>
        /// Save the specified graph to a determined file type
        /// </summary>
        /// <param name="graphingChart">
        /// Chart used to display the results of packet matching
        /// </param>
        public void SaveGraphResults(Chart graphingChart)
        {
            // Ask the user to select a file for the graph to be save under
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff",
                FilterIndex = 0
            };

            // repeat while there are errors
            do
            {
                sfd.ShowDialog();
            } while (sfd.FileName == "" || System.IO.File.Exists(sfd.FileName));

            // initialize the format to bmp
            ChartImageFormat chartImageFormat = ChartImageFormat.Bmp;

            // correct the format if otherwise specified
            switch (sfd.FilterIndex)
            {
                case 2:
                    chartImageFormat = ChartImageFormat.Gif;
                    break;
                case 3:
                    chartImageFormat = ChartImageFormat.Jpeg;
                    break;
                case 4:
                    chartImageFormat = ChartImageFormat.Png;
                    break;
                case 5:
                    chartImageFormat = ChartImageFormat.Tiff;
                    break;
            }

            // save the image with the entered file name and format
            graphingChart.SaveImage(sfd.FileName, chartImageFormat);
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

        public static string SeriesName => seriesName;

        public static string ChartAreaName => chartAreaName;

        internal PacketMatcher Matcher { get => matcher; set => matcher = value; }
        internal FileHandler FileHandler { get => fileHandler; set => fileHandler = value; }
    }
}
