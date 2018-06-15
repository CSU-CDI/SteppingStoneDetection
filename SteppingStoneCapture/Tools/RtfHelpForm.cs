using System;
using System.IO;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools
{
    /// <summary>
    /// Form that will open a RTF file from a specified path
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// <author>
    /// Andrew Lesh
    /// </author>
    public partial class RtfHelpForm : Form
    {
        public RtfHelpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor to load the correct help RTF file
        /// </summary>
        /// <param name="helpFilePath"></param>
        public RtfHelpForm(string helpFilePath)
        {
            InitializeComponent();
            // Verify that the file exists
            if (File.Exists(helpFilePath))
            {
                // Open a file stream to represent the RTF file
                using (FileStream helpFile = File.OpenRead(helpFilePath))
                {
                    // Load the stream to the RichTextBox in RTF form
                    richTextBox.LoadFile(helpFile, RichTextBoxStreamType.RichText);
                }
            }
            else
            {
                MessageBox.Show(String.Format("Error locating:\n {0}", helpFilePath));
            }
        }

        public static void ShowHelp(string helpFileName)
        {
            string curDir = System.IO.Directory.GetCurrentDirectory();//Environment.SystemDirectory.ToString();
            Tools.RtfHelpForm hhf = new Tools.RtfHelpForm(String.Format(@"{0}\Resources\{1}", curDir, helpFileName))
            {
                Text = "Step-Function in a LAN Network Configuration"
            };

            hhf.ShowDialog();
        }
    }
}
