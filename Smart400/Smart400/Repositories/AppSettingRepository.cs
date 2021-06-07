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

        //public string fileContents()
        //{
        //    //var models = new AppSettingModel();
        //    var texts = File.ReadAllLines(@"/Users/tangkwa/Desktop/AS400Status/Smart400/Logs/Logs_AS400_Backend_20210606.txt");
        //    var linesReverse = texts.Reverse().ToList();

        //    return linesReverse;
        //}

        public IEnumerable<AppSettingModel> Get()
        {
            var texts = @"/Users/tangkwa/Desktop/AS400Status/Smart400/Logs/Logs_AS400_Backend_20210606.txt";
            //var linesReverse = texts.Reverse().ToList();
            return texts.Select(index => new AppSettingModel
            {
                TextSmart = File.ReadAllText(texts)
            });

        }

        //public IEnumerable<AppSettingModel> Get()
        //{

        //    var appSettingFullpath = "fileAppSetting.txt";
        //    var appSetting = ReadFileAppSetting(appSettingFullpath);
        //    //var curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        //    var dateToday = DateTime.Now.ToString("yyyyMMdd");
        //    var pathFileLog400 = appSetting.LogsAs400Path;
        //    var filenameLogToday = $"{appSetting.FileNameLogsAs400}{dateToday}.txt";
        //    var logFile = Path.Combine(pathFileLog400, filenameLogToday);

        //    appSetting.LastUpdate = DateTime.Now;
        //    var AppSettingJsonStr = JsonSerializer.Serialize(appSetting);
        //    File.WriteAllText(appSettingFullpath, AppSettingJsonStr);
        //    //var texts = "fileAppSetting.txt";
        //    //var linesReverse = texts.Reverse().ToList();
        //    return logFile.Select(index => new AppSettingModel
        //    {
        //        TextSmart = File.ReadAllText(logFile)
        //    });


        //}

        //private static AppSettingModel ReadFileAppSetting(string filepath)
        //{
        //    //read json appsetting
        //    if (!File.Exists(filepath))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var texts = File.ReadAllText(filepath);

        //        var model = JsonSerializer.Deserialize<AppSettingModel>(texts);
        //        return model;
        //    }
        //}



    }
}
