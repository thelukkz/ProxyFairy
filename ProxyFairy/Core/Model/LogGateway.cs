using System.Collections;
using System.Collections.Generic;
using ProxyFairy.Core.Enums;

namespace ProxyFairy.Core.Model
{
    public class LogGateway : BaseEntity
    {
        public string Level { get; set; }
        public string DeviceId { get; set; }
        public string System { get; set; }
        public string SystemVersion { get; set; }
        public string BundleId { get; set; }
        public string AppVersion { get; set; }
        public long? ContractId { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public ResponseType? Response { get; set; }

        public long? MobAppId { get; set; }
        public virtual MobApp MobApp { get; set; }
    }
}
