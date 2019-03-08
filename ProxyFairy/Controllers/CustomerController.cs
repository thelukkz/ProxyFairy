using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Service.Abstract;
using ProxyFairy.ViewModels.Customer;

namespace ProxyFairy.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager _manager;

        public CustomerController(ICustomerManager manager)
        {
            _manager = manager;
        }

        public async Task<ViewResult> Index()
        {
            var customersDto = await _manager.GetAllCustomersAsync();
            var model = customersDto.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                DroidAppsCount = x.DroidAppsCount,
                IosAppsCount = x.IosAppsCount,
                ActiveSlotsCount = x.ActiveSlotsCount,
                ProducOwner = new ViewModels.Account.ProductOwnerViewModel
                {
                    Id = x.ProductOwner.Id,
                    FullName = x.ProductOwner.FullName
                }
            }).ToList();

            return View(model);
        }

        public ViewResult CreateCustomer() => View(new CreateCustomerViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productOwner = await _manager.GetProductOwnerAsync(model.ProductOwnerId);

                _manager.Create(new Customer
                {
                    ProductOwner = productOwner,
                    Name = model.Name
                });
                await _manager.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditCustomer(long id)
        {
            var dto = await _manager.GetCustomerAsync(id);
            if (string.IsNullOrEmpty(dto.Name)) return RedirectToAction("Index");

            EditCustomerViewModel customerModel = new EditCustomerViewModel
            {
                Id = id,
                Name = dto.Name,
                ProductOwnerId = dto?.ProductOwner?.Id ?? string.Empty
            };

            //TODO: read choosen PO and push as selected to front

            return View(customerModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var customer = (Customer)_manager.GetAll().Where(x => x.Id == viewModel.Id).FirstOrDefault();

            if (customer != null)
            {
                customer.Name = viewModel.Name;
                if (!string.IsNullOrEmpty(viewModel.ProductOwnerId))
                {
                    var newProductOwner = await _manager.GetProductOwnerAsync(viewModel.ProductOwnerId);
                    if (newProductOwner != null) customer.ProductOwner = newProductOwner;
                }

                await _manager.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


    }
}
