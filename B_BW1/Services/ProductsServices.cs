using B_BW1.Data;
using B_BW1.Models;

namespace B_BW1.Services
{
    public static class ProductsServices
    {
        //TUTTI
        public static List<Products> GetAllProducts(string query)
        {
            var dt = DbHelper.GetTable(query);
            List<Products> list = new();

            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new Products
                {
                    idProduct = (int)row["idProduct"],
                    displayName = (string)row["displayName"],
                    descriptionPro = (string)row["descriptionPro"],
                    price = (decimal)row["price"],
                    imageURL = (string)row["imageURL"],
                    inStock = (int)row["inStock"]
                });
            }
            return list;
        }

        //SOLO CON ID
        public static Products GetProductById(int id)
        {
            var dt = DbHelper.GetTable($"SELECT * FROM Products WHERE idProduct = {id}");
            var row = dt.Rows[0];
            return new Products
            {
                idProduct = (int)row["idProduct"],
                displayName = (string)row["displayName"],
                descriptionPro = (string)row["descriptionPro"],
                price = (decimal)row["price"],
                imageURL = (string)row["imageURL"],
                inStock = (int)row["inStock"]
            };
        }

        //IMMAGINI SECONDARI
        public static List<SecondaryImages> GetImagesByProduct(int id)
        {
            string query = $"SELECT * FROM SecondaryImages WHERE idProduct = {id}";

            var dt = DbHelper.GetTable(query);

            List<SecondaryImages> list = new();

            foreach (System.Data.DataRow row in dt.Rows)
            {
                list.Add(new SecondaryImages
                {
                    idSecondaryImages = (int)row["idSecondaryImages"],
                    idProduct = (int)row["idProduct"],
                    imageURL = (string)row["imageURL"]
                });
            }
            return list;
        }
    }
}