using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020MS650_2020PM601_2020LM650.Models;

namespace P2_2020MS650_2020PM601_2020LM650.Controllers
{
    public class generoesController : Controller
    {
        private readonly registro_covidDbContext _context;

        public generoesController(registro_covidDbContext context)
        {
            _context = context;
        }

        // GET: generoes
        public async Task<IActionResult> Index()
        {
              return _context.genero != null ? 
                          View(await _context.genero.ToListAsync()) :
                          Problem("Entity set 'registro_covidDbContext.genero'  is null.");
        }

        // GET: generoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero
                .FirstOrDefaultAsync(m => m.id_genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: generoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: generoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_genero,nombregenero")] genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: generoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: generoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_genero,nombregenero")] genero genero)
        {
            if (id != genero.id_genero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!generoExists(genero.id_genero))
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
            return View(genero);
        }

        // GET: generoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero
                .FirstOrDefaultAsync(m => m.id_genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: generoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.genero == null)
            {
                return Problem("Entity set 'registro_covidDbContext.genero'  is null.");
            }
            var genero = await _context.genero.FindAsync(id);
            if (genero != null)
            {
                _context.genero.Remove(genero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool generoExists(int id)
        {
          return (_context.genero?.Any(e => e.id_genero == id)).GetValueOrDefault();
        }
    }
}
