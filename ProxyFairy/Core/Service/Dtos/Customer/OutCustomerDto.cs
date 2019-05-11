namespace ProxyFairy.Core.Service.Dtos.Customer
{
    public class OutCustomerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ProductOwnerDto ProductOwner { get; set; }
        public long DroidAppsCount { get; set; }
        public long IosAppsCount { get; set; }
        public int ActiveSlotsCount { get; set; }

        public OutCustomerDto()
        {
            ProductOwner = new ProductOwnerDto();
        }
    }
}
