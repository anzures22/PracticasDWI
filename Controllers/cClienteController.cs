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
    public class cClienteController : Controller
    {
        private readonly HotelDBMMAAContext _context;

        public cClienteController(HotelDBMMAAContext context)
        {
            _context = context;
        }

        // GET: cCliente
        public async Task<IActionResult> Index()
        {
              return _context.tCliente != null ? 
                          View(await _context.tCliente.ToListAsync()) :
                          Problem("Entity set 'HotelDBMMAAContext.tCliente'  is null.");
        }

        // GET: cCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // GET: cCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCliente);
        }

        // GET: cCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente == null)
            {
                return NotFound();
            }
            return View(cCliente);
        }

        // POST: cCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCliente,nombre,direccion,documento,telefono,fkNacionalidad")] cCliente cCliente)
        {
            if (id != cCliente.idCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cClienteExists(cCliente.idCliente))
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
            return View(cCliente);
        }

        // GET: cCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tCliente == null)
            {
                return NotFound();
            }

            var cCliente = await _context.tCliente
                .FirstOrDefaultAsync(m => m.idCliente == id);
            if (cCliente == null)
            {
                return NotFound();
            }

            return View(cCliente);
        }

        // POST: cCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tCliente == null)
            {
                return Problem("Entity set 'HotelDBMMAAContext.tCliente'  is null.");
            }
            var cCliente = await _context.tCliente.FindAsync(id);
            if (cCliente != null)
            {
                _context.tCliente.Remove(cCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cClienteExists(int id)
        {
          return (_context.tCliente?.Any(e => e.idCliente == id)).GetValueOrDefault();
        }
    }
}
