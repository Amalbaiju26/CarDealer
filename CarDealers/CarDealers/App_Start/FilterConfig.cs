﻿using System.Web;
using System.Web.Mvc;

namespace CarDealers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //force all request to use ssl
            
        }
    }
}
