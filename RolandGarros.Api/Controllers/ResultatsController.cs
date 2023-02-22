using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ResultatsController : ControllerBase
    {
        private readonly TennisContext _context;

        public ResultatsController(TennisContext context)
        {
            _context = context;
        }

        // GET: api/Resultats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resultat>>> GetResultats()
        {
            return await _context.Resultats
               .Include(r => r.Gagnant)
               .Include(r => r.Match)
               .Include(r => r.Match.Joueur1)
               .Include(r => r.Match.Joueur1.Nationalite)
               .Include(r => r.Match.Joueur2)
               .Include(r => r.Match.Joueur2.Nationalite)
               .ToListAsync();
        }

        // GET: api/Resultats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resultat>> GetResultat(int id)
        {
            var resultat = await _context.Resultats
               .Include(r => r.Gagnant)
               .Include(r => r.Match)
               .Include(r => r.Match.Joueur1)
               .Include(r => r.Match.Joueur1.Nationalite)
               .Include(r => r.Match.Joueur2)
               .Include(r => r.Match.Joueur2.Nationalite)
               .SingleOrDefaultAsync(r => r.Id == id);
        
            if (resultat == null)
            {
                return NotFound();
            }

            return resultat;
        }

        // PUT: api/Resultats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultat(int id, Resultat resultat)
        {
            if (id != resultat.Id)
            {
                return BadRequest();
            }

            _context.Entry(resultat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultatExists(id))
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

        // POST: api/Resultats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resultat>> PostResultat(Resultat resultat)
        {
            _context.Resultats.Add(resultat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultat", new { id = resultat.Id }, resultat);
        }

        // DELETE: api/Resultats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultat(int id)
        {
            var resultat = await _context.Resultats.FindAsync(id);
            if (resultat == null)
            {
                return NotFound();
            }

            _context.Resultats.Remove(resultat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultatExists(int id)
        {
            return _context.Resultats.Any(e => e.Id == id);
        }
    }
}
