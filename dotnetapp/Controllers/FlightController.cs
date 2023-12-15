using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using MySql.Data.MySqlClient;

namespace dotnetapp.Controllers
{
    public class FlightController : Controller
    {
        private readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=flightdetails;Uid=root;Pwd=Janani18;";

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO Flights (Departure, Duration, Arrival, Price, Airline, FlightNumber) " +
                                   "VALUES (@Departure, @Duration, @Arrival, @Price, @Airline, @FlightNumber)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Departure", newFlight.Departure);
                    command.Parameters.AddWithValue("@Duration", newFlight.Duration);
                    command.Parameters.AddWithValue("@Arrival", newFlight.Arrival);
                    command.Parameters.AddWithValue("@Price", newFlight.Price);
                    command.Parameters.AddWithValue("@Airline", newFlight.Airline);
                    command.Parameters.AddWithValue("@FlightNumber", newFlight.FlightNumber);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        // Handle the exception, log it, or provide feedback to the user
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                return RedirectToAction("Index");
            }

            return View(newFlight);
        }

        public IActionResult Index()
        {
            List<Flight> flights = new List<Flight>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Flights";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Flight flight = new Flight
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Departure = reader["Departure"].ToString(),
                                Duration = reader["Duration"].ToString(),
                                Arrival = reader["Arrival"].ToString(),
                                Price = reader["Price"].ToString(),
                                Airline = reader["Airline"].ToString(),
                                FlightNumber = reader["FlightNumber"].ToString()
                            };
                            flights.Add(flight);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle the exception, log it, or provide feedback to the user
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return View(flights);
        }

        // Other actions for Update, Delete, etc., can be similarly modified
    }
}
