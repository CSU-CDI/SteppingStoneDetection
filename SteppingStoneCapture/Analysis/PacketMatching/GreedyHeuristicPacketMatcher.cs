using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// Implements the Greedy-Heuristic Packet Matching algorithm
    /// </summary>
    /// <remarks>
    /// Author: Andrew Lesh
    /// </remarks>
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
            Console.WriteLine("this is greedy");
          //  bool correctMatch = true;
            var sendQ = new Queue<Tuple<CougarPacket, int>>();
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
                        SendIndex++;
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
                        }

                        // add the packet to the queue if within threshold
                        else sendQ.Enqueue(Tuple.Create<CougarPacket,int>(current, SendIndex));
                        break;
                    // if it is an echo packet  
                    case TCPType.ECHO:
                        EchoIndex++;
                        if (sendQ.Count > 0)
                        {
                            // gather the first send packet from the queue
                            var sendTuple = sendQ.Dequeue();
                            var send = sendTuple.Item1;

                            EchoPackets.Add(current);
                            
                            // determine whether they match, or not
                            if ((current.SeqNum >= send.AckNum) && (current.AckNum > send.SeqNum))// && correctMatch)
                            {
                                // if they match, calculate the Round Trip Time

                                // RTT = TimeOfEcho - TimeOfSend
                                DateTime.TryParse(current.TimeStamp, out DateTime echoT);
                                DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                                var rtt = CalculateRoundTripTime(echoT, sendT);
                                RoundTripTimes.Add(rtt);

                                // Format a string declaring the Send and Echo Match
                                PairedMatches.Add(NumberOfMatches++, String.Format("(S#{0}, Packet#{1}), (E#{2}, Packet#{3}), RTT = {4}", sendTuple.Item2, send.PacketNumber, EchoIndex, current.PacketNumber, rtt));
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
