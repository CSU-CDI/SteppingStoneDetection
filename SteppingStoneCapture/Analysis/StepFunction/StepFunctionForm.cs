using SteppingStoneCapture.Analysis.PacketMatching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis
{
    public partial class StepFunctionForm : Form
    {
        private PacketMatcher matcher;
        private Tools.FileHandler fileHandler;

        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
            matcher = new FirstPairMatcher();
            fileHandler = new Tools.FileHandler();
        }


        private void GraphButton_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(sendTextBox.Text) && System.IO.File.Exists(echoTextBox.Text))
            {
                matcher.MatchPackets();

                var dataSeriesCollection = graphingChart.Series;
                var dataSeries = dataSeriesCollection["GraphingSeries"];

                if (matcher.RoundTripTimes.Count > 0)
                {
                    for (int i = 0; i < matcher.RoundTripTimes.Count; i++)
                    {
                        dataSeries.Points.AddXY(i + 1, matcher.RoundTripTimes[i]);
                    }

                    this.graphingChart.Series["GraphingSeries"] = dataSeries;
                    this.graphingChart.Enabled = true;

                    String legible = "";

                    foreach (String s in matcher.PairedMatches.Values)
                    {
                        legible = $"{legible}\n{s}";
                    }

                    var rtf = new Tools.RtfHelpForm();
                    rtf.AddText(legible);
                }

                else
                {
                    MessageBox.Show(String.Format("Error! No matches were detected from files:\n{0}\n{1}", sendTextBox.Text, echoTextBox.Text));
                }
            }
        
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearButton.Enabled = false;
            GraphButton.Enabled = false;
            graphingChart.Series.Clear();
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

        private void LoadSendPackets(object sender, EventArgs e)
        {
            Tools.CustomLoadForm clf = new Tools.CustomLoadForm();
            clf.ShowDialog();
            if (clf.FileNameRequested != "")
            {
                var fh = new Tools.FileHandler();
                sendTextBox.Text = clf.FileNameRequested;
                fh.LoadPacketsFromFiles(clf.FileNameRequested);
               // matcher.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP));
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
                matcher.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(fh.PacketsReadFromFile, fh.SensorIP);
            }
        }
    }
}
