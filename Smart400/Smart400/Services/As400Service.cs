using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Smart400.Models;
using Smart400.Repositories;

namespace Smart400.Services
{
    public interface IAs400Service
    {
        As400Response GetStatus();
    }

    public class As400Service : IAs400Service
    {
        private readonly IAs400Repository as400Repository;
        private IConfiguration configuration;

        public As400Service(IAs400Repository as400Repository,IConfiguration configuration)
        {
            this.as400Repository = as400Repository;
            this.configuration = configuration;

        }

        public As400Response GetStatus()
        {
            //var curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            var dateToday = DateTime.Now.ToString("yyyyMMdd");
            var pathFileLog400 = configuration.GetSection("ModelSetting:LogsAs400Path").Value;
            var fileNameLogs = configuration.GetSection("ModelSetting:FileNameLogsAs400").Value;
            var filenameLogToday = $"{fileNameLogs}{dateToday}.txt";
            var logFile = Path.Combine(pathFileLog400, filenameLogToday);


            var appsetting = as400Repository.Get();
            //return appsetting;


            var data = ReadFileContent(logFile);
            var check = HealthCheckService400(logFile);
            //var check = "Service AS400 ปกติ";

            return new As400Response
            {
                LastUpdate = DateTime.Now,
                TextSmart = data,
                Checktext = check
            };
        }

        private IEnumerable<string> ReadFileContent(string filepath)
        {
            var texts = new List<string>();
            //read json appsetting
            if (!File.Exists(filepath))
            {
                return null;
            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(filepath);
                foreach (string line in lines)
                {
                    texts.Add(line);
                }
                return texts;
            }
        }


        private string HealthCheckService400(string logFile)
        {
            var RES_SERVER_RUN = "Service AS400 ปกติ";
            var RES_SERVER_DOWN = "Smart 400 หยุดทำงาน!!";
            var RES_SERVER_DOWN2 = "Smart 400 หยุดทำงาน 2";
            var RES_SERVER_DOWN3 = "Smart 400 หยุดทำงาน 3";

            var messageCheckStatus = configuration.GetSection("ModelSetting:MessageCheckStatus").Value;
            var timerMinuteCheck = int.Parse(configuration.GetSection("ModelSetting:TimerMinuteCheck").Value);

            if (File.Exists(logFile))
            {
                var lines = File.ReadAllLines(logFile);
                var linesReverse = lines.Reverse().ToList();
                var lastMsg = linesReverse.FirstOrDefault(m => m.Contains(messageCheckStatus));

                if (!string.IsNullOrEmpty(lastMsg))
                {
                    var logLines = lastMsg.Split(" : ").ToList();
                    var logDateStr = logLines.FirstOrDefault();
                    var logDateTime = DateTime.Parse(logDateStr);

                    //chaeck alert
                    var CurDateTime_healthCheck = DateTime.Now;
                    var diffTime = CurDateTime_healthCheck - logDateTime;

                    if (diffTime.Days == 0 && diffTime.Hours == 0 && diffTime.Minutes <= timerMinuteCheck)
                    {
                        return RES_SERVER_RUN;
                    }
                    else
                    {
                        return RES_SERVER_DOWN;
                    }
                }
                else
                {
                    return RES_SERVER_DOWN2;
                }
            }
            else
            {
                return RES_SERVER_DOWN3;
            }

        }


    }
}
