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
        string InputStreamFile, OutputStreamFile;
        StreamReader SendFile, EchoFile;
        List<Tuple<string, string, DateTime>> SendList, EchoList;
        List<string> crossovers;


        public CrossOverPacket()
        {
            InitializeComponent();
            Visible = true;
            btnOk.Enabled = false;
            SendFile = EchoFile = null;
            InputStreamFile = OutputStreamFile = null;
            crossovers = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string s = "03:56:38.994";
            Boolean TimeParseSuccess = DateTime.TryParse(s, out DateTime dt);
            Console.WriteLine(dt.ToString("hh:mm:ss.fff"));

            Cursor = Cursors.WaitCursor;
            SendFile = new StreamReader(InputStreamFile);
            EchoFile = new StreamReader(OutputStreamFile);
            string line;
            string[] lineItems;


            try
            {

                while ((line = SendFile.ReadLine()) != null)
                {
                    lineItems = line.Split(',');

                    SendList.Add(Tuple.Create("send", lineItems[0].Trim(), DateTime.Parse(lineItems[1].Trim())));
                }
                SendFile.Close();

                while ((line = EchoFile.ReadLine()) != null)
                {
                    lineItems = line.Split(',');

                    EchoList.Add(Tuple.Create("echo", lineItems[0].Trim(), DateTime.Parse(lineItems[1].Trim())));

                }
                EchoFile.Close();

                // ----------------------------------------------------------------------------------------------------

                //List<Tuple<string, string, DateTime>> mergedList = new List<Tuple<string, string, DateTime>>(SendList.Count + EchoList.Count);
                /*mergedList.AddRange(SendList);
                mergedList.AddRange(EchoList);*/

                //SendList.ForEach(p => mergedList.Add(p));
                //EchoList.ForEach(p => mergedList.Add(p));

                //List<Tuple<string, string, DateTime>> sortedList = mergedList.OrderBy(d => d.Item3).ToList();
                //List<Tuple<string, string, DateTime>> sortedList = new List<Tuple<string, string, DateTime>>((SendList.Concat(EchoList)).OrderBy(d => d.Item3).ToList());

                // create new list sorted by time of day from send and echo lists
                var sortedList = new List<Tuple<string, string, DateTime>>((SendList.Concat(EchoList)).OrderBy(d => d.Item3).ToList());

                for (int i = 0; i < sortedList.Count - 1; i++)
                {
                    if (sortedList[i].Item1.Equals("send"))
                    {
                        if (!sortedList[i + 1].Item1.Equals("echo"))
                        {
                            crossovers.Add(sortedList[i].Item1 + " " + sortedList[i].Item2 + " " + sortedList[i].Item3.ToString("hh:mm:ss.fff"));
                            crossovers.Add(sortedList[i + 1].Item1 + " " + sortedList[i + 1].Item2 + " " + sortedList[i + 1].Item3.ToString("hh:mm:ss.fff"));
                        }
                    }
                }

                string results;
                if (crossovers.Count < 1)
                {
                    results = "No Cross Over packets detected!";
                }
                else
                {
                    results = "Cross Over packets detected!\n\n";
                    foreach (var item in crossovers)
                    {
                        results += item + "\n";
                    }
                }

                MessageBox.Show(results);

            }
            catch (Exception)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Unable to read send or outgoing text file!");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            // ----------------------------------------------------------------------------------------------------
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
            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    if (ofd.FileName != "" && File.Exists(ofd.FileName))
                    {
                        txtInputStream.Text = ofd.FileName;
                        InputStreamFile = ofd.FileName;
                        if (OutputStreamFile != null)
                            btnOk.Enabled = true;
                    }
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
    }
}
