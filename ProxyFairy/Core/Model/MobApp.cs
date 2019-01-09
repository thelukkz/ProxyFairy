using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyFairy.Core.Model
{
    public class MobApp : BaseEntity
    {
        public string AppBundle { get; set; }
        public Platform Platform { get; set; }

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
