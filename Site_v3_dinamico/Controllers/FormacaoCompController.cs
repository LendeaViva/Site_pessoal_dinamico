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
    public class FormacaoCompController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public FormacaoCompController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: FormacaoComp
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormacaoComp.ToListAsync());
        }

        // GET: FormacaoComp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoComp = await _context.FormacaoComp
                .FirstOrDefaultAsync(m => m.FormacaoCompId == id);
            if (formacaoComp == null)
            {
                return NotFound();
            }

            return View(formacaoComp);
        }

        // GET: FormacaoComp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormacaoComp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormacaoCompId,nomeInstituicaoComp,dataIniciodataFimComp,nomeCursoComp")] FormacaoComp formacaoComp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacaoComp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formacaoComp);
        }

        // GET: FormacaoComp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoComp = await _context.FormacaoComp.FindAsync(id);
            if (formacaoComp == null)
            {
                return NotFound();
            }
            return View(formacaoComp);
        }

        // POST: FormacaoComp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormacaoCompId,nomeInstituicaoComp,dataIniciodataFimComp,nomeCursoComp")] FormacaoComp formacaoComp)
        {
            if (id != formacaoComp.FormacaoCompId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacaoComp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoCompExists(formacaoComp.FormacaoCompId))
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
            return View(formacaoComp);
        }

        // GET: FormacaoComp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacaoComp = await _context.FormacaoComp
                .FirstOrDefaultAsync(m => m.FormacaoCompId == id);
            if (formacaoComp == null)
            {
                return NotFound();
            }

            return View(formacaoComp);
        }

        // POST: FormacaoComp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formacaoComp = await _context.FormacaoComp.FindAsync(id);
            _context.FormacaoComp.Remove(formacaoComp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoCompExists(int id)
        {
            return _context.FormacaoComp.Any(e => e.FormacaoCompId == id);
        }
    }
}
