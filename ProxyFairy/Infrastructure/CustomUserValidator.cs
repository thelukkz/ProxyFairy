using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProxyFairy.Core.Model;

namespace ProxyFairy.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        private readonly string _domain;

        public CustomUserValidator(IConfiguration configuration)
        {
            _domain = configuration["Data:ProxyFairyIdentity:DomainRestriction"];
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ?
                new List<IdentityError>() : result.Errors.ToList();

            if (!user.Email.ToLower().EndsWith(_domain))
            {
                errors.Add(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = $"Only {_domain} domain is allowed."
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
