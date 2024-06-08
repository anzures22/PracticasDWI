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
    public class cAlquilerController : Controller
    {
        private readonly HotelDBMMAAContext _context;

        public cAlquilerController(HotelDBMMAAContext context)
        {
            _context = context;
        }

        // GET: cAlquiler
        public async Task<IActionResult> Index()
        {
              return _context.tAlquiler != null ? 
                          View(await _context.tAlquiler.ToListAsync()) :
                          Problem("Entity set 'HotelDBMMAAContext.tAlquiler'  is null.");
        }

        // GET: cAlquiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // GET: cAlquiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cAlquiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlquiler,fechaHoraEntrada,fechaHoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAlquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAlquiler);
        }

        // GET: cAlquiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler == null)
            {
                return NotFound();
            }
            return View(cAlquiler);
        }

        // POST: cAlquiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlquiler,fechaHoraEntrada,fechaHoraSalida,costoTotal,observacion,fkHabitacion,fkCliente,fkRegistrador,fkEstado")] cAlquiler cAlquiler)
        {
            if (id != cAlquiler.idAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAlquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cAlquilerExists(cAlquiler.idAlquiler))
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
            return View(cAlquiler);
        }

        // GET: cAlquiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tAlquiler == null)
            {
                return NotFound();
            }

            var cAlquiler = await _context.tAlquiler
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (cAlquiler == null)
            {
                return NotFound();
            }

            return View(cAlquiler);
        }

        // POST: cAlquiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tAlquiler == null)
            {
                return Problem("Entity set 'HotelDBMMAAContext.tAlquiler'  is null.");
            }
            var cAlquiler = await _context.tAlquiler.FindAsync(id);
            if (cAlquiler != null)
            {
                _context.tAlquiler.Remove(cAlquiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cAlquilerExists(int id)
        {
          return (_context.tAlquiler?.Any(e => e.idAlquiler == id)).GetValueOrDefault();
        }
    }
}
