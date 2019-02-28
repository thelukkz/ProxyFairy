﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
