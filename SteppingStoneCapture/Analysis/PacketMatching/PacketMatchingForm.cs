using System;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// Enumeration of available algortihms
    /// </summary>
    public enum MatchingAlgorithm
    {
        // Enumerates the algorithms from 0 -> n
        FIRST_PAIR,
        CONSERVATIVE,
        GREEDY_HEURISTIC,
        // Add Algorithms Elements above this comment
        NBR_ALGORITHMS,
        // Replace these if different Max/Min values are wanted for the form's NumericUpDowm
        FIRST = FIRST_PAIR,// These could be renamed Min/Max
        LAST = GREEDY_HEURISTIC
    }

    /// <summary>
    /// Form used to display the results of using a selected packet matching algorithm on
    /// a connection file
    /// </summary>
    /// 
    /// <remarks> 
    /// Author: Andrew Lesh
    /// </remarks>
    public partial class PacketMatchingForm : Form
    {
        private PacketMatchingFormController controller;

        /// <summary>
        /// Initializes the form to use the First-Match algorihm
        /// </summary>
        /// <remarks>
        /// The term First-Pair is merely used to circumvent using First-Match Matching Algorithm
        /// </remarks>
        public PacketMatchingForm()
        {
            InitializeComponent();
            controller = new PacketMatchingFormController();
            this.Visible = true;
        }

        /// <summary>
        /// Initializes the form with necessary data input, depending on specified algorithm
        /// </summary>
        /// <param name="algo">
        /// MatchingAlgortihm Enumeration element detailing the algorithm to be used
        /// </param>
        public PacketMatchingForm(MatchingAlgorithm algo)
        {
            // Initializes the controls on the form
            InitializeComponent();

            // determine which algorithm is to be used
            controller = new PacketMatchingFormController(algo);
            this.Visible = true;
        }

        /// <summary>
        /// Event Handler for when the Run Button is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunBtn_Click(object sender, EventArgs e)
        {
            string algorithmResults = controller.RunAlgorithm();
            resTextBox.Text = algorithmResults;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            controller.ResetController();
            resTextBox.Text = "";
            fileTxtBox.Text = "";
        }
        
        private void ConnectionFileItem_Click(object sender, EventArgs e)
        {
            string filename = controller.LoadConnectionFile();
            fileTxtBox.Text = filename;
        }

        private void SaveTextItem_Click(object sender, EventArgs e)
        {
            controller.SaveResults();
        }
    }
}