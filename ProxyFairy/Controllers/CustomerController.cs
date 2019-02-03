using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyFairy.Core.Service.Abstract;

namespace ProxyFairy.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager _manager;

        public CustomerController(ICustomerManager manager)
        {
            _manager = manager;
        }

        public ViewResult Index()
        {
            var all = _manager.GetAll();
            _manager.Create(new Core.Model.Customer { Name = "testowy" });
            _manager.SaveChanges();
            all = _manager.GetAll();

            return View();
        }
    }
}
