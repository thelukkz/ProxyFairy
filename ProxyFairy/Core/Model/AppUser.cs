using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace ProxyFairy.Core.Model
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
