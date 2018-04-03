using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Transport;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        private string tcpFlags;
        private Datagram payload;
        private byte[] payloadData;
        private IpV4Address sensorIP;

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
        public byte[] PayloadData { get => payloadData; }
        public string TCPFlags { get => tcpFlags; set => tcpFlags = value; }
        public IpV4Address SensorIP { get => sensorIP; set => sensorIP = value; }


        public CougarPacket(string timeStamp = "-",
                            int packetNumber = 0,
                            int length = 0,
                            string sourceIp = "0.0.0.0",
                            string destinationIp = "0.0.0.0",
                            string sensorIP = "0.0.0.0",
                            int srcPort = 0,
                            int dstPort = 0,
                            int chkSum = 0,
                            uint seqNum = 0,
                            uint ackNum = 0,
                            string tcpFlags = "",
                            Datagram payload = null,
                            byte[] payloadData = null)
        {
            TimeStamp = timeStamp;
            PacketNumber = packetNumber;
            Length = length;
            SourceAddress = new IpV4Address(sourceIp);
            DestAddress = new IpV4Address(destinationIp);
            SrcPort = srcPort;
            DstPort = dstPort;
            ChkSum = chkSum;
            SeqNum = seqNum;
            AckNum = ackNum;
            TCPFlags = tcpFlags;
            if (sensorIP == "0.0.0.0") SensorIP = new IpV4Address(getLocalIP());
            Payload = payload;
            setPayloadData(payloadData);
        }

        public void setPayloadData(byte[] inArr)
        {
            if (inArr != null)
            {
                this.payloadData = new byte[inArr.Length];
                for (int i = 0; i < inArr.Length; ++i)
                {
                    this.payloadData[i] = inArr[i];
                }
            }
            else this.payloadData = null;
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
            string pay = (payloadData != null) ? BitConverter.ToString(payloadData).Replace("-", "") : "nil";
            string flags = (tcpFlags.Length > 1) ? tcpFlags.Replace(',', ';') : "---";
            string description = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11},{12}",
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
                                                flags,
                                                pay,
                                                SensorIP);
            return description;
        }


        public string[] ToPropertyArray
        {
            get
            {
                string[] propertyArray = new string[11];
                propertyArray[0] = PacketNumber.ToString();
                propertyArray[1] = TimeStamp.ToString();
                propertyArray[2] = SourceAddress.ToString() == getLocalIP() ? "My Computer" : SourceAddress.ToString();
                propertyArray[3] = DestAddress.ToString() == getLocalIP() ? "My Computer" : DestAddress.ToString();
                propertyArray[4] = Length.ToString();

                propertyArray[5] = (SrcPort == 0) ? "---" : SrcPort.ToString();
                propertyArray[6] = (DstPort == 0) ? "---" : DstPort.ToString();
                propertyArray[7] = (ChkSum == 0) ? "---" : ChkSum.ToString();
                propertyArray[8] = (SeqNum == 0) ? "---" : SeqNum.ToString();
                propertyArray[9] = (AckNum == 0) ? "---" : AckNum.ToString();
                propertyArray[10] = (TCPFlags.Length < 2) ? "---" : TCPFlags;


                return propertyArray;
            }
        }

        private string getLocalIP()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
    }
}

