using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopTest.Models;

namespace WorkshopTest.Configurations
{
    public interface IConfigurationContext
    {
        SiteLocaleModel GetSiteLocale();

        int GetCachingDays();
    }
}
