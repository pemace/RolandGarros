using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using RolandGarros.Entities;
using RolandGarros.Models;
using System.Net.Http;

namespace RolandGarros.Controllers
{
    public class ResultatsController : Controller
    {
        private IHttpClientFactory HttpClientFactory { get; }
        private readonly IWebHostEnvironment HostingEnvironment;

        public ResultatsController(IHttpClientFactory httpClientFactory, IWebHostEnvironment hostingEnvironment)
        {
            HttpClientFactory = httpClientFactory;
            HostingEnvironment = hostingEnvironment;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
            HttpClient client = HttpClientFactory.CreateClient("API");
            var resultats = await client.GetFromJsonAsync<IEnumerable<Resultat>>("api/Resultats");

            return View(resultats);
        }
        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpClient client = HttpClientFactory.CreateClient("API");
            var resultat = await client.GetFromJsonAsync<ResultatDetailsViewModel>($"api/Resulats/{id}");

            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat);
        }

    }
}
