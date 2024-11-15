using Microsoft.AspNetCore.Mvc;
using TeamProject.Models;

namespace TeamProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            var order = new Order
            {
                CustomerName = "John Doe",
                ShippingAddress = "123 Main St",
                PaymentMethod = "Credit Card"
            };

            
            decimal totalAmount = order.TotalAmount;
            DateTime orderDate = order.OrderDate; 

          
            ViewData["TotalAmount"] = totalAmount;
            ViewData["OrderDate"] = orderDate;

            return View(order);
        }
    }
}
