using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using firstApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace firstApp.Controllers
{
[Authorize]
    public class DatosController : Controller
    {
        private readonly ejemplocontext _context;

        public DatosController(ejemplocontext context)
        {
            _context = context;
        }

        // GET: Datos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datos.ToListAsync());
        }

        // GET: Datos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos = await _context.Datos
                .FirstOrDefaultAsync(m => m.empresaID == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // GET: Datos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empresaID,nombreEmpresa,Direccion")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datos);
        }

        // GET: Datos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos = await _context.Datos.FindAsync(id);
            if (datos == null)
            {
                return NotFound();
            }
            return View(datos);
        }

        // POST: Datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empresaID,nombreEmpresa,Direccion")] Datos datos)
        {
            if (id != datos.empresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosExists(datos.empresaID))
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
            return View(datos);
        }

        // GET: Datos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos = await _context.Datos
                .FirstOrDefaultAsync(m => m.empresaID == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datos = await _context.Datos.FindAsync(id);
            _context.Datos.Remove(datos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosExists(int id)
        {
            return _context.Datos.Any(e => e.empresaID == id);
        }
    }
}
