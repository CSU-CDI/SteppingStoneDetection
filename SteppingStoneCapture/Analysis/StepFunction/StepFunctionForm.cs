using SteppingStoneCapture.Analysis.PacketMatching;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SteppingStoneCapture.Analysis.StepFunction
{
    /// <summary>
    /// Provides Graphical Data to allow users to estimate the number of downstream stepping-stones from a sensor host
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
    public partial class StepFunctionForm : Form
    {
        private StepFunctionFormController Controller;

        /// <summary>
        /// Default Constructor for the form initializing various controls and properties
        /// </summary>
        public StepFunctionForm()
        {
            InitializeComponent();
            Visible = true;
            Controller = new StepFunctionFormController();

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
            string results = Controller.RunAlgorithm((int)AlgorithmUpDown.Value);
            this.graphingChart = Controller.DisplayResults(graphingChart);

            // display the matches' descriptions to the user
            var rtf = new Tools.RtfHelpForm();
            rtf.AddText(results);


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
            graphingChart.Series[StepFunctionFormController.SeriesName].Points.Clear();
            foreach (Control c in fileGrpBox.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Text = "";
                }
            }
            Controller.Matcher.ResetMatcher();
            Controller.FileHandler.ResetList();
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
            string file = Controller.LoadConnectionFile();
            if (file != "")
            {
                fileTxtBox.Text = file;
                GraphButton.Enabled = true;
                ClearButton.Enabled = true;

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
            Controller.SaveGraphResults(graphingChart);
        }

        /// <summary>
        /// Saves the text description of the matches to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveTextItem_Click(object sender, EventArgs e)
        {
            Controller.SaveResults();
        }
    }
}
