using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Smart400.Models;

namespace Smart400.Repositories
{
    public interface IAs400Repository
    {
        As400Response Get();
    }

    public class As400Repository : IAs400Repository
    {
        //private string fileContents = File.ReadAllText(@"/Users/tangkwa/Desktop/AS400Status/Smart400/Logs/Logs_AS400_Backend_20210606.txt");

        private IConfiguration configuration;
        public As400Repository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public As400Response Get()
        {
           
            return new As400Response
            {
              
            };
        }

    }
}
