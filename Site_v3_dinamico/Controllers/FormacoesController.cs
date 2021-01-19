using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Formacao1.Data;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Controllers
{
    public class FormacoesController : Controller
    {
        private readonly FormacaoBdContext _context;

        public FormacoesController(FormacaoBdContext context)
        {
            _context = context;
        }

        // GET: Formacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Formacao.ToListAsync());
        }

        // GET: Formacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: Formacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudosCurso")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formacao);
        }

        // GET: Formacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao.FindAsync(id);
            if (formacao == null)
            {
                return NotFound();
            }
            return View(formacao);
        }

        // POST: Formacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudosCurso")] Formacao formacao)
        {
            if (id != formacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoExists(formacao.Id))
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
            return View(formacao);
        }

        // GET: Formacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: Formacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formacao = await _context.Formacao.FindAsync(id);
            _context.Formacao.Remove(formacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(int id)
        {
            return _context.Formacao.Any(e => e.Id == id);
        }
    }
}
