﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Data;
using Site_v3_dinamico.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Site_v3_dinamico.Controllers
{
    [Authorize]
    public class FormacaoController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public FormacaoController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: Formacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Formacao.ToListAsync());
        }

        // GET: Formacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.FormacaoId == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: Formacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormacaoId,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudos")] Formacao formacao, IFormFile ficheiroLogotipoForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (ficheiroLogotipoForm != null && ficheiroLogotipoForm.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroLogotipoForm.CopyTo(ficheiroMemoria);
                    formacao.logotipoForm = ficheiroMemoria.ToArray();
                }
            }
            return View(formacao);
        }

        // GET: Formacao/Edit/5
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

        // POST: Formacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormacaoId,nomeInstituicao,dataIniciodataFim,nomeCurso,conteudos")] Formacao formacao)
        {
            if (id != formacao.FormacaoId)
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
                    if (!FormacaoExists(formacao.FormacaoId))
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

        // GET: Formacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacao
                .FirstOrDefaultAsync(m => m.FormacaoId == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: Formacao/Delete/5
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
            return _context.Formacao.Any(e => e.FormacaoId == id);
        }
    }
}
