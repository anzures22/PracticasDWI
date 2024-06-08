using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pracv1.Context;
using Pracv1.Models;

namespace Pracv1.Controllers
{
    public class cRegistradorController : Controller
    {
        private readonly HotelDBMMAAContext _context;

        public cRegistradorController(HotelDBMMAAContext context)
        {
            _context = context;
        }

        // GET: cRegistrador
        public async Task<IActionResult> Index()
        {
              return _context.tRegistrador != null ? 
                          View(await _context.tRegistrador.ToListAsync()) :
                          Problem("Entity set 'HotelDBMMAAContext.tRegistrador'  is null.");
        }

        // GET: cRegistrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tRegistrador == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador
                .FirstOrDefaultAsync(m => m.idRegistrador == id);
            if (cRegistrador == null)
            {
                return NotFound();
            }

            return View(cRegistrador);
        }

        // GET: cRegistrador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cRegistrador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRegistrador,nombre,direccion,documento,telefono,observacion")] cRegistrador cRegistrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRegistrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRegistrador);
        }

        // GET: cRegistrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tRegistrador == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador.FindAsync(id);
            if (cRegistrador == null)
            {
                return NotFound();
            }
            return View(cRegistrador);
        }

        // POST: cRegistrador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRegistrador,nombre,direccion,documento,telefono,observacion")] cRegistrador cRegistrador)
        {
            if (id != cRegistrador.idRegistrador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRegistrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cRegistradorExists(cRegistrador.idRegistrador))
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
            return View(cRegistrador);
        }

        // GET: cRegistrador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tRegistrador == null)
            {
                return NotFound();
            }

            var cRegistrador = await _context.tRegistrador
                .FirstOrDefaultAsync(m => m.idRegistrador == id);
            if (cRegistrador == null)
            {
                return NotFound();
            }

            return View(cRegistrador);
        }

        // POST: cRegistrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tRegistrador == null)
            {
                return Problem("Entity set 'HotelDBMMAAContext.tRegistrador'  is null.");
            }
            var cRegistrador = await _context.tRegistrador.FindAsync(id);
            if (cRegistrador != null)
            {
                _context.tRegistrador.Remove(cRegistrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cRegistradorExists(int id)
        {
          return (_context.tRegistrador?.Any(e => e.idRegistrador == id)).GetValueOrDefault();
        }
    }
}
