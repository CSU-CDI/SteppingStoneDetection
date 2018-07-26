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
        private Dictionary<char, int> InChar, OutChar;        
        private Dictionary<char, Tuple<int, int>> totalCount;        
        private Dictionary<char, double> charRatios;
        private SortedDictionary<char, double> resultsOverThreshold;
        
        

        public int Incount { get => incount; set => incount = value; }
        public int Outcount { get => outcount; set => outcount = value; }

        public ContentThumbprint()
        {
            InitializeComponent();
            btnOk.Enabled = false;
            chkPacketCount.Checked = true;
            InputStreamFile = null;
            OutputStreamFile = null;
            InFile = null;
            OutFile = null;
            Visible = true;
            Incount = 0;
            Outcount = 0;
            InChar = new Dictionary<char, int>();
            OutChar = new Dictionary<char, int>();            
            totalCount = new Dictionary<char, Tuple<int, int>>();
            charRatios = new Dictionary<char, double>();
            resultsOverThreshold = new SortedDictionary<char, double>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void chkPacketCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPacketCount.Checked)
            {
                chkCharFreq.Checked = false;
                chkCharFreqTime.Checked = false;
            }               
        }

        private void chkCharFreq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharFreq.Checked)
            {
                chkPacketCount.Checked = false;
                chkCharFreqTime.Checked = false;
            }
                
        }

        private void chkCharFreqTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharFreqTime.Checked)
            {
                chkPacketCount.Checked = false;
                chkCharFreq.Checked = false;
            }                
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
                    if (ofd.FileName != "" && File.Exists(ofd.FileName))
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
                    if (ofd.FileName != "" && File.Exists(ofd.FileName))
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
                Cursor = Cursors.WaitCursor;
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

                double ratio = 1d - ((double)(Math.Abs(Incount - Outcount))/(double)Math.Max(Incount, Outcount));

                Cursor = Cursors.Default;

                if (ratio >= (double)numericUpDown1.Value)
                    MessageBox.Show("Stepping-Stone Detected! Ratio: " + ratio);
                else
                    MessageBox.Show("Not a Stepping-Stone! Ratio: " + ratio);
                Incount = Outcount = 0;
            }
            else if (chkCharFreq.Checked)
            {
                Cursor = Cursors.WaitCursor;
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
                        {
                            InChar.Add(c, 1);                            
                        }
                        else
                        {
                            InChar[c]++;
                        }                        
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
                            OutChar[c]++;
                    }
                }
                
                OutFile.Close();
                
                // begin iterating through char count and adding values to total count                
                foreach (char c in InChar.Keys)
                {
                    if (OutChar.ContainsKey(c))
                    {                        
                        totalCount.Add(c, Tuple.Create(InChar[c], OutChar[c]));
                    }
                }               

                // calculate ratios and add them to dictionary as values with their corresponding hex vals as keys
                foreach (char c in totalCount.Keys)
                {   
                    charRatios.Add(c, (1d - (double)((Math.Abs((double)totalCount[c].Item1 - (double)totalCount[c].Item2)) 
                        / Math.Max((double)totalCount[c].Item1, (double)totalCount[c].Item2))));                                        
                }                

                foreach (char c in charRatios.Keys)
                {
                    if (charRatios[c] >= (double)numericUpDown1.Value && !resultsOverThreshold.ContainsKey(c))
                    {
                        resultsOverThreshold.Add(c, charRatios[c]);
                    }
                }

                string formattedResults = "Chars Greather than threshold:\nChar : Ratio\n";

                foreach (char c in resultsOverThreshold.Keys)
                    formattedResults += c + " : " + resultsOverThreshold[c] + "\n";
                if (formattedResults.Equals("Chars Greather than threshold:\nChar : Ratio\n"))
                    formattedResults = "No results over threshold!";

                Cursor = Cursors.Default;
                MessageBox.Show(formattedResults);               

                InChar.Clear();
                OutChar.Clear();
                totalCount.Clear();
                charRatios.Clear();
                resultsOverThreshold.Clear();

            }
            else if (chkCharFreqTime.Checked)
            {
                InFile = new StreamReader(InputStreamFile);
                OutFile = new StreamReader(OutputStreamFile);

            }
        }
    }
}
