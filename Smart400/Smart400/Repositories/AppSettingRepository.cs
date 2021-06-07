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
        private string fileContents = File.ReadAllText(@"/Users/tangkwa/Desktop/AS400Status/Smart400/Logs/Logs_AS400_Backend_20210606.txt");

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
            return texts.Reverse().Select(index => new AppSettingModel
            {
                LogsAs400Path = File.ReadAllText(texts)

            }).ToList();
           
        }

        //public IEnumerable<AppSettingModel> GetAll()
        //{
        //    var models = new List<AppSettingModel>();
        //    using (TextReader db = new StreamReader(fileContents))
        //    {
        //        var text = db.ReadLine();
        //        var linesReverse = text.Reverse().ToList();
        //    }

        //    return linesReverse;
        //}


       

    }
}
