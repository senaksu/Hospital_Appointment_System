using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneOtomasyonu.Data;
using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;

namespace HastaneOtomasyonu.Controllers
{
    [Authorize]

    public class PolikliniksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolikliniksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Polikliniks
        public async Task<IActionResult> Index()
        {
              return _context.polikliniks != null ? 
                          View(await _context.polikliniks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.polikliniks'  is null.");
        }

        // GET: Polikliniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // GET: Polikliniks/Create
[Authorize(Roles = "Sena")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Polikliniks/Create
[Authorize(Roles ="Sena")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,adi")] Poliklinik poliklinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }

        // GET: Polikliniks/Edit/5
[Authorize(Roles = "Sena")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
        }

        // POST: Polikliniks/Edit/5
[Authorize(Roles = "Sena")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,adi")] Poliklinik poliklinik)
        {
            if (id != poliklinik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(poliklinik.Id))
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
            return View(poliklinik);
        }

        // GET: Polikliniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // POST: Polikliniks/Delete/5
        [HttpPost, ActionName("Delete")]
[Authorize(Roles = "Sena")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.polikliniks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.polikliniks'  is null.");
            }
            var poliklinik = await _context.polikliniks.FindAsync(id);
            if (poliklinik != null)
            {
                _context.polikliniks.Remove(poliklinik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
          return (_context.polikliniks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
