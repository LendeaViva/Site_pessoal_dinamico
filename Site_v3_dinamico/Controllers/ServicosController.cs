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
    public class ServicosController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public ServicosController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicos.ToListAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.ServicosId == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        // GET: Servicos/Create
        [Authorize(Roles = "Administradora")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicosId,Nome,Descricao")] Servicos servicos, IFormFile ficheiroImagem)
        {
            if (ModelState.IsValid)
            {
                AtualizaImagem(servicos, ficheiroImagem);
                _context.Add(servicos);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Serviço adicionado com sucesso";
                return View("Sucesso");
            }

            return View(servicos);
        }

        private static void AtualizaImagem(Servicos servicos, IFormFile ficheiroImagem)
        {
            if (ficheiroImagem != null && ficheiroImagem.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    ficheiroImagem.CopyTo(ficheiroMemoria);
                    servicos.imagem = ficheiroMemoria.ToArray();
                }
            }
        }

        // GET: Servicos/Edit/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos.FindAsync(id);
            if (servicos == null)
            {
                return NotFound();
            }
            return View(servicos);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicosId,Nome,Descricao,imagem")] Servicos servicos, IFormFile ficheiroImagem)
        {
            if (id != servicos.ServicosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AtualizaImagem(servicos, ficheiroImagem);
                    _context.Update(servicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosExists(servicos.ServicosId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Serviço alterado com sucesso";
                return View("Sucesso");
            }
            return View(servicos);
        }

        // GET: Servicos/Delete/5
        [Authorize(Roles = "Administradora")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.ServicosId == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicos = await _context.Servicos.FindAsync(id);

            try
            {
                _context.Servicos.Remove(servicos);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (_context.Encomenda.Any(p => p.ServicosId == servicos.ServicosId))
                {
                    ViewBag.Mensagem = "Este serviço não pode ser apagado porque já tem encomendas associadas.";
                }
                else
                {
                    ViewBag.Mensagem = "Não foi possível eliminar o serviço. Tente novamente mais tarde e se o problema persistir contacte a assistência";
                }
                return View("Erro");
            }

            _context.Servicos.Remove(servicos);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "Serviço apagado com sucesso";
            return View("Sucesso");
        }


        private bool ServicosExists(int id)
        {
            return _context.Servicos.Any(e => e.ServicosId == id);
        }
    }
}
