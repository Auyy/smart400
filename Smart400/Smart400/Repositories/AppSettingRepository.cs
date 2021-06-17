using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Smart400.Models;

namespace Smart400.Repositories
{
    public class AppSettingRepository
    {
        //private string fileContents = File.ReadAllText(@"/Users/tangkwa/Desktop/AS400Status/Smart400/Logs/Logs_AS400_Backend_20210606.txt");

        public AppSettingRepository()
        {

        }



        public AppSettingModel Get()
        {
            var appSettingFullpath = "fileAppSetting.txt";
            var appSetting = ReadFileAppSetting(appSettingFullpath);
            //var curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            var dateToday = DateTime.Now.ToString("yyyyMMdd");
            var pathFileLog400 = appSetting.LogsAs400Path;
            var filenameLogToday = $"{appSetting.FileNameLogsAs400}{dateToday}.txt";
            var logFile = Path.Combine(pathFileLog400, filenameLogToday);

            var data = ReadFileContent(logFile);
            var check = HealthCheckService400(appSetting, logFile);
            //var check = "Service AS400 ปกติ";

            return new AppSettingModel
            {
                TextSmart = data,
                Checktext = check
            };
        }


        private AppSettingModel ReadFileAppSetting(string filepath)
        {
            //read json appsetting
            if (!File.Exists(filepath))
            {
                return null;
            }
            else
            {
                var texts = File.ReadAllText(filepath);

                var model = JsonSerializer.Deserialize<AppSettingModel>(texts);
                return model;
            }
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


        private IEnumerable<string> HealthCheckService400(AppSettingModel appSetting, string logFile)
        {
            var textcheck = new List<string>();
            var RES_SERVER_RUN = "Service AS400 ปกติ";
            var RES_SERVER_DOWN = "Smart 400 หยุดทำงาน!!";


            if (File.Exists(logFile))
            {
                var lines = File.ReadAllLines(logFile);
                var linesReverse = lines.Reverse().ToList();
                var lastMsg = linesReverse.FirstOrDefault(m => m.Contains(appSetting.MessageCheckStatus));

                if (!string.IsNullOrEmpty(lastMsg))
                {
                    var logLines = lastMsg.Split(" : ").ToList();
                    var logDateStr = logLines.FirstOrDefault();
                    var logDateTime = DateTime.Parse(logDateStr);

                    //chaeck alert
                    var CurDateTime_healthCheck = DateTime.Now;
                    var diffTime = CurDateTime_healthCheck - logDateTime;

                    // check in https://localhost:5001/swagger/index.html
                    if (diffTime.Days == 0 && diffTime.Hours == 0 && diffTime.Minutes <= appSetting.TimerMinuteCheck)
                    {
                        if (CurDateTime_healthCheck.Hour % appSetting.HourCheck == 0 && CurDateTime_healthCheck.Minute <= 5)
                        {
                            textcheck.Add(RES_SERVER_RUN);
                            return textcheck;
                        }
                        else
                        {
                            textcheck.Add(RES_SERVER_DOWN);
                            return textcheck;
                        }
                    }
                    else
                    {
                        textcheck.Add(RES_SERVER_DOWN);
                        return textcheck;
                    }
                }
                else
                {
                    textcheck.Add(RES_SERVER_DOWN);
                    return textcheck;
                }
            }
            else
            {
                textcheck.Add(RES_SERVER_DOWN);
                return textcheck;
            }

        }


    }
}
