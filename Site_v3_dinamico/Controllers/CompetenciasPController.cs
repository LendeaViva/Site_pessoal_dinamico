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
    public class CompetenciasPController : Controller
    {
        private readonly SiteDinamicoBdContext _context;

        public CompetenciasPController(SiteDinamicoBdContext context)
        {
            _context = context;
        }

        // GET: CompetenciasP
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competencias.ToListAsync());
        }

        [Authorize(Roles = "Administradora")]
        // GET: CompetenciasP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasP = await _context.Competencias
                .FirstOrDefaultAsync(m => m.CompetenciasPId == id);
            if (competenciasP == null)
            {
                return View("Inexistente");
            }

            return View(competenciasP);
        }

        [Authorize(Roles = "Administradora")]
        // GET: CompetenciasP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetenciasP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasPId,nomeComp,descricaoComp")] CompetenciasP competenciasP)
        {
            if (!ModelState.IsValid)
            {

                return View(competenciasP);
            }

           
            _context.Add(competenciasP);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Competência adicionada com sucesso";
            return View("Sucesso");
        }

        [Authorize(Roles = "Administradora")]
        // GET: CompetenciasP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasP = await _context.Competencias.FindAsync(id);
            if (competenciasP == null)
            {
                return NotFound();
            }
            return View(competenciasP);
        }

        // POST: CompetenciasP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasPId,nomeComp,descricaoComp")] CompetenciasP competenciasP)
        {
            if (id != competenciasP.CompetenciasPId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {

                return View(competenciasP);
            }

            try
            {
               
                _context.Update(competenciasP);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenciasPExists(competenciasP.CompetenciasPId))
                {
                    return View("EliminarInserir", competenciasP);
                }
                else
                {
                    ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar a competência. Tente novamente e se o problema persistir contacte a assistência.");
                    return View(competenciasP);
                }
            }

            ViewBag.Mensagem = "Competência alterada com sucesso";
            return View("Sucesso");
        }

        [Authorize(Roles = "Administradora")]
        // GET: CompetenciasP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competenciasP = await _context.Competencias
                .FirstOrDefaultAsync(m => m.CompetenciasPId == id);
            if (competenciasP == null)
            {
                return NotFound();
            }

            return View(competenciasP);
        }

        // POST: CompetenciasP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competenciasP = await _context.Competencias.FindAsync(id);
            _context.Competencias.Remove(competenciasP);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "A competência foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool CompetenciasPExists(int id)
        {
            return _context.Competencias.Any(e => e.CompetenciasPId == id);
        }
    }
}
