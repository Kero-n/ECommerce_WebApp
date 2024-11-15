using Microsoft.AspNetCore.Mvc;
using TeamProject.Extensions;
using Service; 
using TeamProject.Models; 

namespace SmartMart.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);

        }

        public IActionResult Add(int productId, int quantity)
        {
            // Get the cart from the session or create a new one if it doesn't exist
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Find the product from the database based on the product ID
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                // Check if the item already exists in the cart
                var existingItem = cart.FirstOrDefault(p => p.ProductId == productId);

                if (existingItem != null)
                {
                    // If the item already exists, increase the quantity
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // If the item doesn't exist in the cart, add a new CartItem
                    cart.Add(new CartItem
                    {
                        ProductId = productId,
                        ProductName = product.Name,
                        Quantity = quantity,
                        Price = product.Price
                    });
                }

                // Save the updated cart back to the session
                HttpContext.Session.Set("Cart", cart);
            }

            // Redirect to the cart page to view the updated cart
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCartItem(int id, int quantity)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            var item = cart.Find(p => p.CartItemId == id);

            if (item != null)
            {
                item.Quantity = quantity;
                HttpContext.Session.Set("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartItem(int id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            var item = cart.Find(p => p.CartItemId == id);

            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set("Cart", cart);
            }

            return RedirectToAction("Index");
        }
    }
}
