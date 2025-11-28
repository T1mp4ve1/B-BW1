using B_BW1.Models;
using Newtonsoft.Json;

namespace B_BW1.Services
{
    public class CartServices
    {
        private readonly IHttpContextAccessor _http;

        public CartServices(IHttpContextAccessor http)
        {
            _http = http;
        }

        private List<CartItem> GetCart()
        {
            string? json = _http.HttpContext.Session.GetString("CART");
            if (json == null) return new List<CartItem>();

            return JsonConvert.DeserializeObject<List<CartItem>>(json);
        }

        private void SaveCart(List<CartItem> cart)
        {
            string json = JsonConvert.SerializeObject(cart);
            _http.HttpContext.Session.SetString("CART", json);
        }

        public void AddToCart(Products p, int qty)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(c => c.ProductId == p.idProduct);

            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = p.idProduct,
                    DisplayName = p.displayName,
                    ImageURL = p.imageURL,
                    Price = p.price,
                    Quantity = qty
                });
            }
            else
            {
                item.Quantity += qty;
            }

            SaveCart(cart);
        }

        public void Remove(int productId)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
        }


        public List<CartItem> GetAll() => GetCart();
    }
}
