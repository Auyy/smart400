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
    public class AppSettingApiController : ControllerBase
    {
        private AppSettingService appSettingService;


        public AppSettingApiController()
        {
            appSettingService = new AppSettingService();
        }



        //[HttpGet()]
        //public List<AppSettingModel> GetAppSetting()
        //{
        //    return appSettingService.GetAppSetting();
        //}

        [HttpGet()]
        public AppSettingModel Get()
        {
            return appSettingService.Get();
        }


    }

    }
