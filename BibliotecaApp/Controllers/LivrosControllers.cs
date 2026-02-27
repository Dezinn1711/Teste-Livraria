using Microsoft.AspNetCore.Mvc;
using BibliotecaApp.Data;
using BibliotecaApp.Models;
using System.Linq;

namespace BibliotecaApp.Controllers
{
    public class LivrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LivrosController(BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
                return NotFound();

            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

