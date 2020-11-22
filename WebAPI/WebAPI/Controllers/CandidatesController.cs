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
    public class CandidatesController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public CandidatesController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidates>>> GetCandidate()
        {
            var candidateResult = await _context.Candidates.ToListAsync();


            return candidateResult;
        }

        // GET: api/Candidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidates>> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // PUT: api/Candidates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidates candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        [HttpPost]
        public async Task<ActionResult<Candidates>> PostCandidate(Candidates candidate)
        {

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // DELETE: api/Candidates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidates>> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
