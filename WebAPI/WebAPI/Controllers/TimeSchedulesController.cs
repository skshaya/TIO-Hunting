using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSchedulesController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public TimeSchedulesController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/TimeSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSchedule>>> GetTimeSchedule()
        {
            return await _context.TimeSchedule.ToListAsync();
        }

        // GET: api/TimeSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSchedule>> GetTimeSchedule(int id)
        {
            var timeSchedule = await _context.TimeSchedule.FindAsync(id);

            if (timeSchedule == null)
            {
                return NotFound();
            }

            return timeSchedule;
        }

        // PUT: api/TimeSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSchedule(int id, TimeSchedule timeSchedule)
        {
            if (id != timeSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TimeSchedules
        [HttpPost]
        public async Task<ActionResult<TimeSchedule>> PostTimeSchedule(TimeSchedule timeSchedule)
        {
            _context.TimeSchedule.Add(timeSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeSchedule", new { id = timeSchedule.Id }, timeSchedule);
        }

        // DELETE: api/TimeSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeSchedule>> DeleteTimeSchedule(int id)
        {
            var timeSchedule = await _context.TimeSchedule.FindAsync(id);
            if (timeSchedule == null)
            {
                return NotFound();
            }

            _context.TimeSchedule.Remove(timeSchedule);
            await _context.SaveChangesAsync();

            return timeSchedule;
        }

        private bool TimeScheduleExists(int id)
        {
            return _context.TimeSchedule.Any(e => e.Id == id);
        }
    }
}
