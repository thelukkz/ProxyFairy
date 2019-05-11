using ProxyFairy.ViewModels.Account;

namespace ProxyFairy.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public long DroidAppsCount { get; set; }
        public long IosAppsCount { get; set; }
        public int ActiveSlotsCount { get; set; }

        public ProductOwnerViewModel ProducOwner { get; set; }

        public CustomerViewModel()
        {
            ProducOwner = new ProductOwnerViewModel();
        }
    }
}
