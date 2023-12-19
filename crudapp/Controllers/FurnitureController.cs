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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
public IActionResult Create(Furniture newFurniture)
{
    // Assuming the connectionString is properly set

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "INSERT INTO Furniture (product, description, material, cost) " +
                       "VALUES (@Product, @Description, @Material, @Cost)";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Product", newFurniture.product);
        command.Parameters.AddWithValue("@Description", newFurniture.description);
        command.Parameters.AddWithValue("@Material", newFurniture.material);
        command.Parameters.AddWithValue("@Cost", newFurniture.cost);

        try
        {
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Redirect to the Index action after creating the furniture entry
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // Handle the exception if needed
            // For debugging purposes, you can throw the exception to see details
            throw;
        }
    }

    // If insertion fails or an exception occurs, return back to the Create page
    return View(newFurniture);
}


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
                    // Handle the exception if needed
                }
            }

            return View(furnitureList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Furniture WHERE id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw; // For debugging purposes, throw the exception to see details
                }
            }

            return RedirectToAction("Index");
        }
    }
}
