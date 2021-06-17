using System;
using System.Collections.Generic;
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

        public As400Service(IAs400Repository as400Repository)
        {
            this.as400Repository = as400Repository;
        }

        public As400Response GetStatus()
        {
            var appsetting = as400Repository.Get();

            return appsetting;
        }

       
    }
}
