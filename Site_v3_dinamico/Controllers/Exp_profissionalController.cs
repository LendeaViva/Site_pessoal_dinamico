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
    public class Exp_profissionalController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public Exp_profissionalController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: Exp_profissional
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exp_profissional.ToListAsync());
        }

        // GET: Exp_profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exp_profissional = await _context.Exp_profissional
                .FirstOrDefaultAsync(m => m.Exp_profissionalId == id);
            if (exp_profissional == null)
            {
                return NotFound();
            }

            return View(exp_profissional);
        }

        // GET: Exp_profissional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exp_profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Exp_profissionalId,nomeEmpresa,dataInicio,dataFim,funcao,descricaoFuncao")] Exp_profissional exp_profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exp_profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exp_profissional);
        }

        // GET: Exp_profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exp_profissional = await _context.Exp_profissional.FindAsync(id);
            if (exp_profissional == null)
            {
                return NotFound();
            }
            return View(exp_profissional);
        }

        // POST: Exp_profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Exp_profissionalId,nomeEmpresa,dataInicio,dataFim,funcao,descricaoFuncao")] Exp_profissional exp_profissional)
        {
            if (id != exp_profissional.Exp_profissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exp_profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exp_profissionalExists(exp_profissional.Exp_profissionalId))
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
            return View(exp_profissional);
        }

        // GET: Exp_profissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exp_profissional = await _context.Exp_profissional
                .FirstOrDefaultAsync(m => m.Exp_profissionalId == id);
            if (exp_profissional == null)
            {
                return NotFound();
            }

            return View(exp_profissional);
        }

        // POST: Exp_profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exp_profissional = await _context.Exp_profissional.FindAsync(id);
            _context.Exp_profissional.Remove(exp_profissional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exp_profissionalExists(int id)
        {
            return _context.Exp_profissional.Any(e => e.Exp_profissionalId == id);
        }
    }
}
