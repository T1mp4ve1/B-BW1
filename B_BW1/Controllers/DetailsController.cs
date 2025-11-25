using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;
namespace B_BW1.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index(int id)
        {
            var product = ProductsServices.GetProductById(id);
            product.SecondaryImages = ProductsServices.GetImagesByProduct(id);
            return View(product);
        }
    }
}
