using Microsoft.AspNetCore.Mvc;
using LAB5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5.Controllers
{
    public class SearchController : Controller
    {
        private readonly CarService _carService;
        private readonly ManufacturerService _manufacturerService;
        private readonly ServiceBookingService _serviceBookingService;

        public SearchController(
            CarService carService,
            ManufacturerService manufacturerService,
            ServiceBookingService serviceBookingService)
        {
            _carService = carService;
            _manufacturerService = manufacturerService;
            _serviceBookingService = serviceBookingService;
        }

        // Відображення сторінки пошуку
        public IActionResult Index()
        {
            return View();
        }

        // Обробка запиту пошуку
        [HttpPost]
        public async Task<IActionResult> Results(
            DateTime? startDate,
            DateTime? endDate,
            string carModelName,
            string manufacturerName,
            string licenceNumber)
        {
            // Отримуємо список автомобілів
            var cars = await _carService.GetCarsAsync();

            // Фільтруємо за моделлю
            if (!string.IsNullOrWhiteSpace(carModelName))
            {
                cars = cars.Where(c => c.Model.ModelName.Contains(carModelName)).ToList();
            }

            // Отримуємо список виробників
            var manufacturers = await _manufacturerService.GetManufacturersAsync();

            // Фільтруємо за виробником
            if (!string.IsNullOrWhiteSpace(manufacturerName))
            {
                manufacturers = manufacturers.Where(m => m.ManufacturerName.Contains(manufacturerName)).ToList();
                cars = cars.Where(c => manufacturers.Any(m => m.ManufacturerCode == c.Model.ManufacturerCode)).ToList();
            }

            // Отримуємо список бронювань
            var bookings = await _serviceBookingService.GetBookingAsync();

            // Фільтруємо за датою та номером
            if (startDate.HasValue)
                bookings = bookings.Where(b => b.DateTimeOfService >= startDate).ToList();

            if (endDate.HasValue)
                bookings = bookings.Where(b => b.DateTimeOfService <= endDate).ToList();

            if (!string.IsNullOrWhiteSpace(licenceNumber))
                bookings = bookings.Where(b => b.LicenceNumber.StartsWith(licenceNumber)).ToList();

            // Поєднуємо дані (JOIN)
            var results = bookings
                .Where(b => cars.Any(c => c.LicenceNumber == b.LicenceNumber))
                .Select(b => new
                {
                    BookingId = b.SvcBookingId,
                    ModelName = cars.First(c => c.LicenceNumber == b.LicenceNumber).Model.ModelName,
                    ManufacturerName = manufacturers.First(m => m.ManufacturerCode == cars.First(c => c.LicenceNumber == b.LicenceNumber).Model.ManufacturerCode).ManufacturerName,
                    CustomerName = $"{b.Customer.FirstName} {b.Customer.LastName}",
                    b.DateTimeOfService
                })
                .ToList();

            return View(results);
        }
    }
}
