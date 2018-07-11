using SteppingStoneCapture.Analysis.PacketMatching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteppingStoneCapture.Analysis
{
    public partial class StepFunctionForm : Form
    {
        // 
        private const string SeriesName = "GraphingSeries";
        private const string ChartAreaName = "ChartArea1";
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

                    graphingChart.ChartAreas.FindByName(ChartAreaName).AxisY.Maximum = maxY + 10;
                    this.graphingChart.Series[SeriesName] = dataSeries;
                    this.graphingChart.Enabled = true;
                   
                    String legible = "";

                    foreach (KeyValuePair<double, string> keyValue in matcher.PairedMatches)
                    {
                        
                        legible = $"{legible}\n{keyValue.Value}";
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

        private void LoadFileItem_Click(object sender, EventArgs e)
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

        private void SaveGraphItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff",
                FilterIndex = 0
            };

            do
            {
                sfd.ShowDialog();
            } while (sfd.FileName == "" || System.IO.File.Exists(sfd.FileName));

            ChartImageFormat chartImageFormat = ChartImageFormat.Bmp;

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

                graphingChart.SaveImage(sfd.FileName, chartImageFormat);            
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
