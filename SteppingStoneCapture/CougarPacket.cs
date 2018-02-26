﻿using PcapDotNet.Packets.IpV4;
using System.Net;

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

        public string TimeStamp { get => timeStamp; set => timeStamp = value; }
        public int PacketNumber { get => packetNumber; set => packetNumber = value; }
        public int Length { get => length; set => length = value; }
        public IpV4Address SourceAddress { get => sourceAddress; set => sourceAddress = value; }
        public IpV4Address DestAddress { get => destAddress; set => destAddress = value; }
        
        public CougarPacket(string timeStamp = "-",
                            int packetNumber = 0,
                            int length = 0,
                            string sourceIp = "-",
                            string destinationIp = "-")
        {
            TimeStamp = timeStamp;
            PacketNumber = packetNumber;
            Length = length;
            sourceAddress = new IpV4Address(sourceIp);
            destAddress = new IpV4Address(destinationIp);
        }

        public override string ToString()
        {
            string description = string.Format("{0},{1},{2},{3},{4}",
                                                PacketNumber,
                                                TimeStamp,
                                                Length,
                                                SourceAddress,
                                                DestAddress);
            return description;
        }

        public string[] ToPropertyArray
        {
            get
            {
                string[] propertyArray = new string[5];

                propertyArray[0] = PacketNumber.ToString();
                propertyArray[1] = TimeStamp.ToString();
                propertyArray[2] = SourceAddress.ToString() == getLocalIP() ? "My Computer" : SourceAddress.ToString();
                propertyArray[3] = DestAddress.ToString() == getLocalIP() ? "My Computer" : DestAddress.ToString();
                propertyArray[4] = Length.ToString();

                return propertyArray;
            }
        }

        private string getLocalIP()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
    }
}
