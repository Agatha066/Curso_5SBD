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
    public class BemDuravelsController : Controller
    {
        private readonly BancoDeDados _context;

        public BemDuravelsController(BancoDeDados context)
        {
            _context = context;
        }

        // GET: BemDuravels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bens.ToListAsync());
        }

        // GET: BemDuravels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bemDuravel = await _context.Bens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bemDuravel == null)
            {
                return NotFound();
            }

            return View(bemDuravel);
        }

        // GET: BemDuravels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BemDuravels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valor")] BemDuravel bemDuravel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bemDuravel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bemDuravel);
        }

        // GET: BemDuravels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bemDuravel = await _context.Bens.FindAsync(id);
            if (bemDuravel == null)
            {
                return NotFound();
            }
            return View(bemDuravel);
        }

        // POST: BemDuravels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valor")] BemDuravel bemDuravel)
        {
            if (id != bemDuravel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bemDuravel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BemDuravelExists(bemDuravel.Id))
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
            return View(bemDuravel);
        }

        // GET: BemDuravels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bemDuravel = await _context.Bens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bemDuravel == null)
            {
                return NotFound();
            }

            return View(bemDuravel);
        }

        // POST: BemDuravels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bemDuravel = await _context.Bens.FindAsync(id);
            _context.Bens.Remove(bemDuravel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BemDuravelExists(int id)
        {
            return _context.Bens.Any(e => e.Id == id);
        }
    }
}
