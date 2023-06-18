using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string? Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
       
    }
}
