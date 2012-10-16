using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Responses
{
    public class ConnectionCreatedResponse : Response
    {
        public string stbId { get; set;}
        public string orderNumber { get; set; }
        public string description { get; set; }
        public List<string> channels { get; set; }
        public string reseller { get; set; }
        public string menudata { get; set; }
        public string features { get; set; }
        public List<string> blockedChannels { get; set; }

        public ConnectionCreatedResponse()
        {
            channels = new List<string>();
            blockedChannels = new List<string>();
        }
    }
}
