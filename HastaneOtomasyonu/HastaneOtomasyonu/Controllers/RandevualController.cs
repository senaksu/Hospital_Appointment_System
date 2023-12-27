using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyonu.Models;
using HastaneOtomasyonu.Data;

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
        
    }
}
