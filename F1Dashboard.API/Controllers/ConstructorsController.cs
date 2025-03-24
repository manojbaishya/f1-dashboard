using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1Dashboard.API.Data;
using F1Dashboard.API.Models;

namespace F1Dashboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConstructorsController : ControllerBase
    {
        private readonly F1DbContext _context;

        public ConstructorsController(F1DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constructor>>> GetConstructors()
        {
            return await _context.Constructors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Constructor>> GetConstructor(int id)
        {
            var constructor = await _context.Constructors.FindAsync(id);

            if (constructor == null)
            {
                return NotFound();
            }

            return constructor;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Constructor>>> SearchConstructors([FromQuery] string name)
        {
            return await _context.Constructors
                .Where(c => c.Name != null && c.Name.Contains(name))
                .ToListAsync();
        }
    }
} 