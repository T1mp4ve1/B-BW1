using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_BW1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsServices.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            var products = ProductsServices.GetAllProducts();

            return Content($"Prodotti trovati nel DB: {products.Count}");
        }
    }
}
