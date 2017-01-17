using System;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using TestCaseJob.Models.Account;

namespace TestCaseJob.App_Start
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
        }
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}