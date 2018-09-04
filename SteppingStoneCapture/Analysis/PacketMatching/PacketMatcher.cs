using System;
using System.Collections.Generic;
using System.Linq;

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
        private double maxValue, minValue, average, standardDeviation;

        private const int numberOfDeviations = 2;

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

        public static double NumberOfDeviations => numberOfDeviations;

        public double MaxValue { get => maxValue; set => maxValue = value; }
        public double MinValue { get => minValue; set => minValue = value; }
        public double Average { get => average; set => average = value; }
        public double StandardDeviation { get => standardDeviation; set => standardDeviation = value; }

        public static int DecimalShiftValue { get; set; } = 6;


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
            return Math.Abs(echoT.Subtract(sendT).TotalSeconds) * Math.Pow(10, DecimalShiftValue);
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
            Average = 0;
            StandardDeviation = 0;
            EchoIndex = 0;
            SendIndex = 0;
            PairedMatches.Clear();
        }

        /// <summary>
        /// Parses the list of paired matches to compile a description
        /// </summary>
        /// <returns>
        /// Either:
        /// - List of paired matches followed by statistics
        /// - "No Matches Detected."
        /// </returns>
        public string ParseResults()
        {
            if (PairedMatches.Values.Count > 0)
            {
                CalculateExtremeValues();
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                // gather data on the results
                var numSend = SendPackets.Count;
                var numEcho = EchoPackets.Count;
                var numTot = ConnectionPackets.Count;

                // Print the matches to the results' text box
                foreach (string s in PairedMatches.Values)
                {
                    stringBuilder.AppendLine(s);
                }

                return FormatMatchStatistics(numSend, numEcho, numTot, stringBuilder);
            }

            return "No matches detected.";
        }

        /// <summary>
        /// Formats the results of the mathcing algorithm and returns a string describing them
        /// </summary>
        /// <param name="numSend">
        /// Number of Send Packets that were matched
        /// </param>
        /// <param name="numEcho">
        /// Number of Echo Packets that were matched
        /// </param>
        /// <param name="results">
        /// The listing of matched packets
        /// </param>
        /// <returns>
        /// String containing the list of matched packets as well as a statistics footer
        /// </returns>
        private string FormatMatchStatistics(int numSend, int numEcho, int numTot, System.Text.StringBuilder results)
        {
            // Print the numerical details describing the results
            results.AppendLine();
            results.AppendLine($"Total Number Packets: {numTot}");
            results.AppendLine($"Number Send Packets: {numSend}          Number Echo Packets: {numEcho}");
            results.AppendLine();
            results.AppendLine( $"Number of Matches: {PairedMatches.Count}");
            results.AppendLine(String.Format("Percentage matched of all possible pairs: {0:F}%", (100 * PairedMatches.Count / Math.Min(numSend, numEcho))));
            results.AppendLine($"RTT:\n    Min = {MinValue}    Max = {MaxValue}\n    Avg. = {Average}    Std. Dev = {StandardDeviation}");
            return results.ToString();
        }

        public void CalculateExtremeValues()
        {
            if (RoundTripTimes.Count > 0)
            {
                // initialize average to the first element
                double avg = RoundTripTimes[0],
                       max = RoundTripTimes[0],
                       min = RoundTripTimes[0];
                // sum all following Round Trip Times
                for (int ndx = 1; ndx < RoundTripTimes.Count; ++ndx)
                {
                    avg += RoundTripTimes[ndx];

                    if (max < RoundTripTimes[ndx])
                        max = RoundTripTimes[ndx];
                    else if (min > RoundTripTimes[ndx])
                        min = RoundTripTimes[ndx];
                }

                // Divide the total Round Trip Time by the number of matches
                avg /= RoundTripTimes.Count;
                Average = avg;

                double radicand = Math.Pow(RoundTripTimes[0]-avg, 2);

                for (int ndx = 1; ndx < RoundTripTimes.Count; ++ndx)
                {
                    radicand += Math.Pow(RoundTripTimes[ndx]-avg,2);
                }

                radicand /= RoundTripTimes.Count;

                double stdDev = Math.Sqrt(radicand);
                StandardDeviation = stdDev;

                MaxValue = avg + (NumberOfDeviations * stdDev);
                MinValue = avg - (NumberOfDeviations * stdDev);
            }
        }
        /// <summary>
        /// Abstract method that must be implemented by descendent classes
        /// </summary>
        public abstract void MatchPackets();
    }
}
