using System.Collections.Generic;
using System;
namespace SteppingStoneCapture
{
    //Applies entered attributes to each selected protocol to build a filter string
    /// <summary>
    /// Builder of desired capture field string
    /// </summary>
    class CougarFilterBuilder
    {
        private List<string> protocols = new List<string>();
        private List<string> attributes = new List<string>();
        private string ipConjunction;
        private string portConjunction;
        private List<string> ipList = new List<string>();
        private List<string> portList = new List<string>();


        public CougarFilterBuilder(string ipConjunction, string portConjunction)
        {
            IpConjunction = ipConjunction;
            PortConjunction = portConjunction;
        }

        //Adds item to protocol list
        /// <summary>
        /// Adds item to protocol list
        /// </summary>
        /// <remarks>
        /// Helper function to AddToFilterLists with forced true isProtocol
        /// </remarks>
        /// <param name="stringToAdd">
        /// A string depicting a protocol: eg 'tcp', 'udp', or 'arp'
        /// </param>
        public void AddToProtocolList(string stringToAdd)
        {
            protocols.Add(stringToAdd);
        }


        public void AddIP(string ip)
        {
            ipList.Add(ip);

        }
        public void AddPort(string port)
        {
            portList.Add(port);
        }

        /// <summary>
        /// Clears the property lists for following runs
        /// </summary>
        public void ClearFilterLists()
        {
            ClearAttributesList();
            ClearProtocolList();
        }

        /// <summary>
        /// Represents the capture filter built from selected protocols and attributes
        /// </summary>
        /// <remarks>
        /// The default value of an empty string is fine.
        /// This will be interpreted as 'ip' by the capture filter.
        /// </remarks>
        public string FilterString
        {
            get
            {
                string captureString = "";
                Console.WriteLine("ips: "+ipList.Count);
                Console.WriteLine("ports: " + portList.Count);

                //Use the correct construction style based on selected properties
                if (HasNonEmptyAttributesList && HasNonEmptyProtocolList)
                {
                    captureString = BuildProtocolFilterPortion() + " and " + BuildAttributeFilterPortion();
                }
                else if (HasNonEmptyProtocolList)
                {
                    captureString = BuildProtocolFilterPortion();
                }
                else if (HasNonEmptyAttributesList)
                {
                    captureString = BuildAttributeFilterPortion();
                }

                return captureString.Trim().ToLower();
            }
        }

        //Builds the Protocol portion of the filter
        /// <summary>
        /// Formats selected protocols for the filter
        /// </summary>
        /// <example>(tcp or icmp or 'dns')</example>
        /// <returns>
        /// String depicting the Protocol Portion of the capture filter
        /// </returns>
        private string BuildProtocolFilterPortion()
        {
            //create a return string
            string rtrn = "(";

            //temp string for construction
            string current = "";

            //for each item, determine the correct construction
            for (int protoIndx = 0; protoIndx < protocols.Count; ++protoIndx)
            {
                //seperate and format specialized protocols
                if (protocols[protoIndx].ToLower() != "dns")
                    current = protocols[protoIndx];
                else if (protocols[protoIndx].ToLower() == "dns")
                    current = "(tcp or udp) and port 53";

                //append the protocol to the return statement
                if (protoIndx < protocols.Count - 1)
                    rtrn += current + " or ";
                else
                    rtrn += current + ")";
            }

            return rtrn;
        }


        //Builds the Attributes portion of the filter
        /// <summary>
        /// Formats selected attributes for the filter
        /// </summary>
        /// <example>'src host x and dst host y and dst port z'</example>
        /// <returns>
        /// String depicting the Protocol Portion of the capture filter
        /// </returns>
        private string BuildAttributeFilterPortion()
        {
            string rtrn = "(";
            //for each attribute, determine how to apply to filter
            for (int attrIndx = 0; attrIndx < ipList.Count; ++attrIndx)
            {
                Console.WriteLine(ipList[attrIndx]);
                if (attrIndx != 0)
                    rtrn += " " + IpConjunction + " " + ipList[attrIndx];
                else
                {
                    rtrn += ipList[attrIndx];
                }
            }

            if (portList.Count != 0)
            {
                if (rtrn.Length > 1) rtrn += ") and (";

                for (int attrIndx = 0; attrIndx < portList.Count; ++attrIndx)
                {
                    Console.WriteLine(portList[attrIndx]);
                    if (attrIndx != 0)
                        rtrn += " " + PortConjunction + " " + portList[attrIndx];
                    else
                    {
                        rtrn += portList[attrIndx];
                    }
                }
            }
            Console.WriteLine("Filter: "+rtrn);
            if (rtrn.Length == 1) rtrn = "ip";
            else rtrn += ")";
            return rtrn;

        }

        private bool HasNonEmptyProtocolList => (protocols.Count > 0);
        private bool HasNonEmptyAttributesList => (ipList.Count > 0 || portList.Count > 0);

        public string PortConjunction { get => portConjunction; set => portConjunction = value; }
        public string IpConjunction { get => ipConjunction; set => ipConjunction = value; }

        private void ClearProtocolList() => protocols.Clear();
        private void ClearAttributesList()
        {
                portList.Clear();
            ipList.Clear();
        }
    }
}
