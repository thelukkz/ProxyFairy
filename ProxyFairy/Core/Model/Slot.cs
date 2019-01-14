using System.Collections.Generic;

namespace ProxyFairy.Core.Model
{
    public class Slot : BaseEntity
    {
        public int SlotNumber { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
