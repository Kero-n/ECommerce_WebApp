using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Read-only property to calculate the total amount dynamically.
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);

        // Add the OrderDate property to store the date the order was placed.
        public DateTime OrderDate { get; set; } = DateTime.Now; // Default to current date and time
    }
}
