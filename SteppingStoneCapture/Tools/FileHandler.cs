using PcapDotNet.Core;
using PcapDotNet.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools
{
    class FileHandler
    {
        private List<Packet> packetsReadFromFile;
        private string sensorIP;

        public FileHandler()
        {
            PacketsReadFromFile = new List<Packet>();
            SensorIP = "";
        }
        public List<Packet> PacketsReadFromFile { get => packetsReadFromFile; set => packetsReadFromFile = value; }
        public string SensorIP { get => sensorIP; set => sensorIP = value; }

        public void LoadPacketsFromFiles()
        {
            var clf = new CustomLoadForm();
            clf.ShowDialog();

            string loadPath = clf.FileNameRequested;
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

    }
}

