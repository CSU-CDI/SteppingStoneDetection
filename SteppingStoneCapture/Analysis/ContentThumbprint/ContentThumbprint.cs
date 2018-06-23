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
    public partial class ContentThumbprint : Form
    {
        string InputStreamFile, OutputStreamFile;
        StreamReader InFile, OutFile;
        int incount, outcount;
        private Dictionary<Char, int> InChar;
        private Dictionary<Char, int> OutChar;

        public int Incount { get => incount; set => incount = value; }
        public int Outcount { get => outcount; set => outcount = value; }

        public ContentThumbprint()
        {
            InitializeComponent();
            btnOk.Enabled = false;
            chkPacketCount.Checked = true;
            InputStreamFile = OutputStreamFile = null;
            InFile = OutFile = null;
            Visible = true;
            Incount = Outcount = 0;
            InChar = new Dictionary<char, int>();
            OutChar = new Dictionary<char, int>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void chkPacketCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPacketCount.Checked)
                chkCharFreq.Checked = false;
                chkCharFreqTime.Checked = false;
        }

        private void chkCharFreq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharFreq.Checked)
                chkPacketCount.Checked = false;
                chkCharFreqTime.Checked = false;
        }

        private void chkCharFreqTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharFreqTime.Checked)
                chkPacketCount.Checked = false;
                chkCharFreq.Checked = false;
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "txt files (*.txt)|*.txt",
            };
            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    if (ofd.FileName != "")
                    {
                        txtInputStream.Text = ofd.FileName;
                        InputStreamFile = ofd.FileName;
                        if (OutputStreamFile != null)
                            btnOk.Enabled = true;                    }
                    break;
                default:                   
                    break;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "txt files (*.txt)|*.txt",
            };
            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    if (ofd.FileName != "")
                    {
                        txtOutputStream.Text = ofd.FileName;
                        OutputStreamFile = ofd.FileName;
                        if (InputStreamFile != null)
                            btnOk.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string line;
            if (chkPacketCount.Checked)
            {
                InFile = new StreamReader(InputStreamFile);
                OutFile = new StreamReader(OutputStreamFile);                
                

                while ((line = InFile.ReadLine()) != null)
                {
                    ++Incount;
                }
                InFile.Close();

                while ((line = OutFile.ReadLine()) != null)
                {
                    ++Outcount;
                }
                OutFile.Close();
            }
            else if (chkCharFreq.Checked)
            {
                InFile = new StreamReader(InputStreamFile);
                OutFile = new StreamReader(OutputStreamFile);
                string[] lineItems;
                
                // read lines from incoming stream file
                while ((line = InFile.ReadLine()) != null)
                {
                    lineItems = line.Split(',');                    

                    // read contents by char and add to dict if not already there and set val to 1, then if already there, increment val
                    foreach (char c in lineItems[11].Trim())
                    {
                        if (!InChar.ContainsKey(c))                        
                            InChar.Add(c, 1);                        
                        else                        
                            ++InChar[c];                        
                    }                    
                }
                InFile.Close();

                // read lines from outgoing stream file
                while ((line = OutFile.ReadLine()) != null)
                {
                    lineItems = line.Split(',');

                    // read contents by char and add to dict if not already there and set val to 1, then if already there, increment val
                    foreach (char c in lineItems[11].Trim())
                    {
                        if (!OutChar.ContainsKey(c))
                            OutChar.Add(c, 1);
                        else
                            ++OutChar[c];
                    }
                }
                OutFile.Close();

            }
            else if (chkCharFreqTime.Checked)
            {
                InFile = new StreamReader(InputStreamFile);
                OutFile = new StreamReader(OutputStreamFile);

            }
        }
    }
}
