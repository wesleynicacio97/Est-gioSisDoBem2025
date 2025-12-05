using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisDoBem.Data;
using SisDoBem.Models;
using SisDoBem.Models.Enums;

namespace SisDoBem.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Usuarios
        public async Task<IActionResult> Index(string? tipo)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
            {
                if (Enum.TryParse<TipoDeUsuario>(tipo, out var tipoEnum))
                {
                    query = query.Where(u => u.TipoDeUsuario == tipoEnum);
                }
            }

            return View(await query.ToListAsync());
        }



        // ==== LISTA DE DOADORES ====
        public async Task<IActionResult> Doadores()
        {
            var lista = await _context.Usuarios
                .Where(u => u.TipoDeUsuario == TipoDeUsuario.DoadorCpf
                         || u.TipoDeUsuario == TipoDeUsuario.DoadorCnpj)
                .ToListAsync();

            return View("Index", lista); // usa a mesma View Index
        }


        // ==== LISTA DE DONATÁRIOS ====
        public async Task<IActionResult> Donatarios()
        {
            var lista = await _context.Usuarios
                .Where(u => u.TipoDeUsuario == TipoDeUsuario.Donatario)
                .ToListAsync();

            return View("Index", lista);
        }


        // ==== LISTA DE VOLUNTÁRIOS ====
        public async Task<IActionResult> Voluntarios()
        {
            var lista = await _context.Usuarios
                .Where(u => u.TipoDeUsuario == TipoDeUsuario.Voluntario)
                .ToListAsync();

            return View("Index", lista);
        }



        // ==== DETALHES ====
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }


        // ==== CADASTRAR ====
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataDeCadastro = DateTime.Now;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }


        // ==== EDITAR ====
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }



        // ==== DELETAR ====
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);

            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
                _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
