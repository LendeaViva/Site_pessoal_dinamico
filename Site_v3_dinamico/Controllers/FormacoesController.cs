using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SitePessoal.Data;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Controllers
{
    public class FormacoesController : Controller
    {
        private readonly SitePessoalBdContext bd;

        public FormacoesController(SitePessoalBdContext context)
        {
            bd = context;
        }

        // GET: Formacoes
        public async Task<IActionResult> Index()
        {
            return View(await bd.Formacao.ToListAsync());
        }

        // GET: Formacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await bd.Formacao
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
        public async Task<IActionResult> Create([Bind("Id,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudosCurso")] Models.SitePessoal formacao)
        {
            if (!ModelState.IsValid)
            {
                return View(formacao);
            }


            bd.Add(formacao);
            await bd.SaveChangesAsync();

            return View();
        }

        // GET: Formacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await bd.Formacao.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudosCurso")] Models.SitePessoal formacao)
        {
            if (id != formacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(formacao);
                    await bd.SaveChangesAsync();
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

            var formacao = await bd.Formacao
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
            var formacao = await bd.Formacao.FindAsync(id);
            bd.Formacao.Remove(formacao);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(int id)
        {
            return bd.Formacao.Any(e => e.Id == id);
        }
    }
}
