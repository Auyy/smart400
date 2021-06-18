using System;
using System.Collections.Generic;

namespace Smart400.Models
{
    public class As400Response
    {
        public DateTime LastUpdate { get; set; }
        public IEnumerable<string> TextSmart { get; set; }
        public string Checktext {get; set;}
    }
}

//"LineToken":"xPWKd21JRmQ7rt81c19HDKioHVDohcFgqp99WakiSaF",
