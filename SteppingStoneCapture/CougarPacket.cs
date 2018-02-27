using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;
using System.Net;
using System.IO;
using System;

namespace SteppingStoneCapture
{
    /// <summary>
    /// Describes a packet with basic properties and functionale
    /// </summary>
    /// <remarks>
    /// Properties:
    ///     TimeStamp
    ///     PacketNumber
    ///     Length/PacketSize
    ///     Source IP Address
    ///     Destination Ip Address
    ///     Type
    ///     Flags
    ///     
    /// </remarks>
    public class CougarPacket
    {
        private int packetNumber;
        private string timeStamp;
        private int length;
        private IpV4Address sourceAddress;
        private IpV4Address destAddress;
        private int srcPort;
        private int dstPort;
        private int chkSum;
        private uint seqNum;
        private uint ackNum;
        private Datagram payload;
        private byte[] payloadData;      
        




        public string TimeStamp { get => timeStamp; set => timeStamp = value; }
        public int PacketNumber { get => packetNumber; set => packetNumber = value; }
        public int Length { get => length; set => length = value; }
        public IpV4Address SourceAddress { get => sourceAddress; set => sourceAddress = value; }
        public IpV4Address DestAddress { get => destAddress; set => destAddress = value; }
        public int SrcPort { get => srcPort; set => srcPort = value; }
        public int DstPort { get => dstPort; set => dstPort = value; }
        public int ChkSum { get => chkSum; set => chkSum = value; }
        public uint SeqNum { get => seqNum; set => seqNum = value; }
        public uint AckNum { get => ackNum; set => ackNum = value; }
        public Datagram Payload { get => payload; set => payload = value; }
        public byte[] PayloadData { get => payloadData;  }
        
        
        

        public CougarPacket(string timeStamp = "-",
                            int packetNumber = 0,
                            int length = 0,
                            string sourceIp = "-",
                            string destinationIp = "-",
                            int srcPort = 0,
                            int dstPort = 0,
                            int chkSum = 0,
                            uint seqNum = 0,
                            uint ackNum = 0,
                            Datagram payload = null,
                            byte[] payloadData = null)
        {
            TimeStamp = timeStamp;
            PacketNumber = packetNumber;
            Length = length;
            sourceAddress = new IpV4Address(sourceIp);
            destAddress = new IpV4Address(destinationIp);
            this.srcPort = srcPort;
            this.dstPort = dstPort;
            this.chkSum = chkSum;
            this.seqNum = seqNum;
            this.ackNum = ackNum;            
            this.payload = payload;
        }

        public void getPayload()
        {
            if (payload != null)
            {
                using (MemoryStream ms = payload.ToMemoryStream())
                {
                    payloadData = new byte[payload.Length];
                    ms.Read(payloadData, 0, payload.Length);
                }
            }            
        }

        public override string ToString()
        {
            string description = string.Format("Packet #: {0}, TimeStamp: {1}, Length: {2}, SrcAddress: {3}, DstAddress: {4}, SrcPort: {5}, DstPort: {6}, CheckSum: {7}, Sequence #: {8}, Ack #: {9}, Payload: {10}",
                                                PacketNumber,
                                                TimeStamp,
                                                Length,
                                                SourceAddress,
                                                DestAddress,
                                                SrcPort,
                                                DstPort,
                                                ChkSum,
                                                SeqNum,
                                                AckNum,
                                                BitConverter.ToString(payloadData).Replace("-", " "));
            return description;
        }

        public string[] ToPropertyArray
        {
            get
            {
                string[] propertyArray = new string[10];

                propertyArray[0] = PacketNumber.ToString();
                propertyArray[1] = TimeStamp.ToString();
                propertyArray[2] = SourceAddress.ToString() == getLocalIP() ? "My Computer" : SourceAddress.ToString();
                propertyArray[3] = DestAddress.ToString() == getLocalIP() ? "My Computer" : DestAddress.ToString();
                propertyArray[4] = Length.ToString();
                propertyArray[5] = SrcPort.ToString();
                propertyArray[6] = DstPort.ToString();
                propertyArray[7] = ChkSum.ToString();
                propertyArray[8] = SeqNum.ToString();
                propertyArray[9] = AckNum.ToString();

                return propertyArray;
            }
        }

        private string getLocalIP()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
    }
}

