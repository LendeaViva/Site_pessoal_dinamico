using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Data;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Controllers
{
    public class SobreMimImgController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public SobreMimImgController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: SobreMimImg
        public async Task<IActionResult> Index()
        {
            return View(await _context.SobreMimImg.ToListAsync());
        }

        // GET: SobreMimImg/Details/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMimImg = await _context.SobreMimImg
                .FirstOrDefaultAsync(m => m.SobreMimImgId == id);
            if (sobreMimImg == null)
            {
                return NotFound();
            }

            return View(sobreMimImg);
        }

        // GET: SobreMimImg/Create
        [Authorize(Roles = "Administradora")]
        public IActionResult Create()
        {

            return View();
        }

        

        // POST: SobreMimImg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SobreMimImgId,imagem")] SobreMimImg sobreMimImg, IFormFile ficheiroImagem)
        {
            if (ModelState.IsValid)
            {
                AtualizaImagem(sobreMimImg, ficheiroImagem);
                _context.Add(sobreMimImg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            _context.Add(sobreMimImg);
            await _context.SaveChangesAsync();
            return View(sobreMimImg);
        }

        private static void AtualizaImagem(SobreMimImg sobreMimImg, IFormFile ficheiroImagem)
        {
            if (ficheiroImagem != null && ficheiroImagem.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroImagem.CopyTo(ficheiroMemoria);
                    sobreMimImg.imagem = ficheiroMemoria.ToArray();
                }
            }
        }

        // GET: SobreMimImg/Edit/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMimImg = await _context.SobreMimImg.FindAsync(id);
            if (sobreMimImg == null)
            {
                return NotFound();
            }
            return View(sobreMimImg);
        }

        // POST: SobreMimImg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SobreMimImgId,imagem")] SobreMimImg sobreMimImg, IFormFile ficheiroImagem)
        {
            if (id != sobreMimImg.SobreMimImgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaImagem(sobreMimImg, ficheiroImagem);
                    _context.Update(sobreMimImg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobreMimImgExists(sobreMimImg.SobreMimImgId))
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
            return View(sobreMimImg);
        }

        // GET: SobreMimImg/Delete/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMimImg = await _context.SobreMimImg
                .FirstOrDefaultAsync(m => m.SobreMimImgId == id);
            if (sobreMimImg == null)
            {
                return NotFound();
            }

            return View(sobreMimImg);
        }

        // POST: SobreMimImg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sobreMimImg = await _context.SobreMimImg.FindAsync(id);
            _context.SobreMimImg.Remove(sobreMimImg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobreMimImgExists(int id)
        {
            return _context.SobreMimImg.Any(e => e.SobreMimImgId == id);
        }
    }
}
