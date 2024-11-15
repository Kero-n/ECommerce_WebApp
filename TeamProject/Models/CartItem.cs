namespace TeamProject.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; // Initialize to an empty string
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Constructor to initialize non-nullable fields
        public CartItem()
        {
            ProductName = string.Empty; // Ensure the property is initialized
        }
    }
}
