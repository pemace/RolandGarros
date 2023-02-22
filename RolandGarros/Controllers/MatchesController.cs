using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            var matchs = await client.GetFromJsonAsync<IEnumerable<MatchsListViewModel>>("api/Matchs");

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
				HttpClient httpClient = HttpClientFactory.CreateClient("API");
				var response = await httpClient.PutAsJsonAsync($"api/Matchs/{id}", matchEditViewModel);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Index));
				}
				return BadRequest();
			}
            return View(matchEditViewModel);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			using HttpClient httpClient = HttpClientFactory.CreateClient("API");
			var match = await httpClient.GetFromJsonAsync<MatchDeleteViewModel>($"api/Matchs/{id}");
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
			using HttpClient httpClient = HttpClientFactory.CreateClient("API");
			var response = await httpClient.DeleteAsync($"api/Matchs/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction(nameof(Index));
			}
			return BadRequest();
		}

        private async Task<bool> MatchExists(int id)
        {
			HttpClient client = HttpClientFactory.CreateClient("API");
			var match = await client.GetFromJsonAsync<Match>($"api/Matchs/{id}");
			return match != null;
		}
    }
}
