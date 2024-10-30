using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_final_prowebII.Data;
using Proyecto_final_prowebII.Models;

namespace Proyecto_final_prowebII.Controllers
{
    [Authorize]
    public class ItemPedidoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemPedidoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemPedidoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemPedido.Include(i => i.Pedido).Include(i => i.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido
                .Include(i => i.Pedido)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.ItemPedidoId == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // GET: ItemPedidoes/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "NombreProducto");
            return View();
        }

        // POST: ItemPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemPedidoId,PedidoId,ProductoId,Cantidad,Precio,Descuento")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "NombreProducto", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "NombreProducto", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemPedidoId,PedidoId,ProductoId,Cantidad,Precio,Descuento")] ItemPedido itemPedido)
        {
            if (id != itemPedido.ItemPedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPedidoExists(itemPedido.ItemPedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "ProductoId", "NombreProducto", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItemPedido
                .Include(i => i.Pedido)
                .Include(i => i.Producto)
                .FirstOrDefaultAsync(m => m.ItemPedidoId == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // POST: ItemPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido != null)
            {
                _context.ItemPedido.Remove(itemPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItemPedido.Any(e => e.ItemPedidoId == id);
        }
    }
}
