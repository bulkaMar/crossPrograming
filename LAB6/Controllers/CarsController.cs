using LAB6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarsController(CarServiceContext context)
        {
            _context = context;
        }


        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _context.Cars
                .Include(c => c.Model) 
                .Include(c => c.Customer)
                .ToListAsync();
            return Ok(cars);
        }

        // GET: api/Cars/{licenceNumber}
        [HttpGet("{licenceNumber}")]
        public async Task<ActionResult<Car>> GetCar(string licenceNumber)
        {
            var car = await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.LicenceNumber == licenceNumber);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { licenceNumber = car.LicenceNumber }, car);
        }

    }
}
