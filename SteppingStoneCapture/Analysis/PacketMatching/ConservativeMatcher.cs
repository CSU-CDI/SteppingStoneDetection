using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    class ConservativeMatcher : PacketMatcher
    {
        private double threshold;
        // Value to store the acceptable time gap between Send packets, in ms
        public double Threshold { get => threshold; set => threshold = value; }

        /// <summary>
        /// Constructor for Conservative Packet Matcher
        /// 
        /// <para>
        /// Asks for Threshold value to be entered by user using a TextInput Form
        /// </para> 
        /// </summary>
        public ConservativeMatcher():base()
        {
            Algorithm = MatchingAlgorithm.CONSERVATIVE;

            // Ask user to input the acceptable time gap
            Tools.TextInput ti = new Tools.TextInput("Enter acceptable send packet time difference[in milliseconds]: ");

            // sets the title in the TextInput Form
            ti.Text = "Set Time Difference Threshold";

            // Show formatted form to user
            ti.ShowDialog();

            // gather their response
            var input = ti.InputtedText;

            // Try to parse the input into a double   Console.WriteLine(input);
            Double.TryParse(input, out double tg);
            Threshold = tg;
            //Console.WriteLine(tg);
        }

        /// <summary>
        /// Constructor for a Conservative Matcher that accepts an inputted time gap
        /// </summary>
        /// <param name="threshold"></param>
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

                                // Format a string declaring the Send and Echo Match
                                PairedMatches.Add(NumberOfMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}", send.PacketNumber, current.PacketNumber, ' '));
                            }
                            else
                                // negate the Match flag otherwise
                                correctMatch = false;
                        }
                        break;
                }
            }

        }
    }
}
