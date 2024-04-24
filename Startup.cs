using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using EFCodeFirstApprochExample.Identity;

[assembly: OwinStartup(typeof(EFCodeFirstApprochExample.Startup))]

namespace EFCodeFirstApprochExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            }
            );
            CreateRolesandUsers();
        }

        public void CreateRolesandUsers()
        {
            var roleManager=new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDBContext();
            var appUserStore=new ApplicationUserStore(appDbContext);
            var appUserManager = new ApplicationUserManager(appUserStore);

            //Create Admin Role
            if (!roleManager.RoleExists("Admin")){
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Create Admin User
            if (appUserManager.FindByName("admin") == null)
            {
                var appUser=new ApplicationUser();
                appUser.UserName= "admin";
                appUser.Email= "admin@gmail.com";
                string userPassword = "admin123";
                var chkUser = appUserManager.Create(appUser, userPassword);
                if(chkUser.Succeeded)
                {
                    appUserManager.AddToRole(appUser.Id, "Admin");
                }
            }

            //Create Managet Role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //Create Manager User
            if (appUserManager.FindByName("manager")==null)
            {
                var user = new ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager.gmail.com";
                string userPassword = "manager123";
                var chkUser=appUserManager.Create(user, userPassword);
                if(chkUser.Succeeded)
                {
                    appUserManager.AddToRole(user.Id, "manager");
                }
            }

            //Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role=new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

        }
    }
}
