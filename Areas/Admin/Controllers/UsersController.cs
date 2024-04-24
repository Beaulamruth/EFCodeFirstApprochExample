using EFCodeFirstApprochExample.Identity;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApprochExample.Filters;

namespace EFCodeFirstApprochExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {

        // GET: Admin/Users
        public ActionResult Index()
        {
            ApplicationDBContext db = new ApplicationDBContext();
            List<ApplicationUser> users = db.Users.ToList();
            return View(users);
        }
    }
}