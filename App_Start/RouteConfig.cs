﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFCodeFirstApprochExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EFCodeFirstApprochExample.Controllers" }
            );
            routes.MapRoute(
               name: "Product",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "EFCodeFirstApprochExample.Controllers" }
           );
        }
    }
}
