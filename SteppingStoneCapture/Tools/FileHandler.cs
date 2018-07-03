using PcapDotNet.Core;
using PcapDotNet.Packets;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools
{
    ///
    /// <summary>This is the main class for loading/saving packets to/from files.</summary>
    ///  <remarks>The class could be a collection of static functions, but instance variables are provided for ease of use with externals.
    /// This mainly pertains to the Sensor IP, however, extends to the list of raw packets (packets using the PCAP.NET defined Packet class).   </remarks>
    ///
    class FileHandler
    {
        private List<Packet> packetsReadFromFile;
        private string sensorIP;
        private string path;

        public FileHandler()
        {
            PacketsReadFromFile = new List<Packet>();
            SensorIP = "";
        }

        public List<Packet> PacketsReadFromFile { get => packetsReadFromFile; set => packetsReadFromFile = value; }
        public string SensorIP { get => sensorIP; set => sensorIP = value; }

        /// <summary>
        /// Calls the Custom Load Form to gather packet file location to load packets from
        /// </summary>
        public void LoadPacketsFromFiles()
        {
            // call up the custom loading form
            var clf = new CustomLoadForm();
            clf.ShowDialog();

            // gather requested file name and extension
            string loadPath = clf.FileNameRequested;
            path = loadPath;
            if (loadPath != "" && File.Exists(loadPath))
            {
                //Determine the correct file format
                switch (Path.GetExtension(loadPath))
                {
                    // If .pcap, use the PCAP.NET defined functions to dump packets
                    case (".pcap"):
                        // Create the offline device
                        OfflinePacketDevice selectedDevice = new OfflinePacketDevice(loadPath);

                        // Open the capture file
                        using (PacketCommunicator communicator =
                            selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                                        // 65536 guarantees that the whole packet will be captured on all the link layers
                                                PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                1000))                                  // read timeout
                        {
                            // Read and dispatch packets until EOF is reached
                            communicator.ReceivePackets(0, (Packet p) => PacketsReadFromFile.Add(p));
                            // (Packet p) => PacketsReadFromFile.Add(p) is a Lambda Expression with parameter Packet p and a body to add the packet to a list.
                        }
                        break;

                    case (".txt"):
                        string currentPacket;
                        string rawLoadPath = "";
                        string[] path = loadPath.Split('.');
                        if (!loadPath.Contains("_raw"))
                        {
                            rawLoadPath = path[0] + "_raw." + path[1];
                            System.Windows.Forms.MessageBox.Show(String.Format("{0}\n{1}\n{2}",
                                                                  "Clear Text file name detected.", "Error will occur if _raw file not found.",
                                                                  "Please load from the equivalent _raw file."));
                        }
                        else rawLoadPath = loadPath;

                        try
                        {
                            using (StreamReader raw_reader = new StreamReader(rawLoadPath))
                            {
                                //int currentIndex = 0;
                                string sens = raw_reader.ReadLine();
                                if (sens != null) SensorIP = sens;

                                while ((currentPacket = raw_reader.ReadLine()) != null)
                                {
                                    string[] packetInformation = currentPacket.Split(',');
                                    DateTime dt;
                                    dt = DateTime.Parse(packetInformation[1]);
                                    PcapDotNet.Packets.DataLink dl = new PcapDotNet.Packets.DataLink(PcapDotNet.Packets.DataLinkKind.Ethernet);
                                    UInt32.TryParse(packetInformation[3], out uint x);
                                    byte[] packetData = ConvertHexStringToByteArray(packetInformation[0].Replace("-", ""));
                                    PcapDotNet.Packets.Packet p = new PcapDotNet.Packets.Packet(packetData, dt, dl, x);

                                    PacketsReadFromFile.Add(p);
                                }

                            };
                        }

                        catch (FileNotFoundException fnfe)
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("One of the files needed to reconstruct the packets is missing:\n{0}", fnfe.FileName));
                        };
                        break;
                }
            }
        }

        /// <summary>
        /// Loads packets from the desired file at the inputted path
        /// </summary>
        /// <param name="loadPath"></param>
        public void LoadPacketsFromFiles(string loadPath)
        {
            if (loadPath != "" && File.Exists(loadPath))
            {
                switch (Path.GetExtension(loadPath))
                {
                    case (".pcap"):
                        // Create the offline device
                        OfflinePacketDevice selectedDevice = new OfflinePacketDevice(loadPath);

                        // Open the capture file
                        using (PacketCommunicator communicator =
                            selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                                        // 65536 guarantees that the whole packet will be captured on all the link layers
                                                PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                1000))                                  // read timeout
                        {
                            // Read and dispatch packets until EOF is reached
                            communicator.ReceivePackets(0, (Packet p) => PacketsReadFromFile.Add(p));
                        }
                        break;

                    case (".txt"):
                        string currentPacket;
                        string rawLoadPath = "";
                        string[] path = loadPath.Split('.');
                        if (!loadPath.Contains("_raw"))
                        {
                            rawLoadPath = path[0] + "_raw." + path[1];
                            System.Windows.Forms.MessageBox.Show(String.Format("{0}\n{1}\n",
                                                                  "Clear Text file name detected.", "Error will occur if _raw file not found."));
                        }
                        else rawLoadPath = loadPath;

                        try
                        {
                            using (StreamReader raw_reader = new StreamReader(rawLoadPath))
                            {
                                //int currentIndex = 0;
                                string sens = raw_reader.ReadLine();
                                if (sens != null) SensorIP = sens;

                                while ((currentPacket = raw_reader.ReadLine()) != null)
                                {
                                    string[] packetInformation = currentPacket.Split(',');
                                    DateTime dt;
                                    dt = DateTime.Parse(packetInformation[1]);
                                    PcapDotNet.Packets.DataLink dl = new PcapDotNet.Packets.DataLink(PcapDotNet.Packets.DataLinkKind.Ethernet);
                                    UInt32.TryParse(packetInformation[3], out uint x);
                                    byte[] packetData = ConvertHexStringToByteArray(packetInformation[0].Replace("-", ""));
                                    PcapDotNet.Packets.Packet p = new PcapDotNet.Packets.Packet(packetData, dt, dl, x);

                                    PacketsReadFromFile.Add(p);
                                }

                            };
                        }

                        catch (FileNotFoundException fnfe)
                        {
                            System.Windows.Forms.MessageBox.Show(String.Format("One of the files needed to reconstruct the packets is missing:\n{0}", fnfe.FileName));
                        };
                        break;
                }
            }
        }

        /// <summary>
        /// Statically save all necessary data from the raw packets to a .txt file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="packets"></param>
        /// <param name="packetBytes"></param>
        /// <param name="maxFilePackets"></param>
        public static void SavePacketsToTextFile(string fileName, List<Packet> packets, IList<byte[]> packetBytes, int maxFilePackets)
        {
            int indexF = 0;
            int countP = 0;
            string[] file = fileName.Split('.');
            //fileName.
            if (packetBytes.Count > 0)
            {
                //open file stream for mother file and raw mother file
                FileStream fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                StreamWriter fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);

                int i = 0;
                foreach (byte[] barr in packetBytes)
                {
                    if (countP % maxFilePackets == 0 && countP != 0)
                    {
                        indexF++;
                        fs.Close();
                        fsRaw.Close();
                        fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                        fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);
                    }
                    countP++;
                    fs.Write(barr, 0, barr.Length);
                    fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(packets[i].Buffer).Replace("-", ""), packets[i].Timestamp.ToString("hh:mm:ss.fff"), packets[i].DataLink, packets[i].OriginalLength));
                    ++i;
                }

                fs.Close();
                fsRaw.Close();
            }
        }

        /// <summary>
        /// Statically save all necessary data from the raw packet to a txt file with the inputted sensor ip
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="packets"></param>
        /// <param name="packetBytes"></param>
        /// <param name="maxFilePackets"></param>
        /// <param name="sensorIP"></param>
        public static void SavePacketsToTextFile(string fileName, List<Packet> packets, IList<byte[]> packetBytes, int maxFilePackets, string sensorIP)
        {
            int indexF = 0;
            int countP = 0;
            string[] file = fileName.Split('.');

            if (packetBytes.Count > 0)
            {
                //open file stream for mother file and raw mother file
                FileStream fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                StreamWriter fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);

                int i = 0;

                fsRaw.WriteLine(sensorIP);
                foreach (byte[] barr in packetBytes)
                {
                    if (countP % maxFilePackets == 0 && countP != 0)
                    {
                        indexF++;
                        fs.Close();
                        fsRaw.Close();
                        fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                        fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);
                        fsRaw.WriteLine(sensorIP);
                    }
                    countP++;
                    fs.Write(barr, 0, barr.Length);
                    fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(packets[i].Buffer).Replace("-", ""), packets[i].Timestamp.ToString("hh:mm:ss.fff"), packets[i].DataLink, packets[i].OriginalLength));
                    ++i;
                }

                fs.Close();
                fsRaw.Close();
            }

        }


        /// <summary>
        /// Statically save packets to txt or pcap format with a necessary data from the raw packets
        /// </summary>
        /// <param name="packets"></param>
        /// <param name="packetBytes"></param>
        /// <param name="maxFilePackets"></param>
        /// <param name="sensorIP"></param>
        public static void SavePackets(List<Packet> packets, IList<byte[]> packetBytes, int maxFilePackets, string sensorIP)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Dump Files (*.pcap)| *.pcap| Text File (*.txt)| *.txt |All files (*.*)|*.*",
                FilterIndex = 0
            };

            string dumpFileName = sfd.FileName;

            switch (sfd.ShowDialog())
            {
                case DialogResult.OK:
                    if (sfd.FileName != "")
                    {
                        dumpFileName = sfd.FileName;
                        if (sfd.FilterIndex == 1)
                        {

                            using (PacketCommunicator communicator =
                                    LivePacketDevice.AllLocalMachine[1].Open(65536,               // portion of the packet to capture
                                                                                      // 65536 guarantees that the whole packet will be captured on all the link layers
                                       PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                       1000))
                                DumpPackets(communicator, dumpFileName,packets);
                        }
                        else if (sfd.FilterIndex == 2)
                        {
                            SavePacketsToTextFile(dumpFileName, packets, packetBytes, maxFilePackets, sensorIP);
                        }
                    }

                    break;
                default:
                    DialogResult res = MessageBox.Show("No File Path Found...Try Again?", "Error!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        SavePackets(packets, packetBytes, maxFilePackets, sensorIP);
                    break;
            }
        }

        public static void SavePacketsFromConnection(string[] file, string[] selectedConnection, bool incomingConnection, List<Packet> filteredRawPackets, List<CougarPacket> filteredCougarPackets, string sensorIP)
        {
            int indexF = 0;

            if (filteredRawPackets.Count > 0)
            {
                //open file stream for mother file and raw mother file
                FileStream fs = File.OpenWrite(file[0] + "_" + (indexF + 1).ToString() + '.' + file[1]);
                StreamWriter fsRaw = new StreamWriter(file[0] + "_" + (indexF + 1).ToString() + "_raw" + '.' + file[1]);

                selectedConnection[0] = selectedConnection[0].Trim();
                selectedConnection[1] = selectedConnection[1].Trim();

                fsRaw.WriteLine(sensorIP);

                if (incomingConnection)
                {
                    int i = 0;
                    byte[] barr;
                    foreach (CougarPacket cp in filteredCougarPackets)
                    {
                        //if (cp.SourceAddress.ToString().Equals(selectedConnection[0]) && cp.SrcPort == Int32.Parse(selectedConnection[1]))
                        {
                            barr = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                            fs.Write(barr, 0, barr.Length);
                            fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(filteredRawPackets[i].Buffer).Replace("-", ""), filteredRawPackets[i].Timestamp.ToString("hh:mm:ss.fff"), filteredRawPackets[i].DataLink, filteredRawPackets[i].OriginalLength));
                        }
                        ++i;
                    }
                }
                else
                {
                    int i = 0;
                    byte[] barr;
                    foreach (CougarPacket cp in filteredCougarPackets)
                    {
                        //if (cp.DestAddress.ToString().Equals(selectedConnection[0]) && cp.SrcPort == Int32.Parse(selectedConnection[1]))
                        {
                            barr = Encoding.ASCII.GetBytes(cp.ToString() + "\n");
                            fs.Write(barr, 0, barr.Length);
                            fsRaw.WriteLine(String.Format("{0},{1},{2},{3}", BitConverter.ToString(filteredRawPackets[i].Buffer).Replace("-", ""), filteredRawPackets[i].Timestamp.ToString("hh:mm:ss.fff"), filteredRawPackets[i].DataLink, filteredRawPackets[i].OriginalLength));
                        }
                        ++i;
                    }
                }
                fs.Close();
                fsRaw.Close();
            }
        }

        private static void DumpPackets(PacketCommunicator communicator, string dumpFileName, List<Packet> packets) // write pakets to dump file
        {
            using (PacketDumpFile pdf = communicator.OpenDump(dumpFileName))
                foreach (Packet p in packets)
                    pdf.Dump(p);
        }


        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
            }
            return HexAsBytes;
        }

        public void ResetList()
        {
            PacketsReadFromFile.Clear();
        }

        public string getPath()
        {
            return path;
        }

    }
}

