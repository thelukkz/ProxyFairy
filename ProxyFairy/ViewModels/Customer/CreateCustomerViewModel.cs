using System.ComponentModel.DataAnnotations;

namespace ProxyFairy.ViewModels.Customer
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        public string ProductOwnerId { get; set; }

    }
}
