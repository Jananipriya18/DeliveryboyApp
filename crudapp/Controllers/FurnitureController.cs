using Microsoft.AspNetCore.Mvc;
using crudapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace crudapp.Controllers
{
    public class FurnitureController : Controller
    {
        private string connectionString = "User ID=sa;password=examlyMssql@123;server=fcebdccccdbcfacbdcbaeadbebabcdebdca-0;Database=CRUDOperations;trusted_connection=false;Persist Security Info=False;Encrypt=False";

        public IActionResult Index()
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
                    Console.WriteLine(ex.Message);
                }
            }

            return View(furnitureList); 
        }
    }
}
