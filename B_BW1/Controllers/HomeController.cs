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
    }
}
