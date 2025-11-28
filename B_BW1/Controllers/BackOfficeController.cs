using B_BW1.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_BW1.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var prodotti = ProductsServices.GetAllProducts();
            return View(prodotti);
        }

        // POST
        [HttpPost]
        public IActionResult Insert(string displayName, string descriptionPro, string imageURL,
                                    string secondaryImages, decimal price, int inStock)
        {
            // 1) Inserimento Prodotto → ritorna id generato
            int newId = ProductsServices.InsertProduct(displayName, descriptionPro, price, imageURL, inStock);

            // 2) Inserimento immagini secondarie
            if (!string.IsNullOrEmpty(secondaryImages))
            {
                var images = secondaryImages.Split(',');
                ProductsServices.InsertSecondaryImages(newId, images);
            }

            return RedirectToAction("Index");
        }

        //DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProductsServices.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}