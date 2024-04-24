using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;
using System.Web.Http;
using EFDbFirstApprochExample;

namespace EFCodeFirstApprochExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
        }

        protected void Application_Error()
        {
            Exception ex=Server.GetLastError();
            String msg = "Message: " + ex.Message + " Type: " + ex.GetType().ToString() + " Source: " + ex.Source;
            StreamWriter sw = File.AppendText(HttpContext.Current.Request.PhysicalApplicationPath + "\\ErrorLog.txt");
            sw.WriteLine(msg);
            sw.Close();
            Response.Redirect("Error.html");
        }
    }
}
