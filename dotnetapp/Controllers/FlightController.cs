using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class FlightController : Controller
{
    private static readonly List<Flight> _flightList = new List<Flight>
    {
        new Flight("Mumbai", "01h 45m", "Dubai", "₹ 15903", "flydubai", "2137"),
        new Flight("New Delhi", "03h 30m", "Dubai", "₹ 17070", "Emirates", "511")
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
}

}
