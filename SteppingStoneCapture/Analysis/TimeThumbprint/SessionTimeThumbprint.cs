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
        private List<long> incSeq;
        private List<long> outSeq;
        private int numMatches;
        private int numIncPackets;
        private double matchThres;
        private double compThres;
        public SessionTimeThumbprint()
        {
            InitializeComponent();
            outgoingTime = new List<DateTime>();
            incomingTime = new List<DateTime>();
            incSeq = new List<long>();
            outSeq = new List<long>();
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
                TimeSpan diff = incomingTime.ElementAt(i + 1) - incomingTime.ElementAt(i + 1);
                long gap = diff.Ticks;
                incSeq.Add(gap);

            }

            for (int i = 0; i < incSeq.Count; i++)
            {
                isLabel.Text += " " + incSeq.ElementAt(i).ToString() + ",";
            }

            for (int i = 0; i < outgoingTime.Count - 1; i++)
            {
                TimeSpan diff = outgoingTime.ElementAt(i + 1) - outgoingTime.ElementAt(i);
                long gap = diff.Ticks;
                outSeq.Add(gap);

            }
            for (int i = 0; i < outSeq.Count; i++)
            {
                osLabel.Text += " " + outSeq.ElementAt(i).ToString() + ",";
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
                if ((currentBIndex + zero) <= incSeq.Count)
                {
                    if (incSeq.ElementAt(i) == 0 || outSeq.ElementAt(currentBIndex + zero) == 0)
                    {
                    }
                    else
                    {
                        double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + zero)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + zero)));
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + 0) <= incSeq.Count)
                {
                    if (incSeq.ElementAt(i) == 0 || outSeq.ElementAt(currentBIndex + one) == 0)
                    {
                    }
                    else
                    {
                        double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + one)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + one)));
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + two) <= incSeq.Count)
                {
                    if (incSeq.ElementAt(i) == 0 || outSeq.ElementAt(currentBIndex + two) == 0)
                    {
                    }
                    else
                    {
                        double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + two)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + two)));
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + three) <= incSeq.Count)
                {
                    if (incSeq.ElementAt(i) == 0 || outSeq.ElementAt(currentBIndex + three) == 0)
                    {
                    }
                    else
                    {
                        double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + three)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + three)));
                        percentages.Add(perc);
                    }
                }
                if ((currentBIndex + four) <= incSeq.Count)
                {
                    if (incSeq.ElementAt(i) == 0 || outSeq.ElementAt(currentBIndex + four) == 0)
                    {
                    }
                    else
                    {
                        double perc = (Math.Abs(incSeq.ElementAt(i) - outSeq.ElementAt(currentBIndex + four)) / Math.Max(incSeq.ElementAt(i), outSeq.ElementAt(currentBIndex + four)));
                        percentages.Add(perc);
                    }
                }

                double bm = percentages.Max();
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

        private void compButton_Click(object sender, EventArgs e)
        {
            generateSeq();
            //compare();
        }
    }
}
