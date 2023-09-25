using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MVC_CRUDContext _context;

        public UsuarioController(MVC_CRUDContext context)
        {
            _context = context;
        }

        // GET: Usuário
        public async Task<IActionResult> Index()
        {
              return _context.UsuárioModel != null ? 
                          View(await _context.UsuárioModel.ToListAsync()) :
                          Problem("Entity set 'MVC_CRUDContext.UsuárioModel'  is null.");
        }

        // GET: Usuário/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuárioModel == null)
            {
                return NotFound();
            }

            var usuárioModel = await _context.UsuárioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuárioModel == null)
            {
                return NotFound();
            }

            return View(usuárioModel);
        }

        // GET: Usuário/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuário/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Administrador,Ativo,DataDoCadastro,UltimoAcesso")] UsuarioModel usuárioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuárioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuárioModel);
        }

        // GET: Usuário/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuárioModel == null)
            {
                return NotFound();
            }

            var usuárioModel = await _context.UsuárioModel.FindAsync(id);
            if (usuárioModel == null)
            {
                return NotFound();
            }
            return View(usuárioModel);
        }

        // POST: Usuário/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Administrador,Ativo,DataDoCadastro,UltimoAcesso")] UsuarioModel usuárioModel)
        {
            if (id != usuárioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuárioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuárioModelExists(usuárioModel.Id))
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
            return View(usuárioModel);
        }

        // GET: Usuário/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuárioModel == null)
            {
                return NotFound();
            }

            var usuárioModel = await _context.UsuárioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuárioModel == null)
            {
                return NotFound();
            }

            return View(usuárioModel);
        }

        // POST: Usuário/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuárioModel == null)
            {
                return Problem("Entity set 'MVC_CRUDContext.UsuárioModel'  is null.");
            }
            var usuárioModel = await _context.UsuárioModel.FindAsync(id);
            if (usuárioModel != null)
            {
                _context.UsuárioModel.Remove(usuárioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuárioModelExists(int id)
        {
          return (_context.UsuárioModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
