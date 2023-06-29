using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CooperativaMVC.Data;
using CooperativaMVC.Models;

namespace CooperativaMVC.Controllers
{
    public class AssociadosController : Controller
    {
        private readonly BancoDeDados _context;

        public AssociadosController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Associados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Associados.ToListAsync());
        }

        // GET: Associados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // GET: Associados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,SalarioMensal,ValorEmprestado,MargemConsignada")] Associado associado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associado);
        }

        // GET: Associados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados.FindAsync(id);
            if (associado == null)
            {
                return NotFound();
            }
            return View(associado);
        }

        // POST: Associados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,SalarioMensal,ValorEmprestado,MargemConsignada")] Associado associado)
        {
            if (id != associado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociadoExists(associado.Id))
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
            return View(associado);
        }

        // GET: Associados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // POST: Associados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associado = await _context.Associados.FindAsync(id);
            _context.Associados.Remove(associado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociadoExists(int id)
        {
            return _context.Associados.Any(e => e.Id == id);
        }
    }
}
