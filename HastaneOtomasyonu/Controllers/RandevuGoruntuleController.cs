using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class RandevuGoruntuleController : Controller
    {
        Uri apiUrl = new Uri("https://localhost:7111/api/Randevus/DurumTrue");
        private readonly HttpClient _client;
        public RandevuGoruntuleController()
        {
            _client = new HttpClient();
            _client.BaseAddress = apiUrl;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
