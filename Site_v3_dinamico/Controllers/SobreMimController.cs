using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Data;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Controllers
{
    public class SobreMimController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public SobreMimController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: SobreMim
        public async Task<IActionResult> Index()
        {
            List<SobreMim> sobremim = await _context.SobreMim.ToListAsync();
            List<SobreMimImg> sobreMimImg = await _context.SobreMimImg.ToListAsync();

            SobreMimViewModel modelo = new SobreMimViewModel
            {

                SobreMim = sobremim,
                SobreMimImg = sobreMimImg,

            };

            return base.View(modelo);
        }

        [Authorize(Roles = "Administradora")]
        // GET: SobreMim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMim = await _context.SobreMim
                .FirstOrDefaultAsync(m => m.SobreMimId == id);
            if (sobreMim == null)
            {
                return NotFound();
            }

            return View(sobreMim);
        }

        [Authorize(Roles = "Administradora")]
        // GET: SobreMim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SobreMim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SobreMimId,descricao")] SobreMim sobreMim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sobreMim);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Sobre mim adicionado com sucesso";
                return View("Sucesso");
            }
            return View(sobreMim);
        }

        // GET: SobreMim/Edit/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMim = await _context.SobreMim.FindAsync(id);
            if (sobreMim == null)
            {
                return NotFound();
            }
            return View(sobreMim);
        }

        // POST: SobreMim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SobreMimId,descricao")] SobreMim sobreMim)
        {
            if (id != sobreMim.SobreMimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sobreMim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobreMimExists(sobreMim.SobreMimId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Sobre mim alterado com sucesso";
                return View("Sucesso");
            }
            return View(sobreMim);
        }

        // GET: SobreMim/Delete/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobreMim = await _context.SobreMim
                .FirstOrDefaultAsync(m => m.SobreMimId == id);
            if (sobreMim == null)
            {
                return NotFound();
            }

            return View(sobreMim);
        }

        // POST: SobreMim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sobreMim = await _context.SobreMim.FindAsync(id);
            _context.SobreMim.Remove(sobreMim);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Sobre mim removido com sucesso";
            return View("Sucesso");
        }

        private bool SobreMimExists(int id)
        {
            return _context.SobreMim.Any(e => e.SobreMimId == id);
        }
    }
}
