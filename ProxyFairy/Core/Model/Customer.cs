using System;
using System.Collections.Generic;

namespace ProxyFairy.Core.Model
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public virtual AppUser ProductOwner { get; set; }
        public virtual ICollection<MobApp> MobApps { get; set; }
    }
}
