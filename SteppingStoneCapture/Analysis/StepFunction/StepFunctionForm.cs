using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteppingStoneCapture.Analysis
{
    public partial class StepFunctionForm : Form
    {
        private StepFunctionDetector detector;

        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
            detector = new StepFunctionDetector();
        }

        private void loadStreamFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.FileHandler fileHandler = new Tools.FileHandler();
            try
            {
                var clf = new Tools.CustomLoadForm();
                clf.Text = "Please select file containing send stream packets...";
                clf.ShowDialog();

                sendStreamBox.Text = clf.FileNameRequested;
                fileHandler.LoadPacketsFromFiles(clf.FileNameRequested);
                var SendPackets = new List<PcapDotNet.Packets.Packet>(fileHandler.PacketsReadFromFile);
                detector.SendPackets = new Queue<CougarPacket>(CougarPacket.ConvertRawPacketsToCougarPackets(SendPackets, fileHandler.SensorIP));
                                                                                              
                if (sendStreamBox.Text != "")
                {
                    clf.Text = "Please select file containing echo stream packets...";
                    clf.ShowDialog();

                    fileHandler.ResetList();
                    echoStreamBox.Text = clf.FileNameRequested;
                    fileHandler.LoadPacketsFromFiles(clf.FileNameRequested);
                    var EchoPackets = fileHandler.PacketsReadFromFile;
                    detector.EchoPackets = CougarPacket.ConvertRawPacketsToCougarPackets(EchoPackets, fileHandler.SensorIP);

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
            if (detector.RoundTripTimes.Count > 0)
            {
                detector.CalculateRoundTripTimes();

                var dataSeriesCollection = this.graphingChart.Series;
                var dataSeries = dataSeriesCollection["graphingSeries"];
                
                for (int i = 0; i < detector.RoundTripTimes.Count; i++)
                {
                    dataSeries.Points.AddXY((double)(i + 1), detector.RoundTripTimes[i]); 
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
            detector.ResetDetector();
        }
    }
}
