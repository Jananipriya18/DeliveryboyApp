using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace YourNamespace.Controllers
{
    public class FurnitureController
    {
        private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=FurnitureDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

        public List<Furniture> GetAllFurniture()
        {
            List<Furniture> furnitureList = new List<Furniture>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, product, description, material, cost FROM Furniture";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Furniture furniture = new Furniture();
                        furniture.Id = Convert.ToInt32(reader["id"]);
                        furniture.Product = reader["product"].ToString();
                        furniture.Description = reader["description"].ToString();
                        furniture.Material = reader["material"].ToString();
                        furniture.Cost = Convert.ToDecimal(reader["cost"]);

                        furnitureList.Add(furniture);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine(ex.Message);
                }
            }

            return furnitureList;
        }
    }
}
