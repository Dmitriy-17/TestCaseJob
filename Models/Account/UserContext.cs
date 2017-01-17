using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestCaseJob.Models.Account
{
    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext() : base("DBConnection") { }
        public static UserContext Create()
        {
            return new UserContext();
        }
    }
}