using System;

namespace ProxyFairy.Core.Model
{
    public class Contract : BaseEntity
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public bool ServiceDesk { get; set; }

        public long? MobAppId { get; set; }
        public MobApp MobApp { get; set; }

        public long? SlotId { get; set; }
        public virtual Slot Slot { get; set; }
    }
}
