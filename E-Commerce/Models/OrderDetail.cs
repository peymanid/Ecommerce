using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public Order? Order { get; set; }
    }
}
