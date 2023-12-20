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
    try
    {
        Console.WriteLine(newFurniture.cost);
        if (ModelState.IsValid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO     `    (product, description, material, cost) " +
                               "VALUES (@Product, @Description, @Material, @Cost)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Product", newFurniture.product);
                command.Parameters.AddWithValue("@Description", newFurniture.description);
                command.Parameters.AddWithValue("@Material", newFurniture.material);
                command.Parameters.AddWithValue("@Cost", newFurniture.cost);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index", GetFurnitureListFromDatabase());
                }
            }
        }
        else
        {
            // Log ModelState errors
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // Log the exception or handle it appropriately
    }

    return View(newFurniture);
}

        public IActionResult Index()
        {
            List<Furniture> furnitureList = GetFurnitureListFromDatabase();
            return View(furnitureList);
        }

        private List<Furniture> GetFurnitureListFromDatabase()
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

            return furnitureList;
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

        [HttpGet]
    public IActionResult Update(int id)
    {
        // Fetch furniture item based on ID from the database
        Furniture furnitureToUpdate = GetFurnitureById(id);

        if (furnitureToUpdate == null)
        {
            // Handle case where furniture item is not found
            return NotFound();
        }

        return View(furnitureToUpdate); // Pass the fetched item to the Update view
    }

    [HttpPost]
    public IActionResult Update(Furniture updatedFurniture)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Furniture SET product = @Product, description = @Description, " +
                           "material = @Material, cost = @Cost WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Product", updatedFurniture.product);
            command.Parameters.AddWithValue("@Description", updatedFurniture.description);
            command.Parameters.AddWithValue("@Material", updatedFurniture.material);
            command.Parameters.AddWithValue("@Cost", updatedFurniture.cost);
            command.Parameters.AddWithValue("@Id", updatedFurniture.id);

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
                // Handle the exception if needed
            }
        }

        return View("Update", updatedFurniture); // Return to the update view if the update fails
    }

    // Helper method to get a furniture item by ID
    private Furniture GetFurnitureById(int id)
{
    Furniture furniture = null;

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "SELECT id, product, description, material, cost FROM Furniture WHERE id = @Id";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                furniture = new Furniture
                {
                    id = Convert.ToInt32(reader["id"]),
                    product = reader["product"].ToString(),
                    description = reader["description"].ToString(),
                    material = reader["material"].ToString(),
                    cost = Convert.ToInt32(reader["cost"])
                };
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    return furniture;
}


    }
}



