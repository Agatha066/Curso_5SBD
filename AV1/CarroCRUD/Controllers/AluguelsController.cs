using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarroCRUD.Models;

namespace CarroCRUD.Controllers
{
    public class AluguelsController : Controller
    {
        private readonly BancoDeDados _context;

        public AluguelsController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: Aluguels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alugueis.ToListAsync());
        }

        // GET: Aluguels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // GET: Aluguels/Create
        public IActionResult Create()
        {
            var carrosDisponiveis = _context.Carros.Where(c => c.Disponibilidade == true).ToList();
            ViewBag.Carros = carrosDisponiveis;

            var clientes = _context.Clientes.ToList();
            ViewBag.Clientes = clientes;

            var precosCarros = _context.Carros.ToDictionary(c => c.Id, c => c.Preco);
            ViewBag.ValorTotal = precosCarros;
            

            return View();
        }

        public IActionResult ObterValor(int carroId)
        {
            var valor = _context.Carros.FirstOrDefault(c => c.Id == carroId)?.Preco;
            return Json(valor);
        }

        // POST: Aluguels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCarro,IdCliente,DataAluguel,DateReturno,ValorTotal")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(aluguel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
                var carro = _context.Carros.FirstOrDefault(c => c.Id == aluguel.IdCarro);
                if (carro != null)
                {
                    carro.Disponibilidade = false;
                    _context.SaveChanges();
                }
                //return RedirectToAction("Pagamentos");
                return RedirectToAction("Create", "Pagamentos", new { valorAluguel = aluguel.ValorTotal });


            }
            return View(aluguel);
        }

        // GET: Aluguels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            return View(aluguel);
        }

        // POST: Aluguels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCarro,IdCliente,DataAluguel,DateReturno,ValorTotal")] Aluguel aluguel)
        {
            if (id != aluguel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelExists(aluguel.Id))
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
            return View(aluguel);
        }

        // GET: Aluguels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // POST: Aluguels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);
            _context.Alugueis.Remove(aluguel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguelExists(int id)
        {
            return _context.Alugueis.Any(e => e.Id == id);
        }
    }
}
