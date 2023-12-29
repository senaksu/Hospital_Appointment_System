using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyonu.Models;
using HastaneOtomasyonu.Data;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu.Controllers
{
    public class RandevualController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevualController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler =_context.polikliniks.ToList();
            return View(degerler);
        }
        public IActionResult kategoriSec(int id)
        {
            var degerler= _context.polikliniks.ToList();
            var doktor = _context.doktors.Where(x=> x.PoliklinikId== id);

            return View(doktor);
        }
        public IActionResult RandevuGoruntule()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Listele([FromBody] string tc)
        {
            if (string.IsNullOrEmpty(tc))
            {
                ModelState.AddModelError("tc", "TC Kimlik numarası boş olamaz");
                return View("Index");
            }

            var randevular = _context.randevus
                .Include(r => r.doktor)
                .Where(r => r.tc == tc)
                .ToList();

            if (randevular.Count == 0)
            {
                ViewBag.Message = "Belirtilen TC Kimlik numarasına ait randevu bulunamadı.";
            }

            return View(randevular);
        }

      

    }
}
