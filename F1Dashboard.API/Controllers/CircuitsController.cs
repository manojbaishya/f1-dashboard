using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1Dashboard.API.Data;
using F1Dashboard.API.Models;

namespace F1Dashboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CircuitsController : ControllerBase
    {
        private readonly F1DbContext _context;

        public CircuitsController(F1DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> GetCircuits()
        {
            return await _context.Circuits.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> GetCircuit(int id)
        {
            var circuit = await _context.Circuits.FindAsync(id);

            if (circuit == null)
            {
                return NotFound();
            }

            return circuit;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Circuit>>> SearchCircuits([FromQuery] string name)
        {
            return await _context.Circuits
                .Where(c => (c.Name != null && c.Name.Contains(name)) || 
                          (c.Country != null && c.Country.Contains(name)))
                .ToListAsync();
        }
    }
} 