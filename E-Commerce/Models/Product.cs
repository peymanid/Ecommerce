using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? MinDescription { get; set; }
        public string? MaxDescription { get; set; }
        public decimal Price { get; set; }
    }
}
