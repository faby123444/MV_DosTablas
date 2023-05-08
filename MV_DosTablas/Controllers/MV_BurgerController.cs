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
    public class MV_BurgerController : Controller
    {
        private readonly MV_DosTablasContext _context;

        public MV_BurgerController(MV_DosTablasContext context)
        {
            _context = context;
        }

        // GET: MV_Burger
        public async Task<IActionResult> Index()
        {
              return _context.MV_Burger != null ? 
                          View(await _context.MV_Burger.ToListAsync()) :
                          Problem("Entity set 'MV_DosTablasContext.MV_Burger'  is null.");
        }

        // GET: MV_Burger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MV_Burger == null)
            {
                return NotFound();
            }

            var mV_Burger = await _context.MV_Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mV_Burger == null)
            {
                return NotFound();
            }

            return View(mV_Burger);
        }

        // GET: MV_Burger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MV_Burger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,WithCheese")] MV_Burger mV_Burger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mV_Burger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mV_Burger);
        }

        // GET: MV_Burger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MV_Burger == null)
            {
                return NotFound();
            }

            var mV_Burger = await _context.MV_Burger.FindAsync(id);
            if (mV_Burger == null)
            {
                return NotFound();
            }
            return View(mV_Burger);
        }

        // POST: MV_Burger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,WithCheese")] MV_Burger mV_Burger)
        {
            if (id != mV_Burger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mV_Burger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MV_BurgerExists(mV_Burger.Id))
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
            return View(mV_Burger);
        }

        // GET: MV_Burger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MV_Burger == null)
            {
                return NotFound();
            }

            var mV_Burger = await _context.MV_Burger
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mV_Burger == null)
            {
                return NotFound();
            }

            return View(mV_Burger);
        }

        // POST: MV_Burger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MV_Burger == null)
            {
                return Problem("Entity set 'MV_DosTablasContext.MV_Burger'  is null.");
            }
            var mV_Burger = await _context.MV_Burger.FindAsync(id);
            if (mV_Burger != null)
            {
                _context.MV_Burger.Remove(mV_Burger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MV_BurgerExists(int id)
        {
          return (_context.MV_Burger?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
