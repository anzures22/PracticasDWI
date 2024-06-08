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
    public class cNacionalidadController : Controller
    {
        private readonly HotelDBMMAAContext _context;

        public cNacionalidadController(HotelDBMMAAContext context)
        {
            _context = context;
        }

        // GET: cNacionalidad
        public async Task<IActionResult> Index()
        {
              return _context.tNacionalidad != null ? 
                          View(await _context.tNacionalidad.ToListAsync()) :
                          Problem("Entity set 'HotelDBMMAAContext.tNacionalidad'  is null.");
        }

        // GET: cNacionalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tNacionalidad == null)
            {
                return NotFound();
            }

            var cNacionalidad = await _context.tNacionalidad
                .FirstOrDefaultAsync(m => m.idNacionalidad == id);
            if (cNacionalidad == null)
            {
                return NotFound();
            }

            return View(cNacionalidad);
        }

        // GET: cNacionalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cNacionalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idNacionalidad,pais,nacionalidad")] cNacionalidad cNacionalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cNacionalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cNacionalidad);
        }

        // GET: cNacionalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tNacionalidad == null)
            {
                return NotFound();
            }

            var cNacionalidad = await _context.tNacionalidad.FindAsync(id);
            if (cNacionalidad == null)
            {
                return NotFound();
            }
            return View(cNacionalidad);
        }

        // POST: cNacionalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idNacionalidad,pais,nacionalidad")] cNacionalidad cNacionalidad)
        {
            if (id != cNacionalidad.idNacionalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cNacionalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cNacionalidadExists(cNacionalidad.idNacionalidad))
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
            return View(cNacionalidad);
        }

        // GET: cNacionalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tNacionalidad == null)
            {
                return NotFound();
            }

            var cNacionalidad = await _context.tNacionalidad
                .FirstOrDefaultAsync(m => m.idNacionalidad == id);
            if (cNacionalidad == null)
            {
                return NotFound();
            }

            return View(cNacionalidad);
        }

        // POST: cNacionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tNacionalidad == null)
            {
                return Problem("Entity set 'HotelDBMMAAContext.tNacionalidad'  is null.");
            }
            var cNacionalidad = await _context.tNacionalidad.FindAsync(id);
            if (cNacionalidad != null)
            {
                _context.tNacionalidad.Remove(cNacionalidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cNacionalidadExists(int id)
        {
          return (_context.tNacionalidad?.Any(e => e.idNacionalidad == id)).GetValueOrDefault();
        }
    }
}
