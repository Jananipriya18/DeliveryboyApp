using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    public class FlightController : Controller
    {
        private List<Flight> _flightList; // Collection to store flight information

        public FlightController()
        {
            _flightList = new List<Flight>
            {
                // Adding sample flights to the list
                new Flight("Mumbai", "01h 45m", "Dubai", "₹ 15903", "flydubai", "2137"),
                new Flight("New Delhi", "03h 30m", "Dubai", "₹ 17070", "Emirates", "511"),
                // Add more flights here as needed
            };
        }

        // Action to display all flights
        public IActionResult Index()
        {
            return View(_flightList); // Pass the flight list to the view
        }

        // Other actions for handling flights...
    }
}
