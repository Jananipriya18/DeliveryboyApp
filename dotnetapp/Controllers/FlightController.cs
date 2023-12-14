using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class FlightController : Controller
    {
        private static readonly List<Flight> _flightList = new List<Flight>
        {
            new Flight(1,"Mumbai", "01h 45m", "Dubai", "₹ 15903", "flydubai", "2137"),
            new Flight(2,"New Delhi", "03h 30m", "Dubai", "₹ 17070", "Emirates", "511")
        };

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                _flightList.Add(newFlight);
                return RedirectToAction("Index");
            }

            return View(newFlight);
        }

        public IActionResult Index()
        {
            return View(_flightList);
        }

        public IActionResult Update(int id)
        {
            var flightToUpdate = _flightList.FirstOrDefault(f => f.ID == id);
            if (flightToUpdate == null)
            {
                return NotFound(); // Or handle the case where the flight doesn't exist
            }

            return View(flightToUpdate);
        }

        [HttpPost]
        public IActionResult Update(int id, Flight updatedFlight)
        {
            var flightToUpdate = _flightList.FirstOrDefault(f => f.ID == id);
            if (flightToUpdate == null)
            {
                return NotFound(); // Or handle the case where the flight doesn't exist
            }

            // Update the properties of the existing flight
            flightToUpdate.Departure = updatedFlight.Departure;
            flightToUpdate.Duration = updatedFlight.Duration;
            flightToUpdate.Arrival = updatedFlight.Arrival;
            flightToUpdate.Price = updatedFlight.Price;
            flightToUpdate.Airline = updatedFlight.Airline;
            flightToUpdate.FlightNumber = updatedFlight.FlightNumber;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var flightToDelete = _flightList.FirstOrDefault(f => f.ID == id);
            if (flightToDelete == null)
            {
                return NotFound(); // Or handle the case where the flight doesn't exist
            }

            _flightList.Remove(flightToDelete);

            return RedirectToAction("Index");
        }
    }
}
