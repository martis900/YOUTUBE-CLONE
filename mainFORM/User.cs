using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTUBE
{
        public enum Status
        {
            user, artist
        }
        public class userData
        {
            public ulong user_ID { get; set; }
            public string user_username { get; set; }
            public string user_password { get; set; }
            public string user_email { get; set; }
            public string user_colour { get; set; }
            public string user_subscribers { get; set; }
    }
}
