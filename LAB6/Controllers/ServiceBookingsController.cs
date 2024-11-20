using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB6.Models;

namespace LAB6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public ServiceBookingsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBooking>>> GetServiceBookings()
        {
            return await _context.ServiceBookings.Include(s => s.Customer).Include(s => s.Car).ToListAsync();
        }

        // GET: api/ServiceBookings/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBooking>> GetServiceBooking(int id)
        {
            var serviceBooking = await _context.ServiceBookings
                                               .Include(s => s.Customer)
                                               .Include(s => s.Car)
                                               .FirstOrDefaultAsync(s => s.SvcBookingId == id);

            if (serviceBooking == null)
            {
                return NotFound();
            }

            return serviceBooking;
        }

        // POST: api/ServiceBookings
        [HttpPost]
        public async Task<ActionResult<ServiceBooking>> PostServiceBooking(ServiceBooking serviceBooking)
        {
            _context.ServiceBookings.Add(serviceBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceBooking), new { id = serviceBooking.SvcBookingId }, serviceBooking);
        }
    }
}
