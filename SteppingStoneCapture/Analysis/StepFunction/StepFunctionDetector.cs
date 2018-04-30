using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Packets;

namespace SteppingStoneCapture.Analysis
{
    class StepFunctionDetector
    {
        private Queue<CougarPacket> sendPackets;
        private IList<CougarPacket> echoPackets;
        private IList<double> roundTripTimes;

        public StepFunctionDetector()
        {
            SendPackets = new Queue<CougarPacket>();
            EchoPackets = new List<CougarPacket>();
            RoundTripTimes = new List<double>();
        }

        public List<CougarPacket> EchoPackets { get => (List<CougarPacket>) echoPackets; set => echoPackets = value; }
        public Queue<CougarPacket> SendPackets { get => sendPackets; set => sendPackets = value; }
        public List<double> RoundTripTimes { get => (List<double>) roundTripTimes; set => roundTripTimes = value; }

        public void CalculateRoundTripTimes()
        {
            for (int i = 0; i < EchoPackets.Count; i++)
            {
                CougarPacket echo = EchoPackets[i];
                DateTime echoT, sendT;
                DateTime.TryParse(echo.TimeStamp, out echoT);
                bool matched = false;

                while(SendPackets.Count > 0 && !matched)
                {
                    CougarPacket send = SendPackets.Dequeue();
                    DateTime.TryParse(send.TimeStamp, out sendT);

                    if (echo.AckNum == send.SeqNum)
                    {
                        matched = true;
                        RoundTripTimes.Add(echoT.Subtract(sendT).TotalMilliseconds);
                    }
                }

                if(SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }

               
            }
        }

        public void ResetDetector()
        {
            SendPackets.Clear();
            EchoPackets.Clear();
            RoundTripTimes.Clear();            
        }
    }
}
