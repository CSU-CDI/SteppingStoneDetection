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
    class FirstPairMatcher : PacketMatcher
    {
        public FirstPairMatcher() : base()
        {
            Algorithm = MatchingAlgorithm.FIRST_PAIR;
        }
        /// <summary>
        /// Attempts to match each echo packet with the oldest, available send packet
        /// </summary>
        public override void MatchPackets()
        {
            var sendQ = new Queue<Tuple<CougarPacket, int>>();

            for (int ndx = 0; ndx < ConnectionPackets.Count; ++ndx)
            {
                var current = ConnectionPackets[ndx];
                
                switch (current.Type)
                {
                    case TCPType.SEND:                        
                        sendQ.Enqueue(Tuple.Create<CougarPacket,int>(current, SendIndex++));
                        SendPackets.Add(current);
                        break;

                    case TCPType.ECHO:
                        EchoPackets.Add(current);

                        if (sendQ.Count > 0)
                        {
                            var sendTuple = sendQ.Dequeue();
                            var send = sendTuple.Item1;

                            DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                            DateTime.TryParse(send.TimeStamp, out DateTime sendT);

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
