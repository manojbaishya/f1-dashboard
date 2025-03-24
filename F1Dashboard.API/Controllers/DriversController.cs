using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1Dashboard.API.Data;
using F1Dashboard.API.Models;

namespace F1Dashboard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly F1DbContext _context;

        public DriversController(F1DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Driver>>> SearchDrivers([FromQuery] string name)
        {
            return await _context.Drivers
                .Where(d => (d.Forename != null && d.Forename.Contains(name)) || 
                          (d.Surname != null && d.Surname.Contains(name)))
                .ToListAsync();
        }
    }
} 