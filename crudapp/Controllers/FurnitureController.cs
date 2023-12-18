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
User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=FurnitureDB;trusted_connection=false;Persist Security Info=False;Encrypt=False        // Existing code for Index, Create, Update, Delete actions

        // POST: Handle form submission for create operation
        [HttpPost]
        public IActionResult Create(Furniture furniture)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Furniture (product, description, material, cost) VALUES (@Product, @Description, @Material, @Cost)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Product", furniture.product);
                command.Parameters.AddWithValue("@Description", furniture.description);
                command.Parameters.AddWithValue("@Material", furniture.material);
                command.Parameters.AddWithValue("@Cost", furniture.cost);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle exception
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Display form to update furniture item
        public IActionResult Update(int id)
        {
            Furniture furniture = new Furniture();
            
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
                        furniture.id = Convert.ToInt32(reader["id"]);
                        furniture.product = reader["product"].ToString();
                        furniture.description = reader["description"].ToString();
                        furniture.material = reader["material"].ToString();
                        furniture.cost = Convert.ToInt32(reader["cost"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle exception
                }
            }

            return View(furniture);
        }

        // Existing code for UpdateConfirmed, Delete, DeleteConfirmed actions
        // POST: Handle form submission for update operation
[HttpPost]
public IActionResult UpdateConfirmed(Furniture furniture)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "UPDATE Furniture SET product = @Product, description = @Description, material = @Material, cost = @Cost WHERE id = @Id";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Product", furniture.product);
        command.Parameters.AddWithValue("@Description", furniture.description);
        command.Parameters.AddWithValue("@Material", furniture.material);
        command.Parameters.AddWithValue("@Cost", furniture.cost);
        command.Parameters.AddWithValue("@Id", furniture.id);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // Handle exception
        }
    }

    return RedirectToAction("Index");
}

// GET: Display delete confirmation
public IActionResult Delete(int id)
{
    Furniture furniture = new Furniture();

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
                furniture.id = Convert.ToInt32(reader["id"]);
                furniture.product = reader["product"].ToString();
                furniture.description = reader["description"].ToString();
                furniture.material = reader["material"].ToString();
                furniture.cost = Convert.ToInt32(reader["cost"]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // Handle exception
        }
    }

    return View(furniture);
}

// POST: Handle form submission for delete operation
[HttpPost]
public IActionResult DeleteConfirmed(int id)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "DELETE FROM Furniture WHERE id = @Id";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // Handle exception
        }
    }

    return RedirectToAction("Index");
    }
    }
}
