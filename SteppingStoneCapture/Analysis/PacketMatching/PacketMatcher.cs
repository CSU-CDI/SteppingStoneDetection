using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Analysis.PacketMatching
{
    /// <summary>
    /// Class that encapsulates necessary data for further classes to implement specific packet matching algorithm, namely:
    ///    First Match, Conservative, Greedy
    ///
    /// All extending classes must override MatchPackets method
    /// </summary>
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

        /// <summary>
        /// Calculates Round Trip Time for the connection chain by comparing echoes' to their corresponding sends' timestamps
        /// </summary>
        /// <param name="echoT"></param>
        /// <param name="sendT"></param>
        /// <returns>  </returns>
        public static double CalculateRoundTripTime(DateTime echoT, DateTime sendT)
        {
            return Math.Abs(echoT.Subtract(sendT).TotalMilliseconds);
        }

        /// <summary>
        ///  Resets the fields of the Packet Matcher Instance
        /// </summary>
        public void ResetMatcher()
        {
            SendPackets.Clear();
            EchoPackets.Clear();
            RoundTripTimes.Clear();
        }

        public abstract void MatchPackets();
    }
}
