using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HastaneOtomasyonu.Controllers
{
    public class PoliklinikListController : Controller
    {
        Uri apiUrl = new Uri("https://localhost:7248/api/Polikliniks/");
        private readonly HttpClient _client;
        public PoliklinikListController()
        {
            _client = new HttpClient();
            _client.BaseAddress = apiUrl;

        }
        
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string veriyakala = await response.Content.ReadAsStringAsync();
                var durumTrueRandevular = JsonConvert.DeserializeObject<IEnumerable<Poliklinik>>(veriyakala);

                return View(durumTrueRandevular);
            }
            else
            {
                return View("Error");
            }

        }
    }
}
