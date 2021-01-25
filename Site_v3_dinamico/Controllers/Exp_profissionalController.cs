using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Data;
using Site_v3_dinamico.Models;

namespace SitePessoalDinamico.Controllers
{
    public class Exp_ProfissionalController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public Exp_ProfissionalController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: Exp_Profissional
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exp_Profissional.ToListAsync());
        }

        // GET: Exp_Profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Exp_Profissional = await _context.Exp_Profissional
                .FirstOrDefaultAsync(m => m.Exp_ProfissionalId == id);
            if (Exp_Profissional == null)
            {
                return NotFound();
            }

            return View(Exp_Profissional);
        }

        // GET: Exp_Profissional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exp_Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Exp_ProfissionalId,nomeEmpresa,dataInicio,dataFim,funcao,descricaoFuncao")] Exp_Profissional Exp_Profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Exp_Profissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Exp_Profissional);
        }

        // GET: Exp_Profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Exp_Profissional = await _context.Exp_Profissional.FindAsync(id);
            if (Exp_Profissional == null)
            {
                return NotFound();
            }
            return View(Exp_Profissional);
        }

        // POST: Exp_Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Exp_ProfissionalId,nomeEmpresa,dataInicio,dataFim,funcao,descricaoFuncao")] Exp_Profissional Exp_Profissional)
        {
            if (id != Exp_Profissional.Exp_ProfissionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Exp_Profissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exp_ProfissionalExists(Exp_Profissional.Exp_ProfissionalId))
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
            return View(Exp_Profissional);
        }

        // GET: Exp_Profissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Exp_Profissional = await _context.Exp_Profissional
                .FirstOrDefaultAsync(m => m.Exp_ProfissionalId == id);
            if (Exp_Profissional == null)
            {
                return NotFound();
            }

            return View(Exp_Profissional);
        }

        // POST: Exp_Profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Exp_Profissional = await _context.Exp_Profissional.FindAsync(id);
            _context.Exp_Profissional.Remove(Exp_Profissional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exp_ProfissionalExists(int id)
        {
            return _context.Exp_Profissional.Any(e => e.Exp_ProfissionalId == id);
        }
    }
}
