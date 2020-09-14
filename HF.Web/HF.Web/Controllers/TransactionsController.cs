using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HF.Web.Data;
using HF.Web.Models;

namespace HF.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly HFWebContext _context;

        public TransactionsController(HFWebContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var model = await _context.Transaction.ToListAsync();
            var fullModel = model.Select(s => new Transaction
            {
                Id = s.Id,
                Amount = s.Amount,
                OperationDateTime = s.OperationDateTime,
                Category = _context.Category.Where(w=>w.Id==s.CategoryId).Select(k=>k).FirstOrDefault(),
                Currency = _context.Currency.Where(w=>w.Id==s.CurrencyId).Select(k=>k).FirstOrDefault(),
                Operation = _context.Operation.Where(w=>w.Id==s.OperationId).Select(k=>k).FirstOrDefault(),
                Unit = _context.Unit.Where(w=>w.Id==s.UnitId).Select(k=>k).FirstOrDefault()
            }).ToList();
            
            return View(fullModel);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,OperationDateTime")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            var operations = new SelectList(_context.Operation, "Id", "Name", transaction.OperationId);
            ViewBag.Operations = operations;
            
            var categories = new SelectList(_context.Category, "Id", "Name", transaction.CategoryId);
            ViewBag.Categories = categories;
            
            var currencies = new SelectList(_context.Currency, "Id", "Name", transaction.CurrencyId);
            ViewBag.Currencies = currencies;
            
            var units = new SelectList(_context.Unit, "Id", "Name", transaction.UnitId);
            ViewBag.Units = units;
            
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
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
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.Id == id);
        }
    }
}
