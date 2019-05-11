using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Enums;

namespace ProxyFairy.ViewModels.MobApp
{
    public class CreateMobAppViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string AppBundle { get; set; }

        public long CustomerId { get; set; }

        [Required]
        public Platform Platform { get; set; }
    }
}
