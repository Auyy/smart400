﻿using System;
using System.Collections.Generic;

namespace Smart400.Models
{
    public class AppSettingModel
    {
        public string LogsAs400Path { get; set; }
        public string FileNameLogsAs400 { get; set; }
        public string MessageCheckStatus { get; set; }
        public int CounterChecking { get; set; }
        public int TimerMinuteCheck { get; set; }
        public int HourCheck { get; set; }
        public DateTime LastUpdate { get; set; }

        public IEnumerable<string> TextSmart { get; set; }
<<<<<<< HEAD
        public IEnumerable<string> Checktext {get; set;}
=======
>>>>>>> e35158a0cb4f8dd1cec600aabcdd10b8e15ac1d7

        //public string appSettingFullpath { get; set; }
        //public string appSetting { get; set; }
    }
}

//"LineToken":"xPWKd21JRmQ7rt81c19HDKioHVDohcFgqp99WakiSaF",
