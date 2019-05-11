using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Service.Abstract;

namespace ProxyFairy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SlotController : Controller
    {
        private ISlotManager _manager;
        public SlotController(ISlotManager manager)
        {
            _manager = manager;
        }

        public ViewResult Index()
        {
            return View(_manager.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSlot()
        {
            var slot = new Slot();
            _manager.Create(slot);
            await _manager.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}