using Microsoft.AspNetCore.Mvc;
using LAB5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB5.Controllers
{
    public class CarController : Controller
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetCarsAsync();
            return View(cars);
        }

    }
}
