using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string message = "Message: " + filterContext.Exception.Message + ", Type: " + filterContext.Exception.GetType().ToString() + ", Source: " + filterContext.Exception.Source;
            StreamWriter streamWriter=File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath+"\\ErrorLog.txt");
            streamWriter.Write(message);
            streamWriter.Close();
            filterContext.ExceptionHandled=true;
            filterContext.Result = new RedirectResult("~/Error.html");
        }
    }
}