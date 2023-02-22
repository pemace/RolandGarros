using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RolandGarros.Data;
using RolandGarros.Entities;

namespace RolandGarros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchsController : ControllerBase
    {
        private readonly TennisContext _context;

        public MatchsController(TennisContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchs()
        {
            return await _context.Matchs
                .Include(m => m.Joueur1)
                .Include(m => m.Joueur2)
                .Include(m => m.Joueur1.Nationalite)
                .Include(m => m.Joueur2.Nationalite)
                .Include(m => m.Court)
                .Include(m => m.Arbitre)
                .Include(m => m.SousTournoi)
                .ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _context.Matchs
                .Include(m => m.Joueur1)
                .Include(m => m.Joueur2)
                .Include(m => m.Joueur1.Nationalite)
                .Include(m => m.Joueur2.Nationalite)
                .Include(m => m.Court)
                .Include(m => m.Arbitre)
                .Include(m => m.SousTournoi)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        // PUT: api/Matches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Matches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            _context.Matchs.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matchs.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matchs.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(int id)
        {
            return _context.Matchs.Any(e => e.Id == id);
        }
    }
}
