using System;
using System.IO;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools

{
    internal partial class CustomLoadForm : Form
    {
        private OpenFileDialog ofd;
        private string fileNameRequested;

        public CustomLoadForm()
        {
            InitializeComponent();
            this.Text = "Load from Dump File...";
            FileNameRequested = "";
            
        }

        public CustomLoadForm(string title, string description)
        {
            this.Text = title;          

        }
        
        public string FileNameRequested { get => fileNameRequested; set => fileNameRequested = value; }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DetermineDumpFilePath();
        }

        private void Accept_Click(object sender, EventArgs e) => Close();

        private void DetermineDumpFilePath()
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                AddExtension = extensionChkBox.Checked
            };

            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    if (ofd.FileName != "")
                    {
                        FilePathTextBox.Text += ofd.FileName;
                        FileNameRequested = ofd.FileName;
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
