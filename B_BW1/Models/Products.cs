namespace B_BW1.Models
{
    public class Products
    {
        public int idProduct { get; set; }
        public string? displayName { get; set; }
        public string? descriptionPro { get; set; }
        public decimal price { get; set; }
        public string? imageURL { get; set; }
        public int inStock { get; set; }

        public List<SecondaryImages> SecondaryImages { get; set; } = new();
    }
}