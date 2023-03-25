﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicaMVC.Models;

namespace practicaMVC.Controllers
{
    public class Tipo_equipoController : Controller
    {
        private readonly equipoDbContext _context;

        public Tipo_equipoController(equipoDbContext context)
        {
            _context = context;
        }

        // GET: Tipo_equipo
        public async Task<IActionResult> Index()
        {
              return _context.tipo_Equipos != null ? 
                          View(await _context.tipo_Equipos.ToListAsync()) :
                          Problem("Entity set 'equipoDbContext.tipo_Equipos'  is null.");
        }

        // GET: Tipo_equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipo_Equipos == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_Equipos
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }

            return View(tipo_equipo);
        }

        // GET: Tipo_equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo_equipo,descripcion,estado")] tipo_equipo tipo_equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_equipo);
        }

        // GET: Tipo_equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipo_Equipos == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_Equipos.FindAsync(id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }
            return View(tipo_equipo);
        }

        // POST: Tipo_equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id_tipo_equipo,descripcion,estado")] tipo_equipo tipo_equipo)
        {
            if (id != tipo_equipo.id_tipo_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tipo_equipoExists(tipo_equipo.id_tipo_equipo))
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
            return View(tipo_equipo);
        }

        // GET: Tipo_equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipo_Equipos == null)
            {
                return NotFound();
            }

            var tipo_equipo = await _context.tipo_Equipos
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_equipo == null)
            {
                return NotFound();
            }

            return View(tipo_equipo);
        }

        // POST: Tipo_equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.tipo_Equipos == null)
            {
                return Problem("Entity set 'equipoDbContext.tipo_Equipos'  is null.");
            }
            var tipo_equipo = await _context.tipo_Equipos.FindAsync(id);
            if (tipo_equipo != null)
            {
                _context.tipo_Equipos.Remove(tipo_equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tipo_equipoExists(int? id)
        {
          return (_context.tipo_Equipos?.Any(e => e.id_tipo_equipo == id)).GetValueOrDefault();
        }
    }
}
