using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LAB6.Models;

namespace LAB6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public ModelsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {
            return await _context.Models.Include(m => m.Manufacturer).ToListAsync();
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            var model = await _context.Models
                                       .Include(m => m.Manufacturer)
                                       .FirstOrDefaultAsync(m => m.ModelCode == id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // POST: api/Models
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model model)
        {
            // Додаємо нову модель
            _context.Models.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModel), new { id = model.ModelCode }, model);
        }
    }
}
