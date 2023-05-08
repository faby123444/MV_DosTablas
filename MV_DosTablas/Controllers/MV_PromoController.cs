using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MV_DosTablas.Data;
using MV_DosTablas.Models;

namespace MV_DosTablas.Controllers
{
    public class MV_PromoController : Controller
    {
        private readonly MV_DosTablasContext _context;

        public MV_PromoController(MV_DosTablasContext context)
        {
            _context = context;
        }

        // GET: MV_Promo
        public async Task<IActionResult> Index()
        {
              return _context.MV_Promo != null ? 
                          View(await _context.MV_Promo.ToListAsync()) :
                          Problem("Entity set 'MV_DosTablasContext.MV_Promo'  is null.");
        }

        // GET: MV_Promo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MV_Promo == null)
            {
                return NotFound();
            }

            var mV_Promo = await _context.MV_Promo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mV_Promo == null)
            {
                return NotFound();
            }

            return View(mV_Promo);
        }

        // GET: MV_Promo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MV_Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoId,Descripcion,FechaPromo,Id")] MV_Promo mV_Promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mV_Promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mV_Promo);
        }

        // GET: MV_Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MV_Promo == null)
            {
                return NotFound();
            }

            var mV_Promo = await _context.MV_Promo.FindAsync(id);
            if (mV_Promo == null)
            {
                return NotFound();
            }
            return View(mV_Promo);
        }

        // POST: MV_Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoId,Descripcion,FechaPromo,Id")] MV_Promo mV_Promo)
        {
            if (id != mV_Promo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mV_Promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MV_PromoExists(mV_Promo.Id))
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
            return View(mV_Promo);
        }

        // GET: MV_Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MV_Promo == null)
            {
                return NotFound();
            }

            var mV_Promo = await _context.MV_Promo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mV_Promo == null)
            {
                return NotFound();
            }

            return View(mV_Promo);
        }

        // POST: MV_Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MV_Promo == null)
            {
                return Problem("Entity set 'MV_DosTablasContext.MV_Promo'  is null.");
            }
            var mV_Promo = await _context.MV_Promo.FindAsync(id);
            if (mV_Promo != null)
            {
                _context.MV_Promo.Remove(mV_Promo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MV_PromoExists(int id)
        {
          return (_context.MV_Promo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
