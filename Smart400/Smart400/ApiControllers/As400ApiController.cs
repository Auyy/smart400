using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart400.Models;
using Smart400.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smart400.ApiControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class As400ApiController : ControllerBase
    {
        private readonly IAs400Service as400Service;


        public As400ApiController(IAs400Service as400Service)
        {
            this.as400Service = as400Service;
        }

        [HttpGet("GetStatus")]
        public As400Response GetStatus()
        {
            return as400Service.GetStatus();
        }


    }

    }
