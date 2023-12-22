using Microsoft.AspNetCore.Mvc;
using Deliveryboy.Models;
using System;
using System.Linq;
// using Deliveryboy.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Deliveryboy.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var ordersWithStatus = _context.Order.Include(o => o.DeliveryStatus).ToList();
            RefreshCountsInViewBag();
            var deliveryStatuses = GetDeliveryStatuses();
            ViewBag.DeliveryStatuses = deliveryStatuses;
            return View(ordersWithStatus);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                var order = _context.Order
                    .Include(o => o.DeliveryStatus)
                    .FirstOrDefault(o => o.OrderID == orderId);

                if (order == null)
                {
                    return NotFound();
                }
                var latestDelivery = order.DeliveryStatus?.OrderByDescending(d => d.Date).FirstOrDefault();
                if (latestDelivery != null)
                {
                    latestDelivery.Status = status;
                    latestDelivery.Date = DateTime.Now;
                }
                else
                {
                    // If no existing delivery status, create a new one
                    var newDelivery = new Delivery
                    {
                        OrderID = orderId,
                        Date = DateTime.Now,
                        Status = status
                    };

                    order.DeliveryStatus = new List<Delivery> { newDelivery };
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500); // Internal Server Error
            }

            RefreshCountsInViewBag();
            var deliveryStatuses = GetDeliveryStatuses();
            ViewBag.DeliveryStatuses = deliveryStatuses;

            return RedirectToAction("Dashboard");
        }

        private void RefreshCountsInViewBag()
        {
            ViewBag.TotalOrders = _context.Order.Count();
            ViewBag.PendingOrders = _context.Delivery.Count(d => d.Status == "Pending");
            ViewBag.OutForDeliveryOrders = _context.Delivery.Count(d => d.Status == "Out for Delivery");
            ViewBag.InTransitOrders = _context.Delivery.Count(d => d.Status == "In Transit");
            ViewBag.DeliveredOrders = _context.Delivery.Count(d => d.Status == "Delivered");
        }

        private List<string> GetDeliveryStatuses()
        {
            return _context.Delivery.Select(d => d.Status).Distinct().ToList();
        }
    }
}
