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

        private void LoadStreamFilesItem_Click(object sender, EventArgs e)
        {

            if (!firstMatchRadio.Checked)
                matcher = new ConservativeMatcher();

            try
            {
                var clf = new Tools.CustomLoadForm();
                clf.Text = "Please select file containing send stream packets...";
                clf.ShowDialog();

                sendStreamBox.Text = clf.FileNameRequested;
                fileHandler.LoadPacketsFromFiles(clf.FileNameRequested);
                var SendPackets = new List<PcapDotNet.Packets.Packet>(fileHandler.PacketsReadFromFile);
                matcher.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(SendPackets, fileHandler.SensorIP));

                if (sendStreamBox.Text != "")
                {
                    clf.Text = "Please select file containing echo stream packets...";
                    clf.ShowDialog();

                    fileHandler.ResetList();
                    echoStreamBox.Text = clf.FileNameRequested;
                    fileHandler.LoadPacketsFromFiles(clf.FileNameRequested);
                    var EchoPackets = fileHandler.PacketsReadFromFile;
                    matcher.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(EchoPackets, fileHandler.SensorIP);

                    if (sendStreamBox.Text != "" && echoStreamBox.Text != "")
                    {
                        ClearButton.Enabled = true;
                        GraphButton.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(String.Format("Error!\nThere appears to have been an issue while processing files.\n{0}", ex.InnerException.Message));
            };
        }

        private void StepFunctionForm_Load(object sender, EventArgs e)
        {

        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            matcher.MatchPackets();

            var dataSeriesCollection = graphingChart.Series;
            var dataSeries = dataSeriesCollection["graphingSeries"];

            if (matcher.RoundTripTimes.Count > 0)
            {
                for (int i = 0; i < matcher.RoundTripTimes.Count; i++)
                {
                    dataSeries.Points.AddXY(i + 1, matcher.RoundTripTimes[i]);
                }

                this.graphingChart.Series["graphingSeries"] = dataSeries;
                this.graphingChart.Enabled = true;

                String legible = "";

                foreach (String s in matcher.PairedMatches.Values)
                {
                    legible = $"{legible}\n{s}";
                }

                MessageBox.Show(legible);
            }

            else
            {
                MessageBox.Show(String.Format("Error! No matches were detected from files:\n{0}\n{1}", sendStreamBox.Text, echoStreamBox.Text));
            }
        
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearButton.Enabled = false;
            GraphButton.Enabled = false;
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
    }
}
