using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using RolandGarros.Entities;
using RolandGarros.Models;

namespace RolandGarros.Controllers
{
    public class MatchesController : Controller
    {
        private IHttpClientFactory HttpClientFactory { get; }

        public MatchesController(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var listeMatchs = await _context.Matchs
                .Include(m => m.Joueur1)
                .Include(m => m.Joueur2)
                .Include(m => m.Joueur1.Nationalite)
                .Include(m => m.Joueur2.Nationalite)
                .Include(m => m.Court)
                .Include(m => m.Arbitre)
                .Include(m => m.SousTournoi)
                .ToListAsync();

            List<MatchsListViewModel> listeAffichage = new List<MatchsListViewModel>();

            foreach (Match match in listeMatchs)
            {
                var resultat = await _context.Resultats
                            .Include(r => r.Gagnant)
                            .Include(r => r.Match)
                            .SingleOrDefaultAsync(r => r.Match.Id == match.Id);

                int? setsGagnesJoueur1;
                int? setsGagnesJoueur2;


                if (resultat != null)
                {
                    setsGagnesJoueur1 = match.Joueur1.Id == resultat.Gagnant.Id ?
                                            resultat.setsGagnesPourGagnant :
                                            resultat.setsGagnesPourPerdant;
                    setsGagnesJoueur2 = match.Joueur2.Id == resultat.Gagnant.Id ?
                                            resultat.setsGagnesPourGagnant :
                                            resultat.setsGagnesPourPerdant;
                }
                else
                {
                    setsGagnesJoueur1 = null;
                    setsGagnesJoueur2 = null;
                }


                var modele = new MatchsListViewModel()
                {
                    Id = match.Id,
                    Joueur1 = match.Joueur1,
                    Joueur2 = match.Joueur2,
                    Arbitre = match.Arbitre,
                    Court = match.Court,
                    Date = match.Date,
                    SousTournoi = match.SousTournoi,
                    Duree = resultat == null ? null : resultat.Duree,
                    Gagnant = resultat == null ? null : resultat.Gagnant,
                    SetsGagnesPourJoueur1 = setsGagnesJoueur1,
                    SetsGagnesPourJoueur2 = setsGagnesJoueur2
                };
                listeAffichage.Add(modele);
            }


            return View(listeAffichage);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matchs == null)
            {
                return NotFound();
            }

            var match = await _context.Matchs
                .Include(m => m.Joueur1)
                .Include(m => m.Joueur2)
                .Include(m => m.Joueur1.Nationalite)
                .Include(m => m.Joueur2.Nationalite)
                .Include(m => m.SousTournoi)
                .Include(m => m.Arbitre)
                .Include(m => m.Court)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            var resultat = await _context.Resultats
                            .Include(r => r.Gagnant)
                            .Include(r => r.Match)
                            .SingleOrDefaultAsync(r => r.Match.Id == match.Id);


            int? setsGagnesJoueur1;
            int? setsGagnesJoueur2;
            if (resultat != null)
            {
                setsGagnesJoueur1 = match.Joueur1.Id == resultat.Gagnant.Id ?
                                        resultat.setsGagnesPourGagnant :
                                        resultat.setsGagnesPourPerdant;
                setsGagnesJoueur2 = match.Joueur2.Id == resultat.Gagnant.Id ?
                                        resultat.setsGagnesPourGagnant :
                                        resultat.setsGagnesPourPerdant;
            }
            else
            {
                setsGagnesJoueur1 = null;
                setsGagnesJoueur2 = null;
            }

            var modele = new MatchDetailsViewModel()
            {
                Id = match.Id,
                Joueur1 = match.Joueur1,
                Joueur2 = match.Joueur2,
                Arbitre = match.Arbitre,
                Court = match.Court,
                Date = match.Date,
                SousTournoi = match.SousTournoi,
                Duree = resultat == null ? null : resultat.Duree,
                Gagnant = resultat == null ? null : resultat.Gagnant,
                SetsGagnesPourJoueur1 = setsGagnesJoueur1,
                SetsGagnesPourJoueur2 = setsGagnesJoueur2
            };

            return View(modele);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Id")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matchs == null)
            {
                return NotFound();
            }

            var match = await _context.Matchs.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,Id")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matchs == null)
            {
                return NotFound();
            }

            var match = await _context.Matchs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matchs == null)
            {
                return Problem("Entity set 'TennisContext.Matchs'  is null.");
            }
            var match = await _context.Matchs.FindAsync(id);
            if (match != null)
            {
                _context.Matchs.Remove(match);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matchs.Any(e => e.Id == id);
        }
    }
}
