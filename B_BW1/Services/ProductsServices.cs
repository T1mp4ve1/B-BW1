using B_BW1.Data;
using B_BW1.Models;
using Microsoft.Data.SqlClient;

namespace B_BW1.Services
{
    public static class ProductsServices
    {
        //TUTTI
        public static List<Products> GetAllProducts()
        {
            var dt = DbHelper.GetTable("SELECT * FROM Products");
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

        //INSERT
        public static int InsertProduct(string displayName, string descriptionPro,
                                decimal price, string imageURL, int inStock)
        {
            string query =
                "INSERT INTO Products (displayName, descriptionPro, price, imageURL, inStock) " +
                "OUTPUT INSERTED.idProduct " +
                "VALUES (@n, @d, @p, @i, @s)";

            using var conn = new SqlConnection(DbHelper.ConnectionString);
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@n", displayName);
            cmd.Parameters.AddWithValue("@d", descriptionPro);
            cmd.Parameters.AddWithValue("@p", price);
            cmd.Parameters.AddWithValue("@i", imageURL);
            cmd.Parameters.AddWithValue("@s", inStock);

            conn.Open();
            return (int)cmd.ExecuteScalar();
        }

        //INSERT SECONDARIE
        public static void InsertSecondaryImages(int idProduct, IEnumerable<string> urls)
        {
            using var conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            foreach (var url in urls)
            {
                string cleanUrl = url.Trim();
                if (string.IsNullOrWhiteSpace(cleanUrl)) continue;

                string query =
                    "INSERT INTO SecondaryImages (idProduct, imageURL) VALUES (@id, @url)";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idProduct);
                cmd.Parameters.AddWithValue("@url", cleanUrl);
                cmd.ExecuteNonQuery();
            }
        }

        //DELETE
        public static void DeleteProduct(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string deleteImages = "DELETE FROM SecondaryImages WHERE idProduct = @id";
                using (var cmdImg = new SqlCommand(deleteImages, conn))
                {
                    cmdImg.Parameters.AddWithValue("@id", id);
                    cmdImg.ExecuteNonQuery();
                }

                string deleteProduct = "DELETE FROM Products WHERE idProduct = @id";
                using (var cmdProd = new SqlCommand(deleteProduct, conn))
                {
                    cmdProd.Parameters.AddWithValue("@id", id);
                    cmdProd.ExecuteNonQuery();
                }
            }
        }
    }
}