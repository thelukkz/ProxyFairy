using System.Collections.Generic;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Service.Dtos.Customer;

namespace ProxyFairy.Core.Service.Abstract
{
    public interface ICustomerManager : IActionManager
    {
        Task<List<OutCustomerDto>> GetAllCustomersAsync();
        Task<AppUser> GetProductOwnerAsync(string userId);
    }
}
