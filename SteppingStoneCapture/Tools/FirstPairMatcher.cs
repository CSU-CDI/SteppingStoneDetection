using System;
using System.Collections.Generic;

namespace SteppingStoneCapture.Tools
{
    class FirstPairMatcher : PacketMatcher
    {
        public override void MatchPackets()
        {
            for (int i = 0; i < this.EchoPackets.Count; i++)
            {
                CougarPacket echo = EchoPackets[i];
                DateTime.TryParse(echo.TimeStamp, out DateTime echoT);
                bool matched = false;

                while (SendPackets.Count > 0 && !matched)
                {
                    CougarPacket send = SendPackets.Dequeue();
                    DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                    if (echo.AckNum == send.SeqNum)
                    {
                        matched = true;
                        RoundTripTimes.Add(CalculateRoundTripTime(echoT, sendT));
                    }
                }

                if (SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }
            }
        }

        public static List<double> MatchPackets(Queue<CougarPacket> SendPackets, List<CougarPacket> EchoPackets)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < EchoPackets.Count; i++)
            {
                CougarPacket echo = EchoPackets[i];
                DateTime.TryParse(echo.TimeStamp, out DateTime echoT);
                bool matched = false;

                while (SendPackets.Count > 0 && !matched)
                {
                    CougarPacket send = SendPackets.Dequeue();
                    DateTime.TryParse(send.TimeStamp, out DateTime sendT);

                    if (echo.AckNum == send.SeqNum)
                    {
                        matched = true;
                        result.Add(CalculateRoundTripTime(echoT, sendT));
                    }
                }

                if (SendPackets.Count == 0 && !matched)
                {
                    System.Windows.Forms.MessageBox.Show(String.Format("Error!\nNo match detected for:\nEcho No. {0}", echo.PacketNumber));
                }
            
            }
            return result;
        }
    }
}
