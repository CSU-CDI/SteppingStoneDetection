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
            var sendQ = new Queue<CougarPacket>();

            for (int ndx = 0; ndx < ConnectionPackets.Count; ++ndx)
            {
                var current = ConnectionPackets[ndx];

                switch (current.Type)
                {
                    case TCPType.SEND:
                        sendQ.Enqueue(current);
                        SendPackets.Add(current);
                        break;

                    case TCPType.ECHO:
                        EchoPackets.Add(current);

                        if (sendQ.Count > 0)
                        {
                            var send = sendQ.Dequeue();

                            DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                            DateTime.TryParse(send.TimeStamp, out DateTime sendT);
                            double rtt = CalculateRoundTripTime(echoT, sendT);
                            RoundTripTimes.Add(rtt);

                            PairedMatches.Add(base.NumberOfMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}", send.PacketNumber, current.PacketNumber, ' '));
                        }

                        break;
                }
            }
        }
    }
}
