﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RolandGarros.Data;
using RolandGarros.Entities;
using RolandGarros.Models;

namespace RolandGarros.Controllers
{
    public class JoueursController : Controller
    {
        private readonly TennisContext _context;

        public JoueursController(TennisContext context)
        {
            _context = context;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Joueurs.ToListAsync());
        }

        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Joueurs == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueurs/Create
        public IActionResult Create()
        {
            ViewData["Pays"]= new SelectList(_context.Pays, "Id", "NomFrFr"); 
            return View(new JoueurCreateViewModel());
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JoueurCreateViewModel joueur)
        {
            //TODO : Ajout d'un joueur dans la BDD, création d'un objet joueur
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Joueurs == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sexe,DateNaissance,Classement,Nom,Prenom,Id")] Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueur.Id))
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
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Joueurs == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Joueurs == null)
            {
                return Problem("Entity set 'TennisContext.Joueurs'  is null.");
            }
            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur != null)
            {
                _context.Joueurs.Remove(joueur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoueurExists(int id)
        {
          return _context.Joueurs.Any(e => e.Id == id);
        }
    }
}