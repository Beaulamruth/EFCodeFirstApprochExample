using EFCodeFirstApprochExample.Identity;
using EFCodeFirstApprochExample.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [ActionName("Register")]
        public ActionResult RegisterationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new ApplicationDBContext();
                var userStore = new ApplicationUserStore(dbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser()
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    PasswordHash = passwordHash,
                    PhoneNumber = rvm.Mobile,
                    Birthday = rvm.DateOfBirth,
                    Address = rvm.Address,
                    City = rvm.City,
                    Country = rvm.Country
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    //Add user to Role
                    userManager.AddToRole(user.Id, "Customer");

                    //Login
                    //var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    //var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    this.LoginUser(userManager, user);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [OverrideExceptionFilters]//Don't execute Exception Filter on login action method
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new ApplicationDBContext();
                var userStore = new ApplicationUserStore(dbContext);
                var userManager = new ApplicationUserManager(userStore);

                var user = userManager.Find(lvm.UserName, lvm.Password);
                if (user != null)
                {
                    //var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    //var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    //authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    this.LoginUser(userManager, user);
                }
                if (userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                else {
                    return RedirectToAction("Index", "Home"); 
                }

            }
            else
            {
                ModelState.AddModelError("myerror", "Invalid User Name and Password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            var dbContext = new ApplicationDBContext();
            var applicationUser = new ApplicationUser();
            var userStore = new ApplicationUserStore(dbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }

        [NonAction]
        public void LoginUser(ApplicationUserManager userManager, ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
    }
}
