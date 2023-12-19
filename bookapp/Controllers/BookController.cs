using Microsoft.AspNetCore.Mvc;
using crudapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace crudapp.Controllers
{
    public class BookController : Controller
    {
        private string connectionString = "User ID=sa;password=examlyMssql@123;server=fcebdccccdbcfacbdcbaeadbebabcdebdca-0;Database=books;trusted_connection=false;Persist Security Info=False;Encrypt=False";

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books newBook)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Books (name, author, genre, language) " +
                                   "VALUES (@Name, @Author, @Genre, @Language)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", newBook.name);
                    command.Parameters.AddWithValue("@Author", newBook.author);
                    command.Parameters.AddWithValue("@Genre", newBook.genre);
                    command.Parameters.AddWithValue("@Language", newBook.language);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Handle the exception if needed
            }

            return View(newBook);
        }

        public IActionResult Index()
        {
            List<Books> bookList = GetBooksListFromDatabase();
            return View(bookList);
        }

        private List<Books> GetBooksListFromDatabase()
        {
            List<Books> bookList = new List<Books>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, name, author, genre, language FROM Books";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Books book = new Books();
                        book.id = Convert.ToInt32(reader["id"]);
                        book.name = reader["name"].ToString();
                        book.author = reader["author"].ToString();
                        book.genre = reader["genre"].ToString();
                        book.language = Convert.ToInt32(reader["language"]);

                        bookList.Add(book);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return bookList;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Books WHERE id = @Id";

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
            Books bookToUpdate = GetBookById(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            return View(bookToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Books updatedBook)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Books SET name = @Name, author = @Author, " +
                               "genre = @Genre, language = @Language WHERE id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", updatedBook.name);
                command.Parameters.AddWithValue("@Author", updatedBook.author);
                command.Parameters.AddWithValue("@Genre", updatedBook.genre);
                command.Parameters.AddWithValue("@Language", updatedBook.language);
                command.Parameters.AddWithValue("@Id", updatedBook.id);

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

            return View("Update", updatedBook); // Return to the update view if the update fails
        }

        private Books GetBookById(int id)
        {
            Books book = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, name, author, genre, language FROM Books WHERE id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        book = new Books
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            author = reader["author"].ToString(),
                            genre = reader["genre"].ToString(),
                            language = Convert.ToInt32(reader["language"])
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Handle the exception if needed
                }
            }

            return book;
        }
    }
}
