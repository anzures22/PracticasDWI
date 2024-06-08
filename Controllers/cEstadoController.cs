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
    public class cEstadoController : Controller
    {
        private readonly HotelDBMMAAContext _context;

        public cEstadoController(HotelDBMMAAContext context)
        {
            _context = context;
        }

        // GET: cEstado
        public async Task<IActionResult> Index()
        {
              return _context.tEstado != null ? 
                          View(await _context.tEstado.ToListAsync()) :
                          Problem("Entity set 'HotelDBMMAAContext.tEstado'  is null.");
        }

        // GET: cEstado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tEstado == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado
                .FirstOrDefaultAsync(m => m.idEstado == id);
            if (cEstado == null)
            {
                return NotFound();
            }

            return View(cEstado);
        }

        // GET: cEstado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cEstado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstado,nombre")] cEstado cEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cEstado);
        }

        // GET: cEstado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tEstado == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado.FindAsync(id);
            if (cEstado == null)
            {
                return NotFound();
            }
            return View(cEstado);
        }

        // POST: cEstado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEstado,nombre")] cEstado cEstado)
        {
            if (id != cEstado.idEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cEstadoExists(cEstado.idEstado))
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
            return View(cEstado);
        }

        // GET: cEstado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tEstado == null)
            {
                return NotFound();
            }

            var cEstado = await _context.tEstado
                .FirstOrDefaultAsync(m => m.idEstado == id);
            if (cEstado == null)
            {
                return NotFound();
            }

            return View(cEstado);
        }

        // POST: cEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tEstado == null)
            {
                return Problem("Entity set 'HotelDBMMAAContext.tEstado'  is null.");
            }
            var cEstado = await _context.tEstado.FindAsync(id);
            if (cEstado != null)
            {
                _context.tEstado.Remove(cEstado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cEstadoExists(int id)
        {
          return (_context.tEstado?.Any(e => e.idEstado == id)).GetValueOrDefault();
        }
    }
}
