using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
            HttpClient client = HttpClientFactory.CreateClient("API");

            var matchs = await client.GetFromJsonAsync<IEnumerable<Match>>("api/Matchs");

            return View(matchs);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            HttpClient httpClient = HttpClientFactory.CreateClient("API");

            var match = await httpClient.GetFromJsonAsync<MatchDetailsViewModel>($"api/Matchs/{id}");

           
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
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
        public async Task<IActionResult> Create(MatchCreateViewModel matchViewModel)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpClient = HttpClientFactory.CreateClient("API");
                var match = await httpClient.PostAsJsonAsync<MatchCreateViewModel>("api/Matchs", matchViewModel) ;

                return RedirectToAction(nameof(Index));
            }
            return View(matchViewModel);
        }
        //TODO: Faire les vues

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using HttpClient httpClient = HttpClientFactory.CreateClient("API");
            var match = await httpClient.GetFromJsonAsync<MatchEditViewModel>($"api/Matchs/{id}");
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
        public async Task<IActionResult> Edit(int id, MatchEditViewModel matchEditViewModel)
        {
            if (id != matchEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchEditViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(matchEditViewModel.Id))
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
            return View(matchEditViewModel);
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
