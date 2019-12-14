using System;
using System.Collections.Generic;
using System.Linq;
using BuddySystem.Data;
//using BuddySystem_WebAPI.Data;    //threw an error do not think it is needed
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BuddySystem_WebAPI.Startup))]

namespace BuddySystem_WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            SeedDefaultRolesAndUsers();
        }

        private void SeedDefaultRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists(RoleNames.Admin))
            {
                var adminRole = new IdentityRole(RoleNames.Admin);
                roleManager.Create(adminRole);

                var adminUser = new ApplicationUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                var adminPassword = "password";

                var userCreationResult = userManager.Create(adminUser, adminPassword);

                if (userCreationResult.Succeeded)
                    userManager.AddToRole(adminUser.Id, RoleNames.Admin);
            }

            if (!roleManager.RoleExists(RoleNames.User))
            {
                var userRole = new IdentityRole(RoleNames.User);
                roleManager.Create(userRole);
            }

        }
    }
}
