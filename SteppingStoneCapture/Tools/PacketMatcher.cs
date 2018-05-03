using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteppingStoneCapture.Tools
{
    /*
     * Class that encapsulates necessary data for further classes to implement specific packet matching algorithm, namely:
     *  - First Match
     *  - Conservative
     *  - Heuristic 
     * 
     *  All extending classees must override MatchPackets method
     */
    abstract class PacketMatcher
    {
        // data structures
        private Queue<CougarPacket> sendPackets;
        private List<CougarPacket> echoPackets;
        private List<double> roundTripTimes;

        // default constructor for PacketMatcher
        public PacketMatcher()
        {
            SendPackets = new Queue<CougarPacket>();
            EchoPackets = new List<CougarPacket>();
            RoundTripTimes = new List<double>();
        }

        // Properties of Packet Matchers
        public List<CougarPacket> EchoPackets { get => (List<CougarPacket>)echoPackets; set => echoPackets = value; }
        public Queue<CougarPacket> SendPackets { get => sendPackets; set => sendPackets = value; }
        public List<double> RoundTripTimes { get => (List<double>)roundTripTimes; set => roundTripTimes = value; }

        /*
         * Calculates Round Trip Time for the connection chain by comparing echoes' to their corresponding sends' timestamps
         * 
         * <param name="echoT"/>
         * <param name="sendT"/>
         *  
         *  <return>Difference of the send's (start) to the echo's timestamp. Result = echoT - sendT</return>
         */
        public static double CalculateRoundTripTime(DateTime echoT, DateTime sendT)
        {
            return Math.Abs(echoT.Subtract(sendT).TotalMilliseconds);
        }

        public void ResetMatcher()
        {
            SendPackets.Clear();
            EchoPackets.Clear();
            RoundTripTimes.Clear();
        }

        public abstract void MatchPackets();
    }
}
