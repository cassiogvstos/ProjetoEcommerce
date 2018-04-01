using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesceUmaGeralada.Dados;
using DesceUmaGeralada.Models;

namespace DesceUmaGeralada.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly BeerContext _context;

        public ProdutoesController(BeerContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            var beerContext = _context.Produtos.Include(p => p.Cliente).Include(p => p.NotaFiscal);
            return View(await beerContext.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Cliente)
                .Include(p => p.NotaFiscal)
                .SingleOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "ID");
            ViewData["NotaFiscalID"] = new SelectList(_context.NotasFiscais, "NotaFiscalID", "NotaFiscalID");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoID,NotaFiscalID,ClienteID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "ID", produto.ClienteID);
            ViewData["NotaFiscalID"] = new SelectList(_context.NotasFiscais, "NotaFiscalID", "NotaFiscalID", produto.NotaFiscalID);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.SingleOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "ID", produto.ClienteID);
            ViewData["NotaFiscalID"] = new SelectList(_context.NotasFiscais, "NotaFiscalID", "NotaFiscalID", produto.NotaFiscalID);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoID,NotaFiscalID,ClienteID")] Produto produto)
        {
            if (id != produto.ProdutoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoID))
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
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ID", "ID", produto.ClienteID);
            ViewData["NotaFiscalID"] = new SelectList(_context.NotasFiscais, "NotaFiscalID", "NotaFiscalID", produto.NotaFiscalID);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Cliente)
                .Include(p => p.NotaFiscal)
                .SingleOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(m => m.ProdutoID == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoID == id);
        }
    }
}
