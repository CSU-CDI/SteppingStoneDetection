using SteppingStoneCapture.Analysis.PacketMatching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteppingStoneCapture.Analysis
{
    /// <summary>
    /// Provides Graphical Data to allow users to estimate the number of downstream stepping-stones from a sensor host
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
    public partial class StepFunctionForm : Form
    {
        // Global variables for the step function form
        private const string SeriesName = "GraphingSeries";
        private const string ChartAreaName = "ChartArea1";
        private PacketMatcher matcher;
        private Tools.FileHandler fileHandler;
        private string FileName;

        /// <summary>
        /// Default Constructor for the form initializing various controls and properties
        /// </summary>
        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
            fileHandler = new Tools.FileHandler();
            FileName = "";

            // Sets the max/min value of the NumericUpDown Algorithm selector to be the first and last enumerated algorithms
            AlgorithmUpDown.Maximum = (int)MatchingAlgorithm.LAST;
            AlgorithmUpDown.Minimum = (int)MatchingAlgorithm.FIRST;
        }


        /// <summary>
        /// Responds to Graphing Request and runs algorithm on specified capture file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphButton_Click(object sender, EventArgs e)
        {
            // If the specified capture file exists
            if (System.IO.File.Exists(fileTxtBox.Text))
            { 
                // Ensure that the PacketMatcher is initialized to the correct algorithm
                if (matcher == null || AlgorithmUpDown.Value != (int)matcher.Algorithm)
                {
                    switch (AlgorithmUpDown.Value)
                    {
                        case (int)MatchingAlgorithm.CONSERVATIVE:
                            matcher = new ConservativeMatcher();
                            break;
                        case (int)MatchingAlgorithm.FIRST_PAIR:
                            matcher = new FirstPairMatcher();
                            break;
                        case (int)MatchingAlgorithm.GREEDY_HEURISTIC:
                            matcher = new GreedyHeuristicPacketMatcher();
                            break;
                    }
                }

                // load the packets from the file
                fileHandler.LoadPacketsFromFiles(FileName);

                // Convert the raw packets to Cougar Packets for analysis
                matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fileHandler.PacketsReadFromFile, fileHandler.SensorIP);
                // Match the Send and Echo Packets accordingly
                matcher.MatchPackets();

                // Grab the object with the graphing chart that stores the data
                var dataSeriesCollection = graphingChart.Series;
                var dataSeries = dataSeriesCollection[SeriesName];

                // if the PacketMatcher successfully matched packets
                if (matcher.RoundTripTimes.Count > 0)
                {
                    // initialize the max dimensions of the chart
                    int maxX = matcher.RoundTripTimes.Count;
                    double maxY = matcher.RoundTripTimes[0];

                    // graph each round-trip time against its index
                    for (int i = 1; i < matcher.RoundTripTimes.Count; i++)
                    {
                        // change to 1-based indexing
                        int index = i + 1;
                        double rtt = matcher.RoundTripTimes[i];

                        // update the max height of the chart if the current rtt is greater than the current max
                        if (rtt > maxY) maxY = rtt;

                        // add the ordered pair (index, rtt) to the data
                        dataSeries.Points.AddXY(index, matcher.RoundTripTimes[i]);
                    }

                    // Assign the max height to the y-axis control object
                    graphingChart.ChartAreas.FindByName(ChartAreaName).AxisY.Maximum = maxY + 10;

                    // reassign the modified series to the chart
                    this.graphingChart.Series[SeriesName] = dataSeries;
                    // enable the chart for viewing
                    this.graphingChart.Enabled = true;
                   
                    String legible = "";

                    // gather a string describing the matches
                    foreach (KeyValuePair<double, string> keyValue in matcher.PairedMatches)
                    {
                        
                        legible = $"{legible}\n{keyValue.Value}";
                    }

                    // display the matches' descriptions to the user
                    var rtf = new Tools.RtfHelpForm();
                    rtf.AddText(legible);
                }

                else
                {
                    Console.WriteLine($"Error! No matches were detected from files:\n{fileTxtBox.Text}");
                }
            }
        
        }

        /// <summary>
        /// Resets the Controls and properties of the form for reuse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            
            ClearButton.Enabled = false;
            GraphButton.Enabled = false;
            graphingChart.Series[SeriesName].Points.Clear();
            foreach (Control c in fileGrpBox.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Text = "";
                }
            }
            matcher.ResetMatcher();
        }

        /// <summary>
        /// Displays an html file detailing the network configuration necessary for 
        /// Step-Function in a LAN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NetworkConfigurationItem_Click(object sender, EventArgs e) =>
            Tools.HtmlHelpForm.ShowHelp("stepFunction_NetworkConfiguration.html", "Step-Function in a LAN Network Configuration");

        /// <summary>
        /// Loads the connection file, which can be .pcap or specialized .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFileItem_Click(object sender, EventArgs e)
        {
            // Ask user to select a file
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();

            // if the selected file exists
            if (System.IO.File.Exists(clf.FileNameRequested)) //clf.FileNameRequested")
            {
                // Display the file name on the form
                fileTxtBox.Text = clf.FileNameRequested;
                // set the file name property of the form
                FileName = clf.FileNameRequested;
                // enable the graph and clear buttons for use
                if (!GraphButton.Enabled && !ClearButton.Enabled)
                {
                    GraphButton.Enabled = true;
                    ClearButton.Enabled = true;
                }
            }
            else
            {
                fileTxtBox.Text = "Error!";
            }
        }

        /// <summary>
        /// Saves the Result Graph to file in the specified formats
        /// <para>
        /// Currently: .bmp, .gif, .jpg, .png, .tiff
        /// </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveGraphItem_Click(object sender, EventArgs e)
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
        /// Saves the text description of the matches to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveTextItem_Click(object sender, EventArgs e)
        {
            // If there are any matches to save
            if (matcher.PairedMatches.Values.Count > 0)
            {
                // ask for a file to save the packets under
                var sfd = new SaveFileDialog()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
                };
                sfd.ShowDialog();

                // create a streamwriter for the specified path
                var file = new System.IO.StreamWriter(sfd.FileName);

                // write every description to its own line
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
