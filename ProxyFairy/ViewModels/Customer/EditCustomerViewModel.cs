using System.ComponentModel.DataAnnotations;

namespace ProxyFairy.ViewModels.Customer
{
    public class EditCustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        public string ProductOwnerId { get; set; }
    }
}
