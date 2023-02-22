using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RolandGarros.Entities;
using RolandGarros.Models;
using System.Text.Json;

namespace RolandGarros.Controllers
{
    public class JoueursController : Controller
    {
		private IHttpClientFactory HttpClientFactory { get; }
		private readonly IWebHostEnvironment HostingEnvironment;

        public JoueursController(IHttpClientFactory httpClientFactory, IWebHostEnvironment hostingEnvironment)
        {
			HttpClientFactory = httpClientFactory;
            HostingEnvironment = hostingEnvironment;
        }
        
        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
            HttpClient client = HttpClientFactory.CreateClient("API");
			var joueurs = await client.GetFromJsonAsync<IEnumerable<Joueur>>("api/Joueurs");

			return View(joueurs);
        }

        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			HttpClient client = HttpClientFactory.CreateClient("API");
			var joueur = await client.GetFromJsonAsync<JoueurDetailsViewModel>($"api/Joueurs/{id}");

            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueurs/Create
        public async Task<IActionResult> Create()
        {
			HttpClient client = HttpClientFactory.CreateClient("API");
			var pays = await client.GetFromJsonAsync<IEnumerable<Pays>>($"api/Pays");

			ViewData["Pays"]= new SelectList(pays , "Id", "NomFrFr"); 
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

                using HttpClient httpClient = HttpClientFactory.CreateClient("API");
                var pays = await httpClient.GetFromJsonAsync<Pays>($"api/Pays/{joueurViewModel.NationaliteId}");
                if (pays == null)
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
                    NationaliteId = joueurViewModel.NationaliteId,
                    PhotoUrl = photoUrl,
                    Nationalite=pays
                };

				string message=JsonSerializer.Serialize(joueur);

				var response = await httpClient.PostAsJsonAsync("api/Joueurs", joueur);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Index));
				}
				return BadRequest();
            }
			HttpClient client = HttpClientFactory.CreateClient("API");
			var listePays = await client.GetFromJsonAsync<IEnumerable<Pays>>($"api/Pays");

			ViewData["Pays"] = new SelectList(listePays, "Id", "NomFrFr");
            return View(joueurViewModel);
        }

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			using HttpClient httpClient = HttpClientFactory.CreateClient("API");
			var joueur = await httpClient.GetFromJsonAsync<JoueurEditViewModel>($"api/Joueurs/{id}");

			if (joueur == null)
            {
                return NotFound();
            }

			HttpClient client = HttpClientFactory.CreateClient("API");
			var pays = await client.GetFromJsonAsync<IEnumerable<Pays>>($"api/Pays");
			ViewData["Pays"] = new SelectList(pays, "Id", "NomFrFr");
            return View(joueur);
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
                var photoUrl = joueurEditViewModel.Photo == null ? joueurEditViewModel.PhotoUrl : await UploadFile(joueurEditViewModel.Photo);
					
                HttpClient httpClient = HttpClientFactory.CreateClient("API");
				var pays = await httpClient.GetFromJsonAsync<Pays>($"api/Pays/{joueurEditViewModel.NationaliteId}");

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

				httpClient = HttpClientFactory.CreateClient("API");
				var response = await httpClient.PutAsJsonAsync($"api/Joueurs/{id}", joueur);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Index));
				}
				return BadRequest();
            }


		    HttpClient client = HttpClientFactory.CreateClient("API");
		    var listePays = await client.GetFromJsonAsync<IEnumerable<Pays>>($"api/Pays");
		    ViewData["Pays"] = new SelectList(listePays, "Id", "NomFrFr");
            return View(joueurEditViewModel);
        }

        // GET: Joueurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
			using HttpClient httpClient = HttpClientFactory.CreateClient("API");
			var joueur = await httpClient.GetFromJsonAsync<Joueur>($"api/Joueurs/{id}");
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
			using HttpClient httpClient = HttpClientFactory.CreateClient("API");
			var response = await httpClient.DeleteAsync($"api/Joueurs/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction(nameof(Index));
			}
			return BadRequest();
		}

        private async Task<bool> JoueurExists(int id)
        {
			HttpClient client = HttpClientFactory.CreateClient("API");
			var joueur = await client.GetFromJsonAsync<JoueurDetailsViewModel>($"api/Joueurs/{id}");
			return joueur!=null;
        }

        //TODO: A Déplacer dans API
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
