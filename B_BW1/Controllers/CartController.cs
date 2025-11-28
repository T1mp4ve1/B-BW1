using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_BW1.Controllers
{
    public class CartController : Controller
    {
        private readonly CartServices _cart;

        public CartController(CartServices cart)
        {
            _cart = cart;
        }

        [HttpPost]
        public IActionResult Add(int id, int qty)
        {
            var product = ProductsServices.GetProductById(id);
            _cart.AddToCart(product, qty);
            return RedirectToAction("Index", "Details", new { id = id });
        }

        public IActionResult Index()
        {
            var items = _cart.GetAll();
            return View(items);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _cart.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
