﻿using EFCodeFirstApprochExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionFilter());
            //For Handle Error
            //filters.Add(new HandleErrorAttribute() { ExceptionType=typeof(Exception),View="Error"});
        }
    }
}