using SteppingStoneCapture.Analysis.PacketMatching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis
{
    public partial class StepFunctionForm : Form
    {
        private const string SeriesName = "GraphingSeries";
        private PacketMatcher matcher;
        private Tools.FileHandler fileHandler;
        private string FileName;

        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
         //   matcher = new FirstPairMatcher();
            fileHandler = new Tools.FileHandler();
            FileName = "";

            AlgorithmUpDown.Maximum = (int)MatchingAlgorithm.LAST;
            AlgorithmUpDown.Minimum = (int)MatchingAlgorithm.FIRST;
        }


        private void GraphButton_Click(object sender, EventArgs e)
        {
            

            if (System.IO.File.Exists(fileTxtBox.Text))
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

                fileHandler.LoadPacketsFromFiles(FileName);

                matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fileHandler.PacketsReadFromFile, fileHandler.SensorIP);
                matcher.MatchPackets();

                var dataSeriesCollection = graphingChart.Series;
                var dataSeries = dataSeriesCollection[SeriesName];

                if (matcher.RoundTripTimes.Count > 0)
                {
                    int maxX = matcher.RoundTripTimes.Count;
                    double maxY = matcher.RoundTripTimes[0];

                    for (int i = 1; i < matcher.RoundTripTimes.Count; i++)
                    {
                        int index = i + 1;
                        double rtt = matcher.RoundTripTimes[i];


                        if (rtt > maxY) maxY = rtt;

                        dataSeries.Points.AddXY(i + 1, matcher.RoundTripTimes[i]);
                    }

                    graphingChart.ChartAreas.FindByName("ChartArea1").AxisY.Maximum = maxY + 10;
                    this.graphingChart.Series[SeriesName] = dataSeries;
                    this.graphingChart.Enabled = true;
                   
                    String legible = "";

                    foreach (KeyValuePair<double, string> keyValue in matcher.PairedMatches)
                    {
                        
                        legible = $"{legible}\n{keyValue.Value}: {keyValue.Key}";
                    }

                    var rtf = new Tools.RtfHelpForm();
                    rtf.AddText(legible);
                }

                else
                {
                    Console.WriteLine($"Error! No matches were detected from files:\n{fileTxtBox.Text}");
                }
            }
        
        }

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

        private void NetworkConfigurationItem_Click(object sender, EventArgs e) =>
            Tools.HtmlHelpForm.ShowHelp("stepFunction_NetworkConfiguration.html", "Step-Function in a LAN Network Configuration");

        private void loadFileItem_Click(object sender, EventArgs e)
        {
            var clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (System.IO.File.Exists(clf.FileNameRequested)) //clf.FileNameRequested")
            {


                fileTxtBox.Text = clf.FileNameRequested;
                FileName = clf.FileNameRequested;
                if (!GraphButton.Enabled && !ClearButton.Enabled)
                {
                    GraphButton.Enabled = true;
                    ClearButton.Enabled = true;
                }

                //               matcher.ConnectionPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
            else
            {
                fileTxtBox.Text = "Error!";
            }

        }
    }
}
