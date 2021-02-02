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
    [Authorize(Roles ="Administradora, Cliente")]
    public class EncomendasController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public EncomendasController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: Encomendas
        //[Authorize (Roles="Administradora")]
        public async Task<IActionResult> Index(string sortOrder, int pagina = 1)
        {
            ViewData["OrdenaData"] = sortOrder == "data" ? "data_desc" : "data";
            ViewData["OrdenaCliente"] = sortOrder == "nome" ? "nome_desc" : "nome";
            ViewData["OrdenaServico"] = sortOrder == "servico" ? "servico_desc" : "servico";

            var encomenda = from s in _context.Encomenda
                             select s;
            switch (sortOrder)
            {
                case "data":
                    encomenda = encomenda.OrderBy(s => s.dataEncomenda);
                    break;
                case "data_desc":
                    encomenda = encomenda.OrderByDescending(s => s.dataEncomenda);
                    break;
                case "nome":
                    encomenda = encomenda.OrderBy(s => s.Cliente.Nome);
                    break;
                case "nome_desc":
                    encomenda = encomenda.OrderByDescending(s => s.Cliente.Nome);
                    break;
                case "servico":
                    encomenda = encomenda.OrderBy(s => s.Servicos);
                    break;
                case "servico_desc":
                    encomenda = encomenda.OrderByDescending(s => s.Servicos);
                    break;
                default:
                    encomenda = encomenda.OrderBy(p => p.respondido)
                    .ThenByDescending(p => p.dataEncomenda);
                    break;
            }

            //Contador de novas encomendas
            string conta = ContarNovas().ToString();
            ViewBag.Message = conta;

            //Paginacao
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Encomenda.CountAsync(),
                PaginaAtual = pagina
            };

            List<Encomenda> encomendas = await _context.Encomenda
                .Include(p => p.Servicos)
                .Include(p => p.Cliente)
                .OrderBy(p => p.respondido)
                .ThenByDescending(p => p.dataEncomenda)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaEncomendasViewModel modelo = new ListaEncomendasViewModel
            {
       
                Encomenda = encomendas,
                Paginacao = paginacao,

            };

           

            var siteDinamicoBdContext = _context.Encomenda.Include(e => e.Cliente).Include(e => e.Servicos);
            return base.View(modelo);
        }

        public int ContarNovas()
        {
            int count = 0;
            foreach (var item in _context.Encomenda.ToList())
            {
                //SystemsCount 
                count = _context.Encomenda.Where(x => x.respondido == false).Count();
            }
            return count;
        }
        

        // GET: Encomendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomenda = await _context.Encomenda.Include(p => p.Servicos)
                .SingleOrDefaultAsync(p => p.EncomendaId == id); 
            if (encomenda == null)
            {
                return NotFound();
            }

            return View(encomenda);
        }

        // GET: Encomendas/Create
        public IActionResult Create()
        {
            //ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email");
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([Bind("EncomendaId,dataEncomenda,ServicosId")] Encomenda encomenda)
        {

            if (ModelState.IsValid)
            {
                var cliente = _context.Cliente.SingleOrDefault(c => c.Email == User.Identity.Name);
                encomenda.Cliente = cliente;
                encomenda.dataEncomenda = DateTime.Now;
                _context.Add(encomenda);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Encomenda criada com sucesso";
                return View("Sucesso");
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Email", encomenda.ClienteId);
            ViewData["ServicosId"] = new SelectList(_context.Servicos, "ServicosId", "Nome", encomenda.ServicosId);
            return View(encomenda);
        }

        [Authorize(Roles = "Administradora")]
        // GET: Encomendas/Edit/5
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

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncomendaId,dataEncomenda,ClienteId,ServicosId, respondido")] Encomenda encomenda)
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

        [Authorize(Roles = "Administradora")]
        // GET: Encomendas/Delete/5
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

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomenda = await _context.Encomenda.FindAsync(id);
            _context.Encomenda.Remove(encomenda);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Encomenda apagada com sucesso";
            return View("Sucesso");
        }

        private bool EncomendaExists(int id)
        {
            return _context.Encomenda.Any(e => e.EncomendaId == id);
        }

        public int NumeroEncomendas()
        {
            int count = 0;
            foreach (var item in _context.Encomenda.ToList())
            {
                //SystemsCount 
                count = _context.Encomenda.Where(x => x.respondido == false).Count();
            }
            return count;
        }
    }
}
