using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    class ConservativeMatcher : PacketMatcher
    {
        /// <summary>
        /// Attempts to match each echo packet with the oldest, available send packet
        /// </summary>
        public override void MatchPackets()
        {
            // For every captured echo packet,
            for (int i = 0; i < this.EchoPackets.Count; i++)
            {
                //  Gather the echo's timestamp
                CougarPacket echo = EchoPackets[i];
                DateTime.TryParse(echo.TimeStamp, out DateTime echoT);

                // reset the match flag, since this is a new packet
                bool matched = false;

                //for every captured send packet,
                while (SendPackets.Count > 0 && !matched)
                {
                    // Gather the first, available send packet's time stamp
                    CougarPacket send = SendPackets.Dequeue();
                    DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                    // if it matches the current echo packet
                    if (echo.AckNum == send.SeqNum && send.SeqNum < echo.AckNum)
                    {
                        // set the match flag to proceed to the next echo
                        matched = true;
                        // add the round trip time to the resultant list
                        RoundTripTimes.Add(CalculateRoundTripTime(echoT, sendT));

                        PairedMatches.Add(base.nbrMatches++, String.Format("Send #{0} matches Echo #{1}", send.PacketNumber, echo.PacketNumber));
                    }
                }

                // Report error if all send packets have been processed and no match was found
                if (SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }
            }
        }

        /// <summary>
        /// Statically Attempts to match each echo packet with the oldest, available send packet
        /// </summary>
        /// <param name="SendPackets">
        ///     Queue of send packets captured
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
                    // gather current send packet's timestamp
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

                // Report error if all send packets have been processed and no match was found
                if (SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }
            }
            return result;
        }
    }
}
