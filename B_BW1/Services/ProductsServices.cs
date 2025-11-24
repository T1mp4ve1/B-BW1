using B_BW1.Data;
using B_BW1.Models;
using Microsoft.Data.SqlClient;

namespace B_BW1.Services
{
    public class ProductsServices
    {
        public List<Products> GetAllProducts()
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

        public Products GetProductById(int id)
        {
            string query = "SELECT * FROM Products WHERE idProduct = @id";

            var dt = DbHelper.GetTable(query,
                new SqlParameter("@id", id));

            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];

            return new Products
            {
                idProduct = (int)row["idProduct"],
                displayName = row["displayName"].ToString(),
                descriptionPro = row["descriptionPro"].ToString(),
                price = (decimal)row["price"],
                imageURL = row["imageURL"].ToString(),
                inStock = (int)row["inStock"]
            };
        }
    }
}
