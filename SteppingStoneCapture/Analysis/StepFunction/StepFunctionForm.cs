using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis
{
    public partial class StepFunctionForm : Form
    {
        private Tools.PacketMatcher matcher;
        private Tools.FileHandler fileHandler;

        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
            matcher = new Tools.FirstPairMatcher();
            fileHandler = new Tools.FileHandler();
        }

        private void LoadStreamFilesItem_Click(object sender, EventArgs e)
        {           

            if (firstMatchRadio.Checked)
                matcher = new Tools.FirstPairMatcher();

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

            }catch (Exception ex)
            {
            
                MessageBox.Show(String.Format("Error!\nThere appears to have been an issue while processing files.\n{0}",ex.InnerException.Message));
            };
        }

        private void StepFunctionForm_Load(object sender, EventArgs e)
        {

        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            if (matcher.RoundTripTimes.Count > 0)
            {
                matcher.MatchPackets();

                var dataSeriesCollection = this.graphingChart.Series;
                var dataSeries = dataSeriesCollection["graphingSeries"];
                
                for (int i = 0; i < matcher.RoundTripTimes.Count; i++)
                {
                    dataSeries.Points.AddXY((double)(i + 1), matcher.RoundTripTimes[i]); 
                }

                this.graphingChart.Series["graphingSeries"] = dataSeries;
                this.graphingChart.Enabled = true;
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

        private void loadStreamFIlesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
