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
            var clf = new Tools.CustomLoadForm();
            clf.Text = "Please select file containing send stream packets...";
            clf.ShowDialog();

            string sendFileName = clf.FileNameRequested;

            clf.Text = "Please select file containing echo stream packets...";
            clf.ShowDialog();

            string echoFileName = clf.FileNameRequested;


        }

        private void StepFunctionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
