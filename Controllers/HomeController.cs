using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApprochExample.Filters;

namespace EFCodeFirstApprochExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyActionFilter]
        [MyResultFilter]
        //[OutputCache(Duration =60)]//Stores Result in CacheMemory in certain amount time (60 seconds).
        public ActionResult Index()
        {
            //For Handle Error
            //throw new Exception("Some exception for testing purpose!");
            return View();
        }
    }
}