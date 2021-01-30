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
    public class EncomendasTempController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public EncomendasTempController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: EncomendasTemp
        public async Task<IActionResult> Index()
        {
            var siteDinamicoBdContext = _context.Encomenda.Include(e => e.Cliente).Include(e => e.Servicos);
            return View(await siteDinamicoBdContext.ToListAsync());
        }

        // GET: EncomendasTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda
                .Include(e => e.Cliente)
                .Include(e => e.Servicos)
                .FirstOrDefaultAsync(m => m.EncomendaId == id);
            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // GET: EncomendasTemp/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email");
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome");
            return View();
        }

        // POST: EncomendasTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EncomendaId,dataEncomenda,detalhes,respondido,ClienteId,ServicosId")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", encomenda.ClienteId);
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome", encomenda.ServicosId);
            return View(encomenda);
        }

        // GET: EncomendasTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda.FindAsync(id);
            if (encomenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", encomenda.ClienteId);
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome", encomenda.ServicosId);
            return View(encomenda);
        }

        // POST: EncomendasTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncomendaId,dataEncomenda,detalhes,respondido,ClienteId,ServicosId")] Encomenda encomenda)
        {
            if (id != encomenda.EncomendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomendaExists(encomenda.EncomendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", encomenda.ClienteId);
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome", encomenda.ServicosId);
            return View(encomenda);
        }

        // GET: EncomendasTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda
                .Include(e => e.Cliente)
                .Include(e => e.Servicos)
                .FirstOrDefaultAsync(m => m.EncomendaId == id);
            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // POST: EncomendasTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomenda = await _context.Encomenda.FindAsync(id);
            _context.Encomenda.Remove(encomenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncomendaExists(int id)
        {
            return _context.Encomenda.Any(e => e.EncomendaId == id);
        }
    }
}
