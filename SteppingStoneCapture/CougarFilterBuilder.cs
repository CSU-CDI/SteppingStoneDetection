using System.Collections.Generic;

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
            AddToFilterLists(stringToAdd, true);
        }

        //Adds item to attribute list
        /// <summary>
        /// Adds item to attribute list
        /// </summary>
        /// <remarks>
        /// Helper function to AddToFilterLists with forced false isProtocol
        /// </remarks>
        /// <param name="stringToAdd">
        /// An IP address or Port No. with their respective attribute tags applied: ie 'src host someIPAddress'
        /// </param>
        public void AddToAttributeList(string stringToAdd)
        {
            AddToFilterLists(stringToAdd, false);
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
            string rtrn = "";
            //for each attribute, determine how to apply to filter
            for (int attrIndx = 0; attrIndx < attributes.Count; ++attrIndx)
            {
                if (attrIndx > 0)
                    rtrn += " and " + attributes[attrIndx];
                else
                    rtrn += attributes[attrIndx];
            }
            return rtrn;

        }

        private void AddToFilterLists(string stringToAdd, bool isProtocol)
        {
            if (isProtocol)
                protocols.Add(stringToAdd);
            else
                attributes.Add(stringToAdd);
        }

        private bool HasNonEmptyProtocolList => (protocols.Count > 0);
        private bool HasNonEmptyAttributesList => (attributes.Count > 0);
        private void ClearProtocolList() => protocols.Clear();
        private void ClearAttributesList() => attributes.Clear();
    }
}
