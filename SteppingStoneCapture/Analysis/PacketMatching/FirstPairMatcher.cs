using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// PacketMatcher that implements the first-match algorithm
    /// <para>
    /// Every Echo packet is matched to the next available Send packet; regardless of ACK/SEQ # relation
    /// </para>
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
    class FirstPairMatcher : PacketMatcher
    {
        public FirstPairMatcher() : base()
        {
            this.Algorithm = MatchingAlgorithm.FIRST_PAIR;
        }
        /// <summary>
        /// Attempts to match each echo packet with the oldest, available send packet
        /// </summary>
        public override void MatchPackets()
        {
           // Console.WriteLine("this is in first match");
            // Initialize the Send Packet Queue
            var sendQ = new Queue<Tuple<CougarPacket, int>>();

            // Match every Echo Packet to the First, Available Send Packet
            for (int ndx = 0; ndx < ConnectionPackets.Count; ++ndx)
            {
                // Gather the current packet
                var current = ConnectionPackets[ndx];
                
                // determine TCP type
                switch (current.Type)
                {
                    // Add the packet to the Queue if it's a Send
                    case TCPType.SEND:    
                        // add the packet and the send packet number to the queue
                        sendQ.Enqueue(Tuple.Create<CougarPacket,int>(current, SendIndex++));
                        // add the packet to a list for external use
                        SendPackets.Add(current);
                        break;
                   // Match the packet to the first packet in the Queue if it's an Echo
                    case TCPType.ECHO:
                        // add the packet to a list of echo packets for external use
                        EchoPackets.Add(current);
                        EchoIndex++;
                        // if there is a send packet to match
                        if (sendQ.Count > 0)
                        {
                            // take the first send packet out of the queue
                            var sendTuple = sendQ.Dequeue();
                            var send = sendTuple.Item1;

                            // parse the send and echos packets' timestamps
                            DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                            DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                            // calculate the round trip time 
                            // RTT = echoT - sendT
                            var rtt = CalculateRoundTripTime(echoT, sendT);
                            RoundTripTimes.Add(rtt);

                            // Format a string declaring the Send and Echo Match
                            PairedMatches.Add(NumberOfMatches++, String.Format("(S#{0}, Packet#{1}), (E#{2}, Packet#{3}), RTT = {4}", sendTuple.Item2, send.PacketNumber, EchoIndex, current.PacketNumber, rtt));
                        }

                        break;
                }
            }
        }
    }
}
