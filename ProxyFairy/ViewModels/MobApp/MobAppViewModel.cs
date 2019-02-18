using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Enums;

namespace ProxyFairy.ViewModels.MobApp
{
    public class MobAppViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppBundle { get; set; }
        public Platform Platform { get; set; }
        public long? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductOwnerId { get; set; }
        public string ProductOwnerName { get; set; }
    }
}
