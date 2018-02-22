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

        public void ClearFilterLists()
        {
            ClearAttributesList();
            ClearProtocolList();
        }

        //
        public string GetFilterString()
        {
            string captureString = "";

            if (NonEmptyAttributesList() && NonEmptyProtocolList())
            {
                captureString = BuildProtocolPortionFilter() +" and "+ BuildAttributePortionFilter();
            }
            else if (NonEmptyProtocolList())
            {
                captureString = BuildProtocolPortionFilter();
            }
            else if (NonEmptyAttributesList())
            {
                captureString = BuildAttributePortionFilter();
            }

            return captureString.Trim().ToLower();
        }

        private string BuildProtocolPortionFilter()
        {
            string rtrn = "(";

            string current = "";
            for (int protoIndx = 0; protoIndx < protocols.Count; ++protoIndx)
            {
                if (protocols[protoIndx].ToLower() != "dns")
                    current = protocols[protoIndx];
                else if (protocols[protoIndx].ToLower() == "dns")
                    current = "((tcp or udp) and port 53)";

                if (protoIndx < protocols.Count - 1)
                    rtrn += current + " or ";
                else
                    rtrn += current + ")";
            }
            
            return rtrn;
        }

        private string BuildAttributePortionFilter()
        {
            string rtrn = "";
            for (int attrIndx = 0; attrIndx < attributes.Count; ++attrIndx)
            {
                if (attrIndx > 0)
                    rtrn += " and " + attributes[attrIndx];
                else
                    rtrn += attributes[attrIndx];
            }
            return rtrn;

        }

        private void ClearProtocolList()
        {
            protocols.Clear();
        }

        private void ClearAttributesList()
        {
            attributes.Clear();
        }

        private string CombineEqualIndexedItems()
        {
            return "";
        }

        private void AddToFilterLists(string stringToAdd, bool isProtocol)
        {
            if (isProtocol)
                protocols.Add(stringToAdd);
            else
                attributes.Add(stringToAdd);
        }

        private bool NonEmptyProtocolList()
        {
            return (protocols.Count > 0);
        }

        private bool NonEmptyAttributesList()
        {
            return (attributes.Count > 0);
        }
    }
}
