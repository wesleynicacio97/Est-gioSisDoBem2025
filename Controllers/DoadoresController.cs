using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisDoBem.Data;
using SisDoBem.Models;

namespace SisDoBem.Controllers
{
    public class DoadoresController : Controller
    {
        private readonly AppDbContext _context;

        public DoadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Doadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doador.ToListAsync());
        }

        // GET: Doadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // GET: Doadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Endereco")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doador);
        }

        // GET: Doadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador.FindAsync(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        // POST: Doadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,Endereco")] Doador doador)
        {
            if (id != doador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorExists(doador.Id))
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
            return View(doador);
        }

        // GET: Doadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // POST: Doadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doador = await _context.Doador.FindAsync(id);
            if (doador != null)
            {
                _context.Doador.Remove(doador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(int id)
        {
            return _context.Doador.Any(e => e.Id == id);
        }
    }
}
