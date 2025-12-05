using SwineSyncc.Navigation.Inventory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwineSyncc.Data
{
    internal class InventoryRepository
    {
        public Item GetInventoryById(int inventoryId)
        {
            using (SqlConnection conn = DBConnection.Instance.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT 
                    ProductID,
                    ProductType,
                    Quantity,
                    RecordDate,
                    ExpirationDate,
                    Description
                FROM Inventory
                WHERE ProductID = @id;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", inventoryId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Item
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductType = reader["ProductType"] == DBNull.Value ? null : reader["ProductType"].ToString(),
                                Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Quantity"]),
                                RecordDate = reader["RecordDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["RecordDate"]),
                                ExpirationDate = reader["ExpirationDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["ExpirationDate"]),
                                Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
        

    }
    public class Item
    {
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
