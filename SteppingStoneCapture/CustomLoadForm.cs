using System;
using System.IO;
using System.Windows.Forms;

namespace SteppingStoneCapture
{
    internal partial class CustomLoadForm : Form
    {
        private OpenFileDialog ofd;
        private string dumpFileNameRequested;

        public CustomLoadForm()
        {
            InitializeComponent();
            this.Text = "Load from Dump File...";
            DumpFileNameRequested = "";
        }

        public CustomLoadForm(string title, string description)
        {
            this.Text = title;          

        }

        public string DumpFileNameRequested { get => dumpFileNameRequested; set => dumpFileNameRequested = value; }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DetermineDumpFilePath();
        }

        private void Accept_Click(object sender, EventArgs e) => Close();

        private void DetermineDumpFilePath()
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    if (ofd.FileName != "")
                    {
                        FilePathTextBox.Text += ofd.FileName;
                        DumpFileNameRequested = ofd.FileName;
                    }

                    break;
                default:
                    DialogResult res = MessageBox.Show("No File Path Found...","Try Again?", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes) DetermineDumpFilePath();
                    break;
            }
        }

       
    }
}
