using ProxyFairy.Core.Enums;

namespace ProxyFairy.Core.Service.Dtos.MobApp
{
    public class OutMobAppDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppBundle { get; set; }
        public Platform Platform { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductOwnerDto ProductOwner { get; set; }
    }
}
