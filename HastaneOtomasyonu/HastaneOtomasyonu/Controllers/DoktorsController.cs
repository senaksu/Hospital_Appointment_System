﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneOtomasyonu.Data;
using HastaneOtomasyonu.Models;

namespace HastaneOtomasyonu.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doktors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.doktors.Include(d => d.poliklinik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors
                .Include(d => d.poliklinik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            ViewData["PoliklinikId"] = new SelectList(_context.polikliniks, "Id", "adi");
            return View();
        }

        // POST: Doktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,doktoradi,muayeneucreti,PoliklinikId")] Doktor doktor)
        {
            ViewData["PoliklinikId"] = new SelectList(_context.polikliniks, "Id", "adi", doktor.PoliklinikId);

            _context.Add(doktor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            ViewData["PoliklinikId"] = new SelectList(_context.polikliniks, "Id", "adi", doktor.PoliklinikId);
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,doktoradi,muayeneucreti,PoliklinikId")] Doktor doktor)
        {
            if (id != doktor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.Id))
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
            ViewData["PoliklinikId"] = new SelectList(_context.polikliniks, "Id", "adi", doktor.PoliklinikId);
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors
                .Include(d => d.poliklinik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doktors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.doktors'  is null.");
            }
            var doktor = await _context.doktors.FindAsync(id);
            if (doktor != null)
            {
                _context.doktors.Remove(doktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return (_context.doktors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
