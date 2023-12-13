using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models; // Ensure to include your Flight model namespace

namespace dotnetapp.Controllers
{
    public class FlightController : Controller
    {
        private readonly List<Flight> _flightList; // Collection to store flight information

        public FlightController()
        {
            // Initialize an empty list for flights
            _flightList = new List<Flight>();
        }

        // Action to display the flight creation form
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle form submission and create a new flight
        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                // Add the submitted flight to the flight list
                _flightList.Add(newFlight);

                // Redirect to the index or any other appropriate action
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return back to the form view
            return View(newFlight);
        }

        // Action to display all flights
        public IActionResult Index()
        {
            return View(_flightList);
        }

        // Other actions for handling flights...
    }
}
