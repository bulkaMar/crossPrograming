using Microsoft.AspNetCore.Mvc;
using LAB5.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LAB5.Controllers
{
    public class ServiceBookingController : Controller
    {
        private readonly ServiceBookingService _serviceBookingService;

        public ServiceBookingController(ServiceBookingService serviceBookingService)
        {
            _serviceBookingService = serviceBookingService;
        }

        // Сторінка пошуку
        public IActionResult Search()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var serviceBookings = await _serviceBookingService.GetBookingAsync();
            return View(serviceBookings);
        }
    }
}
