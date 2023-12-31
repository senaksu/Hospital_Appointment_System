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
    public class RandevusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Randevus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.randevus.Include(r => r.doktor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Randevus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus
                .Include(r => r.doktor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevus/Create
    [Authorize]

        public IActionResult Create()
        {
            ViewData["doktorId"] = new SelectList(_context.doktors, "Id", "doktoradi");
            return View();
        }

        // POST: Randevus/Create
    [Authorize]

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,tc,randevuZamani,doktorId")] Randevu randevu)
        {
            ViewData["doktorId"] = new SelectList(_context.doktors, "Id", "doktoradi", randevu.doktorId);

            _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: Randevus/Edit/5
[Authorize(Roles = "Sena")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["doktorId"] = new SelectList(_context.doktors, "Id", "doktoradi", randevu.doktorId);
            return View(randevu);
        }

        // POST: Randevus/Edit/5
[Authorize(Roles = "Sena")]

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tc,randevuZamani,doktorId")] Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.Id))
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
            ViewData["doktorId"] = new SelectList(_context.doktors, "Id", "doktoradi", randevu.doktorId);
            return View(randevu);
        }

        // GET: Randevus/Delete/5
[Authorize(Roles = "Sena")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus
                .Include(r => r.doktor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevus/Delete/5
        [HttpPost, ActionName("Delete")]
[Authorize(Roles = "Sena")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.randevus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.randevus'  is null.");
            }
            var randevu = await _context.randevus.FindAsync(id);
            if (randevu != null)
            {
                _context.randevus.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return (_context.randevus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
