using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonu.Controllers
{
    public class PanelController : Controller
    {
[Authorize(Roles = "Sena")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
