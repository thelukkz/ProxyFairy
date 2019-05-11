using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Service.Dtos.MobApp;

namespace ProxyFairy.Core.Service.Abstract
{
    public interface IMobAppsManager : IActionManager
    {
        Task<List<OutMobAppDto>> GetAllMobAppsAsync();
    }
}
