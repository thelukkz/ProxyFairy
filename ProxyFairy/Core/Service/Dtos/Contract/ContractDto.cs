namespace ProxyFairy.Core.Service.Dtos.Contract
{
    public class ContractDto
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public bool ServiceDesk { get; set; }
        public long MobAppId { get; set; }
        public long SlotId { get; set; }
    }
}