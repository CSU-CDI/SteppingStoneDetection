using SteppingStoneCapture.Analysis.PacketMatching;
using SteppingStoneCapture.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private int algorithmWindowSize = 3;


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
                // graph each round-trip time against its index
                for (int i = 0; i < Matcher.RoundTripTimes.Count; i++)
                {
                    // add the ordered pair (index+1, rtt) to the data
                    dataSeries.Points.AddXY(i+1, Matcher.RoundTripTimes[i]);
                }

                // Assign the max/min height to the y-axis control object
                graphingChart.ChartAreas.FindByName(ChartAreaName).AxisY.Maximum = Matcher.MaxValue + 10;
                graphingChart.ChartAreas.FindByName(ChartAreaName).AxisY.Minimum = Matcher.MinValue - 10;

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

        public string DescribeConnectionEstimation()
        {
            Tuple<int, int> estimate = EstimateNumberOfConnections();
            if (estimate != null)
            {
                return String.Format("{0}/{1} Ups/Downs, Estimate No. Connections: {2}", estimate.Item1, estimate.Item2, Math.Min(estimate.Item1, estimate.Item2));
            }

            return "";
        }

        public Tuple<int,int> EstimateNumberOfConnections()
        {
            List<double> roundTripTimes = Matcher.RoundTripTimes;
            if (Matcher != null && roundTripTimes.Count > 0)
            {
                double threshold = 0.0f;
                threshold = CalculateThresholdAmount();

                int numJumpsUp = 0, numJumpsDown = 0;

                for (int ndx = roundTripTimes.Count - 1; ndx >= 2*AlgorithmWindowSize-1; ndx -= 2*AlgorithmWindowSize)
                {
                    CreateHalvesOfCurrentGrouping(roundTripTimes, out List<double> leftTimes, out List<double> rightTimes, ndx);

                    double minLeft = leftTimes.Min(),
                           minRight = rightTimes.Min(),
                           diff = minRight - minLeft;

                    bool isUp = false;
                    
                    if (diff > 0)
                        isUp = true;
                    else
                        diff *= -1;

                    Console.WriteLine($"TG: {threshold} Diff: {diff}\nMin: L: {minLeft} R: {minRight}\nIsUp: {isUp}");
                    if (diff > threshold)
                    {
                        int x = (isUp) ? numJumpsUp++ : numJumpsDown++;

                    }
                }

                return Tuple.Create(numJumpsUp, numJumpsDown);
            }

            return null;
        }

        private void CreateHalvesOfCurrentGrouping(List<double> roundTripTimes, out List<double> leftTimes, out List<double> rightTimes, int ndx)
        {
            leftTimes = new List<double>();
            rightTimes = new List<double>();
            for (int i = 2 * AlgorithmWindowSize - 1; i >= 0; i--)
            {
                if (i > (int) Math.Floor((2 * AlgorithmWindowSize - 1) / 2f))
                    leftTimes.Add(roundTripTimes[ndx - i]);
                else
                    rightTimes.Add(roundTripTimes[ndx - i]);
            }
        }

        private double CalculateThresholdAmount()
        {
            double threshold;
            if (Matcher.RoundTripTimes.Count < 30)
            {
                threshold = Matcher.RoundTripTimes.Average();
            }
            else
            {
                HashSet<int> indices = new HashSet<int>();
                Random rand = new Random();
                LinkedList<double> rtts = new LinkedList<double>();

                while (indices.Count < 30)
                {
                    int newIndex = rand.Next(0, Matcher.RoundTripTimes.Count);
                    if (!indices.Contains(newIndex))
                    {
                        indices.Add(newIndex);
                        rtts.AddLast(Matcher.RoundTripTimes[newIndex]);
                    }
                }

                threshold = rtts.Average();
                rtts.Clear();
                indices.Clear();
            }

            return threshold;
        }

        public static string SeriesName => seriesName;

        public static string ChartAreaName => chartAreaName;

        internal PacketMatcher Matcher { get => matcher; set => matcher = value; }
        internal FileHandler FileHandler { get => fileHandler; set => fileHandler = value; }
        public int AlgorithmWindowSize { get => algorithmWindowSize; set => algorithmWindowSize = value; }
    }
}
