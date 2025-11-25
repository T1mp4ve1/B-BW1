using B_BW1.Data;
using B_BW1.Models;
using Microsoft.Data.SqlClient;

namespace B_BW1.Services
{
    public static class SecondaryImagesServices
    {
        public static List<SecondaryImages> GetImagesByProduct(int idProduct)
        {
            string query = "SELECT * FROM SecondaryImages WHERE idProduct = @idProduct";

            var dt = DbHelper.GetTable(query,
                new SqlParameter("@idProduct", idProduct));

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
