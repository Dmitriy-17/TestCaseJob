using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TestCaseJob.Models.Account;

namespace TestCaseJob.Initializers
{
    public class UserContextInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        protected override void Seed(UserContext db)
        {
            var adminRole = new ApplicationRole { Name = "admin", Description = "main role" };
            var userRole = new ApplicationRole { Name = "user", Description = "main role" };

            IdentityResult result = RoleManager.Create(adminRole);
            IdentityResult result2 = RoleManager.Create(userRole);

            var admin = new ApplicationUser
            {
                UserName = "admin1",
                Email = "admin.email@gmail.com",
                FirstName = "Admin",
                UserLastName = "AdminAdmin"
            };
            IdentityResult result3 = UserManager.Create(admin, "adminadmin1");
            UserManager.AddToRole(admin.Id, adminRole.Name);
        }
    }
}