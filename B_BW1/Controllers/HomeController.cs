using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_BW1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsServices _productService = new();
        private readonly SecondaryImagesServices _imagesService = new();
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

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            product.SecondaryImages = _imagesService.GetImagesByProduct(id);

            return View(product);
        }
    }
}
