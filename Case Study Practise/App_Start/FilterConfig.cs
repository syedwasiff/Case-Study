﻿using System.Web;
using System.Web.Mvc;

namespace Case_Study_Practise
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
