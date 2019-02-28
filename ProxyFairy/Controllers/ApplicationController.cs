using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.ViewModels.MobApp;

namespace ProxyFairy.Controllers
{
    public class ApplicationController : Controller
    {
        private IMobAppsManager _mobAppsManager;

        public ApplicationController(IMobAppsManager mobAppsManager)
        {
            _mobAppsManager = mobAppsManager;
        }

        public async Task<ViewResult> Index()
        {
            var mobAppsDto = await _mobAppsManager.GetAllMobAppsAsync();
            var model = mobAppsDto.Select(x => new MobAppViewModel
            {
                Id = x.Id,
                Name = x.Name,
                AppBundle = x.AppBundle,
                Platform = x.Platform,
                CustomerId = x.Customer?.Id,
                CustomerName = x.Customer?.Name,
                ProductOwnerId = x.ProductOwner?.Id,
                ProductOwnerName = x.ProductOwner?.FullName
            }).ToList();

            return View(model);
        }
    }
}
