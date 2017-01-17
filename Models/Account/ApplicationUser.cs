using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCaseJob.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public string UserLastName { get; set; }

        public string FirstName { get; set; }

    }
}