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
    public partial class CrossOverPacket : Form
    {
        string InputStreamFile, OutputStreamFile, results;
        StreamReader SendFile, EchoFile;
        List<Tuple<string, string, DateTime>> SendList, EchoList;
        List<string> crossovers;
        int crossoverCount;


        public CrossOverPacket()
        {
            InitializeComponent();
            Visible = true;
            btnOk.Enabled = false;
            SendFile = null;
            EchoFile = null;
            InputStreamFile = null;
            OutputStreamFile = null;
            crossovers = new List<string>();
            SendList = new List<Tuple<string, string, DateTime>>();
            EchoList = new List<Tuple<string, string, DateTime>>();
            results = "";
            crossoverCount = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SendFile = new StreamReader(InputStreamFile);
            EchoFile = new StreamReader(OutputStreamFile);
            string line;
            string[] lineItems;

            try
            {
                // read send file info
                while ((line = SendFile.ReadLine()) != null)
                {                    
                    lineItems = line.Split(',');                    
                    SendList.Add(Tuple.Create("send", lineItems[0].Trim(), DateTime.Parse(lineItems[1].Trim())));
                
                }
                SendFile.Close();
            

                // read echo file info
                while ((line = EchoFile.ReadLine()) != null)
                {
                    lineItems = line.Split(',');
                    EchoList.Add(Tuple.Create("echo", lineItems[0].Trim(), DateTime.Parse(lineItems[1].Trim())));
                }
                EchoFile.Close();
            

            // create new list sorted by packet number from send and echo lists
            var sortedList = new List<Tuple<string, string, DateTime>>((SendList.Concat(EchoList)).OrderBy(combinedList => int.Parse(combinedList.Item2)).ToList());            

            // flag to indicate the beginning of a cross over
            bool inCrossOver = false;

                // determine whether or not cross over exists
                // TODO: review this to make sure the logic is correct concerning the time condition
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;
                for (int i = 0; i < sortedList.Count - 1; i++)
                {
                    if (sortedList[i].Item1.Equals("send"))
                    { // if next packet is send packet and it's number is less than prev send packet
                        if (!inCrossOver)
                        {
                            start = sortedList[i].Item3;
                        }
                        if (sortedList[i+1].Item1.Equals("send")/* && int.Parse(sortedList[i+1].Item2) < int.Parse(sortedList[i].Item2)*/)
                        {                        
                            inCrossOver = true;
                            crossovers.Add(sortedList[i].Item1 + " " + sortedList[i].Item2 + " " + sortedList[i].Item3.ToString("hh:mm:ss.fff"));
                        } 
                        else if (inCrossOver && sortedList[i+1].Item1.Equals("echo")/* && int.Parse(sortedList[i+1].Item2) < int.Parse(sortedList[i].Item2)*/)
                        {
                            end = sortedList[i+1].Item3;
                            inCrossOver = false;
                            crossoverCount++;
                            crossovers.Add(sortedList[i].Item1 + " " + sortedList[i].Item2 + " " + sortedList[i].Item3.ToString("hh:mm:ss.fff"));
                            crossovers.Add(sortedList[i+1].Item1 + " " + sortedList[i+1].Item2 + " " + sortedList[i+1].Item3.ToString("hh:mm:ss.fff"));
                            TimeSpan span = end.Subtract(start);
                            crossovers.Add("RTT: " + span.Milliseconds.ToString() + " ms");
                            crossovers.Add("----------------------------------------");
                        }
                    }                    
                }

                // format results                
                if (crossovers.Count < 1)
                {
                    results = "No Cross Over packets detected!";
                }
                else
                {
                    results = "Cross Over packets detected!\n" + "Cross Over Count: " + crossoverCount + "\nSend/Echo\tPacket#\tTimestamp" + "\n----------------------------------------\n";
                    foreach (var item in crossovers)
                    {
                        results += item + "\n";
                    }
                }
                
                // output and ask user if they want to save results
                if (MessageBox.Show("Save Results?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        Filter = "txt files (*.txt)|*.txt",
                    };

                    if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                    {                        
                        File.WriteAllText(sfd.FileName, results);                        
                    }
                    MessageBox.Show(results, "Results");
                }
                else
                {
                    MessageBox.Show(results, "Results");
                }
                crossoverCount = 0;
                crossovers.Clear();
                SendList.Clear();
                EchoList.Clear();
            }
            catch (Exception)
            {                
                MessageBox.Show("Unable to read send or echo text file!");
            }
            finally
            {
                Cursor = Cursors.Default;
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "txt files (*.txt)|*.txt",
            };            

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "" && File.Exists(ofd.FileName))
            {                
                txtInputStream.Text = ofd.FileName;
                InputStreamFile = ofd.FileName;
                if (OutputStreamFile != null)
                    btnOk.Enabled = true;                
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "txt files (*.txt)|*.txt",
            };            

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "" && File.Exists(ofd.FileName))
            {
                txtOutputStream.Text = ofd.FileName;
                OutputStreamFile = ofd.FileName;
                if (InputStreamFile != null)
                    btnOk.Enabled = true;                
            }
        }
    }
}
