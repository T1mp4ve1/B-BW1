using B_BW1.Data;
using B_BW1.Models;

namespace B_BW1.Services
{
    public static class ProductsServices
    {
        public static List<Products> GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            var dt = DbHelper.GetTable(query);

            List<Products> list = new();

            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new Products
                {
                    idProduct = (int)row["idProduct"],
                    displayName = row["displayName"].ToString(),
                    descriptionPro = row["descriptionPro"].ToString(),
                    price = (decimal)row["price"],
                    imageURL = row["imageURL"].ToString(),
                    inStock = (int)row["inStock"]
                });
            }
            return list;
        }
    }
}