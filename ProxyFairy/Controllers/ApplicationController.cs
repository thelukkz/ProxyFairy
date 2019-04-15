using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.ViewModels.MobApp;

namespace ProxyFairy.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ViewResult CreateMobApp() => View(new CreateMobAppViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMobApp(CreateMobAppViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newApp = new MobApp
                {
                    AppBundle = model.AppBundle,
                    Name = model.Name,
                    Platform = model.Platform
                };
                if (model.CustomerId > 0) newApp.CustomerId = model.CustomerId;

                _mobAppsManager.Create(newApp);
                await _mobAppsManager.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
