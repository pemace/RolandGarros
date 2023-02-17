﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using RolandGarros.Data;
using RolandGarros.Entities;
using RolandGarros.Models;

namespace RolandGarros.Controllers
{
    public class JoueursController : Controller
    {
        private readonly TennisContext _context;
        private readonly IWebHostEnvironment HostingEnvironment;

        public JoueursController(TennisContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            HostingEnvironment = hostingEnvironment;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Joueurs.Include(j=>j.Nationalite).ToListAsync());
        }

        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Joueurs == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs.Include(j=>j.Nationalite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            JoueurDetailsViewModel joueurDetailsViewModel = new JoueurDetailsViewModel()
            {
                Id=joueur.Id,
                Nom=joueur.Nom,
                Prenom=joueur.Prenom,
                DateNaissance=joueur.DateNaissance,
                Classement=joueur.Classement,
                Nationalite=joueur.Nationalite,
                Sexe=joueur.Sexe,
                PhotoUrl=joueur.PhotoUrl
            };

            return View(joueurDetailsViewModel);
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
        public async Task<IActionResult> Create(JoueurCreateViewModel joueurViewModel)
        {
            //TODO : Ajout d'un joueur dans la BDD, création d'un objet joueur
            if (ModelState.IsValid)
            {
                var photoUrl = joueurViewModel.Photo == null ? null : await UploadFile(joueurViewModel.Photo);
                Pays? pays = _context.Pays.SingleOrDefault(p=>p.Id==joueurViewModel.NationaliteId);
                if(pays==null)
                {
                    return NotFound();
                }
                Joueur joueur = new Joueur()
                {
                    Nom = joueurViewModel.Nom,
                    Prenom = joueurViewModel.Prenom,
                    Sexe = joueurViewModel.Sexe,
                    DateNaissance = joueurViewModel.DateNaissance,
                    Classement = joueurViewModel.Classement,
                    Nationalite = pays,
                    PhotoUrl = photoUrl
                };
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pays"] = new SelectList(_context.Pays, "Id", "NomFrFr");
            return View(joueurViewModel);
        }

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Joueurs == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs.Include(j=>j.Nationalite).SingleOrDefaultAsync(j=>j.Id==id);
            if (joueur == null)
            {
                return NotFound();
            }
            JoueurEditViewModel joueurEditViewModel = new JoueurEditViewModel()
            {
                Id=joueur.Id,
                Nom=joueur.Nom,
                Prenom=joueur.Prenom,
                Classement=joueur.Classement,
                DateNaissance=joueur.DateNaissance,
                Sexe=joueur.Sexe,
                NationaliteId=joueur.Nationalite.Id,
                PhotoUrl = joueur.PhotoUrl
            };
            ViewData["Pays"] = new SelectList(_context.Pays, "Id", "NomFrFr");
            return View(joueurEditViewModel);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JoueurEditViewModel joueurEditViewModel)
        {
            if (id != joueurEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var photoUrl = joueurEditViewModel.Photo == null ? joueurEditViewModel.PhotoUrl : await UploadFile(joueurEditViewModel.Photo);
                    Pays? pays = _context.Pays.SingleOrDefault(p => p.Id == joueurEditViewModel.NationaliteId);
                    if (pays == null)
                    {
                        return NotFound();
                    }
                    Joueur joueur = new Joueur()
                    {
                        Id=joueurEditViewModel.Id,
                        Nom=joueurEditViewModel.Nom,
                        Prenom= joueurEditViewModel.Prenom,
                        Classement=joueurEditViewModel.Classement,
                        DateNaissance=joueurEditViewModel.DateNaissance, //TODO: Conversion date
                        Nationalite=pays,
                        Sexe=joueurEditViewModel.Sexe,
                        PhotoUrl = photoUrl
                    };
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueurEditViewModel.Id))
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
            ViewData["Pays"] = new SelectList(_context.Pays, "Id", "NomFrFr");
            return View(joueurEditViewModel);
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

        private async Task<string> UploadFile(IFormFile file)
        {
            string webRootPath = HostingEnvironment.WebRootPath;
            var filePath = Path.Combine(webRootPath, "images");
            filePath = Path.Combine(filePath, "profiles");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = Path.GetFileName(file.FileName);
            var copyPath = Path.Combine(filePath, fileName);
            using (var stream = new FileStream(copyPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return @$"/images/profiles/{fileName}";
        }
    }
}
