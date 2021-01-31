using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Data;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Controllers
{
    public class CompetenciasFController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public CompetenciasFController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: CompetenciasF
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompetenciasF.ToListAsync());
        }

        // GET: CompetenciasF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasF = await _context.CompetenciasF
                .FirstOrDefaultAsync(m => m.CompetenciasFId == id);
            if (competenciasF == null)
            {
                return NotFound();
            }

            return View(competenciasF);
        }

        // GET: CompetenciasF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetenciasF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasFId,nomeComp,nivelComp,logo")] CompetenciasF competenciasF)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenciasF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competenciasF);
        }

        // GET: CompetenciasF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasF = await _context.CompetenciasF.FindAsync(id);
            if (competenciasF == null)
            {
                return NotFound();
            }
            return View(competenciasF);
        }

        // POST: CompetenciasF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasFId,nomeComp,nivelComp,logo")] CompetenciasF competenciasF)
        {
            if (id != competenciasF.CompetenciasFId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenciasF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasFExists(competenciasF.CompetenciasFId))
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
            return View(competenciasF);
        }

        // GET: CompetenciasF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasF = await _context.CompetenciasF
                .FirstOrDefaultAsync(m => m.CompetenciasFId == id);
            if (competenciasF == null)
            {
                return NotFound();
            }

            return View(competenciasF);
        }

        // POST: CompetenciasF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenciasF = await _context.CompetenciasF.FindAsync(id);
            _context.CompetenciasF.Remove(competenciasF);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasFExists(int id)
        {
            return _context.CompetenciasF.Any(e => e.CompetenciasFId == id);
        }
    }
}
