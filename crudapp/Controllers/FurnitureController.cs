using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using crudapp.Models;

namespace crudapp.Controllers
{

    public class FurnitureController
    {
        private string connectionString = "User ID=sa;password=examlyMssql@123;server=fcebdccccdbcfacbdcbaeadbebabcdebdca;Database=CRUDOperations;trusted_connection=false;Persist Security Info=False;Encrypt=False";

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
                        furniture.id = Convert.ToInt32(reader["id"]);
                        furniture.product = reader["product"].ToString();
                        furniture.description = reader["description"].ToString();
                        furniture.material = reader["material"].ToString();
                        furniture.cost = Convert.ToInt32(reader["cost"]);

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
