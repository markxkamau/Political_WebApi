using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingApi.Models;

namespace TrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticalCandidateController : ControllerBase
    {
        private readonly PoliticalCandidateContext _context;

        public PoliticalCandidateController(PoliticalCandidateContext context)
        {
            _context = context;
        }

        // GET: api/PoliticalCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliticalCandidate>>> GetPoliticalCandidate()
        {
          if (_context.PoliticalCandidate == null)
          {
              return NotFound();
          }
            return await _context.PoliticalCandidate.ToListAsync();
        }

        // GET: api/PoliticalCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PoliticalCandidate>> GetPoliticalCandidate(int id)
        {
          if (_context.PoliticalCandidate == null)
          {
              return NotFound();
          }
            var politicalCandidate = await _context.PoliticalCandidate.FindAsync(id);

            if (politicalCandidate == null)
            {
                return NotFound();
            }

            return politicalCandidate;
        }

        // PUT: api/PoliticalCandidate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliticalCandidate(int id, PoliticalCandidate politicalCandidate)
        {
            if (id != politicalCandidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(politicalCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliticalCandidateExists(id))
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

        // POST: api/PoliticalCandidate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PoliticalCandidate>> PostPoliticalCandidate(PoliticalCandidate politicalCandidate)
        {
          if (_context.PoliticalCandidate == null)
          {
              return Problem("Entity set 'PoliticalCandidateContext.PoliticalCandidate'  is null.");
          }
            _context.PoliticalCandidate.Add(politicalCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoliticalCandidate", new { id = politicalCandidate.Id }, politicalCandidate);
        }

        // DELETE: api/PoliticalCandidate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliticalCandidate(int id)
        {
            if (_context.PoliticalCandidate == null)
            {
                return NotFound();
            }
            var politicalCandidate = await _context.PoliticalCandidate.FindAsync(id);
            if (politicalCandidate == null)
            {
                return NotFound();
            }

            _context.PoliticalCandidate.Remove(politicalCandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliticalCandidateExists(int id)
        {
            return (_context.PoliticalCandidate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
