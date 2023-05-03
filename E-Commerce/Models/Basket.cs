using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int quantity { get; set; }

    }
}
