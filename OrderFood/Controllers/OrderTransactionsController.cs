using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderFood.Models;

namespace OrderFood.Controllers
{
    public class OrderTransactionsController : Controller
    {
        private readonly OrderFoodDbContext _context;

        public OrderTransactionsController(OrderFoodDbContext context)
        {
            _context = context;
        }

        // GET: OrderTransactions
        public async Task<IActionResult> Index()
        {
              return _context.OrderTrx != null ? 
                          View(await _context.OrderTrx.ToListAsync()) :
                          Problem("Entity set 'OrderFoodDbContext.OrderTrx'  is null.");
        }

        // GET: OrderTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderTrx == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTrx
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderTransaction == null)
            {
                return NotFound();
            }

            return View(orderTransaction);
        }

        // GET: OrderTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodId,Qty,SubTotalPrice")] OrderTransaction orderTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderTransaction);
        }

        // GET: OrderTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderTrx == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTrx.FindAsync(id);
            if (orderTransaction == null)
            {
                return NotFound();
            }
            return View(orderTransaction);
        }

        // POST: OrderTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodId,Qty,SubTotalPrice")] OrderTransaction orderTransaction)
        {
            if (id != orderTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTransactionExists(orderTransaction.Id))
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
            return View(orderTransaction);
        }

        // GET: OrderTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderTrx == null)
            {
                return NotFound();
            }

            var orderTransaction = await _context.OrderTrx
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderTransaction == null)
            {
                return NotFound();
            }

            return View(orderTransaction);
        }

        // POST: OrderTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderTrx == null)
            {
                return Problem("Entity set 'OrderFoodDbContext.OrderTrx'  is null.");
            }
            var orderTransaction = await _context.OrderTrx.FindAsync(id);
            if (orderTransaction != null)
            {
                _context.OrderTrx.Remove(orderTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTransactionExists(int id)
        {
          return (_context.OrderTrx?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
