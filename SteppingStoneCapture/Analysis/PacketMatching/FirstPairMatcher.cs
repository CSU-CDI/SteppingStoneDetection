using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// PacketMatcher that implements the first-match algorithm
    /// </summary>
    class FirstPairMatcher : PacketMatcher
    {

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

                            PairedMatches.Add(base.nbrMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}: {2, -25}", send.PacketNumber, current.PacketNumber, rtt, ' '));
                        }

                        break;
                }
            }



            //var sendQ = new Queue<CougarPacket>(SendPackets);
            //// For every captured echo packet,
            //for (int i = 0; i < this.EchoPackets.Count; i++)
            //{
            //    CougarPacket echo = EchoPackets[i];

            //    DateTime.TryParse(echo.TimeStamp, out DateTime echoT);

            //    if (SendPackets.Count > 0)
            //    {

            //        // gather current send packet's timestamp
            //        CougarPacket send = sendQ.Dequeue();

            //        DateTime.TryParse(send.TimeStamp, out DateTime sendT);

            //        // add the round trip time to the resultant list
            //        RoundTripTimes.Add(CalculateRoundTripTime(echoT, sendT));
            //        // Console.WriteLine(String.Format("Send #{0} matches Echo #{1}", send.PacketNumber, echo.PacketNumber));
            //        PairedMatches.Add(base.nbrMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}", send.PacketNumber, echo.PacketNumber, ' '));
            //    }
            //}
        }
    }
}
