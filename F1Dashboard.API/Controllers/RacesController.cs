using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1Dashboard.API.Data;
using F1Dashboard.API.Models;

namespace F1Dashboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly F1DbContext _context;

        public RacesController(F1DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetRaces()
        {
            return await _context.Races
                .Include(r => r.Circuit)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            var race = await _context.Races
                .Include(r => r.Circuit)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<Race>>> GetRacesByYear(int year)
        {
            return await _context.Races
                .Include(r => r.Circuit)
                .Where(r => r.Year == year)
                .OrderBy(r => r.Round)
                .ToListAsync();
        }
    }
} 