using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    class GreedyHeuristicPacketMatcher : ConservativeMatcher
    { 
        public GreedyHeuristicPacketMatcher():base()
        {
            Algorithm = MatchingAlgorithm.GREEDY_HEURISTIC;
        }
        public GreedyHeuristicPacketMatcher(double threshold):base(threshold)
        {
            Algorithm = MatchingAlgorithm.GREEDY_HEURISTIC;
        }

        public override void MatchPackets()
        {
          //  bool correctMatch = true;
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
                           // correctMatch = true;
                        }

                        // add the packet to the queue if within threshold
                        else sendQ.Enqueue(current);
                        break;
                    // if it is an echo packet  
                    case TCPType.ECHO:
                        if (sendQ.Count > 0)
                        {
                            // gather the first send packet from the queue
                            var send = sendQ.Dequeue();
                            EchoPackets.Add(current);
                            // determine whether they match, or not
                            if ((current.SeqNum >= send.AckNum) && (current.AckNum > send.SeqNum))// && correctMatch)
                            {
                                // if they match, calculate the Round Trip Time

                                // RTT = TimeOfEcho - TimeOfSend
                                DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                                DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                                RoundTripTimes.Add(CalculateRoundTripTime(echoT, sendT));

                                PairedMatches.Add(base.NumberOfMatches++, String.Format("Send #{0,-20}{2,15} <======== matches ========>{2,25} Echo #{1,-20}", send.PacketNumber, current.PacketNumber, ' '));
                            }
                        }
                      //  else
                         //   correctMatch = false;
                        break;
                }
            }
        }
    }
}
