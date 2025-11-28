namespace B_BW1.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string? DisplayName { get; set; }
        public string? ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
