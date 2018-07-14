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
    /// 
    /// <remarks> 
    /// Author: Andrew Lesh
    /// </remarks>
    abstract class PacketMatcher
    {
        // data structures
        private List<CougarPacket> sendPackets;
        private List<CougarPacket> echoPackets;
        private List<CougarPacket> connectionPackets;

        private List<double> roundTripTimes;
        private Dictionary<double, string> pairedMatches;
        private int nbrMatches = 0, sendIndex = 0, echoIndex = 0;
        private MatchingAlgorithm algorithm;

        // default constructor for PacketMatcher
        public PacketMatcher()
        {
            SendPackets = new List<CougarPacket>();
            EchoPackets = new List<CougarPacket>();
            RoundTripTimes = new List<double>();
            PairedMatches = new Dictionary<double, string>();
            Algorithm = MatchingAlgorithm.FIRST;
        }

        // Properties of Packet Matchers
        public List<CougarPacket> EchoPackets { get => echoPackets; set => echoPackets = value; }
        public List<CougarPacket> SendPackets { get => sendPackets; set => sendPackets = value; }
        public Dictionary<double, string> PairedMatches { get => pairedMatches; set => pairedMatches = value; }
        public List<CougarPacket> ConnectionPackets { get => connectionPackets; set => connectionPackets = value; }
        public MatchingAlgorithm Algorithm { get => algorithm; set => algorithm = value; }
        public List<double> RoundTripTimes { get => roundTripTimes; set => roundTripTimes = value; }
        protected int NumberOfMatches { get => nbrMatches; set => nbrMatches = value; }
        public int SendIndex { get => sendIndex; set => sendIndex = value; }
        public int EchoIndex { get => echoIndex; set => echoIndex = value; }


        /// <summary>
        /// Calculates Round Trip Time for the connection chain by comparing echoes' to their corresponding sends' timestamps
        /// </summary>
        /// <param name="echoT">
        /// Time stamp from echo packet
        /// </param>
        /// <param name="sendT">
        /// Time stamp from send packet
        /// </param>
        /// <returns>
        /// Round Trip Time calculated by finding the difference between the packets' times stamps
        /// </returns>
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
            NumberOfMatches = 0;
            EchoIndex = 0;
            SendIndex = 0;
            PairedMatches.Clear();
        }

        /// <summary>
        /// Abstract method that must be implemented by descendent classes
        /// </summary>
        public abstract void MatchPackets();
    }
}
