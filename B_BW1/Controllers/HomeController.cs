using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_BW1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsServices _productService = new();
        private readonly SecondaryImagesServices _imagesService = new();
        public HomeController(ProductsServices productService, SecondaryImagesServices imagesService)
        {
            _productService = productService;
            _imagesService = imagesService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            var products = _productService.GetAllProducts();

            return Content($"Prodotti trovati nel DB: {products.Count}");
        }
    }
}
