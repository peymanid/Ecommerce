namespace E_Commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
    }
}
