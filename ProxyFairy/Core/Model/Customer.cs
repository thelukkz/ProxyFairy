using System;

namespace ProxyFairy.Core.Model
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public Guid ProductOwnerId { get; set; }
        public virtual AppUser ProductOwner { get; set; }
    }
}
