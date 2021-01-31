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
    public class CompetenciasDController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public CompetenciasDController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: CompetenciasD
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompetenciasD.ToListAsync());
        }

        // GET: CompetenciasD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasD = await _context.CompetenciasD
                .FirstOrDefaultAsync(m => m.CompetenciasDId == id);
            if (competenciasD == null)
            {
                return NotFound();
            }

            return View(competenciasD);
        }

        // GET: CompetenciasD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetenciasD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasDId,nomeComp,nivelComp")] CompetenciasD competenciasD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competenciasD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competenciasD);
        }

        // GET: CompetenciasD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasD = await _context.CompetenciasD.FindAsync(id);
            if (competenciasD == null)
            {
                return NotFound();
            }
            return View(competenciasD);
        }

        // POST: CompetenciasD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasDId,nomeComp,nivelComp")] CompetenciasD competenciasD)
        {
            if (id != competenciasD.CompetenciasDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competenciasD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasDExists(competenciasD.CompetenciasDId))
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
            return View(competenciasD);
        }

        // GET: CompetenciasD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasD = await _context.CompetenciasD
                .FirstOrDefaultAsync(m => m.CompetenciasDId == id);
            if (competenciasD == null)
            {
                return NotFound();
            }

            return View(competenciasD);
        }

        // POST: CompetenciasD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenciasD = await _context.CompetenciasD.FindAsync(id);
            _context.CompetenciasD.Remove(competenciasD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasDExists(int id)
        {
            return _context.CompetenciasD.Any(e => e.CompetenciasDId == id);
        }
    }
}
