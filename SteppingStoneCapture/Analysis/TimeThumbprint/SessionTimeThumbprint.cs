using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Icmp;
using PcapDotNet.Packets.Arp;

namespace SteppingStoneCapture.Analysis.TimeThumbprint
{
    public partial class SessionTimeThumbprint : Form
    {
        private List<DateTime> incomingTime;
        private List<DateTime> outgoingTime;
        private List<int> incSeq;
        private List<int> outSeq;
        private int numMatches;
        private int numIncPackets;
        private double matchThres;
        private double compThres;
        public SessionTimeThumbprint()
        {
            InitializeComponent();
            outgoingTime = new List<DateTime>();
            incomingTime = new List<DateTime>();
            incSeq = new List<int>();
            outSeq = new List<int>();
            numMatches = 0;
            numIncPackets = 0;
            matchThres = 0;
            compThres = 0;
        }

        private void incButton_Click(object sender, EventArgs e)
        {
            Tools.FileHandler incoming = new Tools.FileHandler();
            incoming.LoadPacketsFromFiles();
            for (int i = 0; i< incoming.PacketsReadFromFile.Count;i++) {

                Packet p = incoming.PacketsReadFromFile[i];
                incomingTime.Add(p.Timestamp);

            }
            numIncPackets = incomingTime.Count;
            incomingBox.Text = incoming.getPath();
        }

        private void outButton_Click(object sender, EventArgs e)
        {
            Tools.FileHandler outgoing = new Tools.FileHandler();
            outgoing.LoadPacketsFromFiles();
            for (int i = 0; i < outgoing.PacketsReadFromFile.Count; i++)
            {

                Packet p = outgoing.PacketsReadFromFile[i];
                outgoingTime.Add(p.Timestamp);

            }
            numIncPackets = outgoingTime.Count;
            outgoingBox.Text = outgoing.getPath();
        }

        private void generateSeq() {

            for (int i = 0; i < incomingTime.Count - 1; i++)
            {
                TimeSpan diff = incomingTime.ElementAt(i + 1) - incomingTime.ElementAt(i);
                int gap = diff.Milliseconds;
                incSeq.Add(gap);

            }

            for (int i = 0; i < incSeq.Count; i++)
            {
                if (i == incSeq.Count - 1)
                {
                    isLabel.Text += " " + incSeq.ElementAt(i).ToString();
                }
                else
                {
                    isLabel.Text += " " + incSeq.ElementAt(i).ToString() + ",";
                }
            }

            for (int i = 0; i < outgoingTime.Count - 1; i++)
            {
                TimeSpan diff = outgoingTime.ElementAt(i + 1) - outgoingTime.ElementAt(i);
                int gap = diff.Milliseconds;
                outSeq.Add(gap);

            }
            for (int i = 0; i < outSeq.Count; i++)
            {
                if (i == outSeq.Count - 1)
                {
                    osLabel.Text += " " + outSeq.ElementAt(i).ToString();
                }
                else
                {
                    osLabel.Text += " " + outSeq.ElementAt(i).ToString() + ",";
                }
            }

        }

        private void compare()
        {
            //generateSeq();
            numMatches = 0;
            int currentBIndex = 0;
            int zero = 0;
            int one = 1;
            int two = 2;
            int three = 3;
            int four = 4;
            //generateSeq();
            for (int i = 0; i < incSeq.Count; i++)
            {
                List<double> percentages = new List<double>();
                if ((currentBIndex + zero) < outSeq.Count)
                {
                    if (outSeq.ElementAt(currentBIndex + zero) == 0)
                    {
                    }
                    else
                    {
                        
                        double perc = (double)(Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + zero))) / (double)Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + zero));
                        //Console.WriteLine(perc);
                        //oseq.Text += perc.ToString();
                        //percentages.Add(perc);
                    }
                }
                if ((currentBIndex + one) < outSeq.Count)
                {
                    if (outSeq.ElementAt(currentBIndex + one) == 0)
                    {
                    }
                    else
                    {
                        
                        double perc = (double)(Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + one))) / (double)Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + one));
                        //Console.WriteLine(perc);
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + two) < outSeq.Count)
                {
                    if (outSeq.ElementAt(currentBIndex + two) == 0)
                    {
                    }
                    else
                    {
                        
                        double perc = (double)(Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + two))) / (double)Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + two));
                        //Console.WriteLine(perc);
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + three) < outSeq.Count)
                {
                    if (outSeq.ElementAt(currentBIndex + three) == 0)
                    {
                    }
                    else
                    {
                        
                        double perc = (double)(Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + three))) / (double)Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + three));
                        //Console.WriteLine(perc);
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + four) < outSeq.Count)
                {
                    if (outSeq.ElementAt(currentBIndex + four) == 0)
                    {
                    }
                    else
                    {
                        
                        double perc = (double)(Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + four))) / (double)Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + four));
                        percentages.Add(perc);
                    }
                }

                double bm = percentages.Max();
                double mt = 0.58;
                //Console.WriteLine(matchBox.Text);
                //double.Parse(matchBox.Text, System.Globalization.CultureInfo.InvariantCulture)
                if (bm >= matchThres)
                {
                    numMatches += 1;
                }
                int bmIndex = percentages.IndexOf(bm) + 1;
                currentBIndex = currentBIndex + bmIndex + 1;
                if (currentBIndex > outSeq.Count - 1)
                {
                    break;
                }

                //if ((5 + currentBIndex) < outSeq.Count)
                //{
                //List<double> percentages = new List<double>();
                //for (int j = 0; j < 5; i++)
                //{
                //double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + j)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + j)));
                //  percentages.Add(perc);
                //}
                //double bm = percentages.Max();
                // int bmIndex = percentages.IndexOf(bm) + 1;
                //   currentBIndex = bmIndex + 1;

                // }
                // else {

                //}
                //}
            }
        }

        private void simllarity()
        {
            double st = 0.70;
            //Console.WriteLine((double)numMatches / (double)numIncPackets);
            if (((double)numMatches / (double)numIncPackets) >= compThres)
            {
                //Console.WriteLine("It's a match. The host machine is a Stepping Stone");
                MessageBox.Show("It's a match. The host machine is a Stepping Stone");
            }
            else
            {
                //Console.WriteLine("It's not a match. The host machine is not a Stepping Stone");
                MessageBox.Show("It's not a match. The host machine is not a Stepping Stone");
            }
        }

        private void compButton_Click(object sender, EventArgs e)
        {

            //Console.WriteLine(matchBox.Text);
            matchThres = Convert.ToDouble(numericMatch.Value);
            //Console.WriteLine(matchThres);
            //matchThres = double.Parse(matchBox.Text);
            //matchThres = Convert.ToDouble(numericMatch.Value);
            //compThres = double.Parse(similarityBox.Text);
            compThres = Convert.ToDouble(numericSim.Value);
            generateSeq();
            compare();
            simllarity();
        }
        private void resetProperties() {
            outgoingTime = new List<DateTime>();
            incomingTime = new List<DateTime>();
            incSeq = new List<int>();
            outSeq = new List<int>();
            numMatches = 0;
            numIncPackets = 0;
            matchThres = 0;
            compThres = 0;
            isLabel.Text = "Incoming Sequence: ";
            osLabel.Text = "Outgoing Sequence: ";
            incomingBox.Text = "";
            outgoingBox.Text = "";

        }
        private void outgoingBox_TextChanged(object sender, EventArgs e)
        {
            compButton.Enabled = true;
        }

        private void incomingBox_TextChanged(object sender, EventArgs e)
        {
            outButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetProperties();
            outButton.Enabled = false;
            compButton.Enabled = false;
            numericMatch.Value = 0;
            numericSim.Value = 0;
        }
    }
}
