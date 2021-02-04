using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopTest.Models;

namespace WorkshopTest.Configurations
{
    public class ConfigurationContext : IConfigurationContext
    {
        private readonly IConfiguration _config;

        public ConfigurationContext(IConfiguration config)
        {
            _config = config;
        }

        public int GetCachingDays()
        {
            return Convert.ToInt32(_config["CachingDays"]);

            throw new NotImplementedException();
        }

        public SiteLocaleModel GetSiteLocale()
        {
            var siteLocale = new SiteLocaleModel
            {
                EN = _config["SiteLocale:EN"].ToString(),
                TH = _config["SiteLocale:TH"].ToString(),
            };

            return siteLocale;

            throw new NotImplementedException();
        }
    }
}
