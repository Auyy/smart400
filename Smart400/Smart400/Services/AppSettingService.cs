using System;
using System.Collections.Generic;
using System.Linq;
using Smart400.Models;
using Smart400.Repositories;

namespace Smart400.Services
{
    public class AppSettingService
    {
        private AppSettingRepository appSettingRepository;

        public AppSettingService()
        {
            appSettingRepository = new AppSettingRepository();
        }

        public AppSettingModel Get()
        {
            var appsetting = appSettingRepository.Get();
            var reverseTexts = appsetting.TextSmart.Reverse();

            appsetting.TextSmart = reverseTexts;

            return appsetting;
        }

       
    }
}
