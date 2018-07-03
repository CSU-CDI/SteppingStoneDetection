using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    class ConservativeMatcher : PacketMatcher
    {
        private double threshold;

        public double Threshold { get => threshold; set => threshold = value; }

        public ConservativeMatcher():base()
        {
            Tools.TextInput ti = new Tools.TextInput("Enter acceptable send packet time difference[in milliseconds]: ");
            ti.Text = "Set Time Difference Threshold";
            ti.ShowDialog();

            var input = ti.InputtedText;

            Console.WriteLine(input);
            Double.TryParse(input, out double tg);

            Threshold = tg;
        }
        public ConservativeMatcher(double threshold) : base()
        {
            Threshold = threshold;
        }

        /// <summary>
        /// Attempts to match each echo packet with the oldest, available send packet
        /// </summary>
        public override void MatchPackets()
        {
            bool correctMatch = true;
            var sendQ = new Queue<CougarPacket>();
            bool firstPacket = true;

            //for every packet
            for (int ndx = 0; ndx < ConnectionPackets.Count; ++ndx)
            {
                var current = ConnectionPackets[ndx];

                //determine the type
                switch (current.Type)
                {
                    // if it is a send packet
                    case TCPType.SEND:
                        DateTime lastTime = new DateTime();
                        SendPackets.Add(current);
                        // if this will be the first packet in the queue
                        if (firstPacket)
                        {
                            // "initialize" the value for last packet's time to this packet's
                            DateTime.TryParse(current.TimeStamp, out lastTime);
                            // clear flag for the next run
                            firstPacket = false;
                        }

                        // parse the current packet's time stamp
                        DateTime.TryParse(current.TimeStamp, out DateTime currentTime);

                        // calculate time elapsed between send packets
                        double tg = currentTime.Subtract(lastTime).TotalMilliseconds;


                        // reset queue and flags if beyond threshold amount
                        if (tg > Threshold)
                        {
                            sendQ.Clear();
                            firstPacket = true;
                            correctMatch = true;
                        }

                        // add the packet to the queue if within threshold
                        else sendQ.Enqueue(current);
                        break;
                    // if it is an echo packet  
                    case TCPType.ECHO:
                        // gather the first potMatch packet from the queue
                        if (sendQ.Count > 0)
                        {
                            var send = sendQ.Dequeue();
                            EchoPackets.Add(current);
                            // determine whether they match, or not
                            if ((current.SeqNum == send.AckNum) && (current.AckNum > send.SeqNum) && correctMatch)
                            {
                                // if they match, calculate the Round Trip Time

                                // RTT = TimeOfEcho - TimeOfSend
                                DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                                DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                                RoundTripTimes.Add(CalculateRoundTripTime(echoT, sendT));

                                PairedMatches.Add(nbrMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}", send.PacketNumber, current.PacketNumber, ' '));
                            }
                            else
                                correctMatch = false;
                        }
                        break;
                }
            }

        }

        /// <summary>
        /// Statically Attempts to match each echo packet with the oldest, available potMatch packet
        /// </summary>
        /// <param name="SendPackets">
        ///     Queue of potMatch packets captured
        /// </param>
        /// <param name="EchoPackets">
        ///     List of echo packets captured
        /// </param>
        /// <returns>
        ///     List of calculated RTTs
        /// </returns>
        public static List<double> MatchPackets(Queue<CougarPacket> SendPackets, List<CougarPacket> EchoPackets)
        {
            // Empty list for resulting RTTs
            List<double> result = new List<double>();
            for (int i = 0; i < EchoPackets.Count; i++)
            {
                // gather current echo packet's timestamp
                CougarPacket echo = EchoPackets[i];
                DateTime.TryParse(echo.TimeStamp, out DateTime echoT);

                // reset match flag
                bool matched = false;

                while (SendPackets.Count > 0 && !matched)
                {
                    // gather current potMatch packet's timestamp
                    CougarPacket send = SendPackets.Dequeue();
                    DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                    // if it matches the current echo packet
                    if (echo.AckNum == send.SeqNum)
                    {
                        // set the match flag to proceed to the next echo
                        matched = true;
                        // add the round trip time to the resultant list
                        result.Add(CalculateRoundTripTime(echoT, sendT));
                    }
                }

                // Report error if all potMatch packets have been processed and no match was found
                if (SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }
            }
            return result;
        }
    }
}
