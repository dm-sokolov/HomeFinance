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
    public class NewTransactionsController : Controller
    {
        private readonly HFWebContext _context;

        public NewTransactionsController(HFWebContext context)
        {
            _context = context;
        }

        // GET: NewTransactions
        public async Task<IActionResult> Index()
        {
            var hFWebContext = _context.Transaction
                .Include(t => t.Contractor)
                .Include(t => t.Currency)
                .Include(t => t.Operation)
                .Include(t => t.Recipient)
                .Include(t => t.Unit);
            return View(await hFWebContext.ToListAsync());
        }

        // GET: NewTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Contractor)
                .Include(t => t.Currency)
                .Include(t => t.Operation)
                .Include(t => t.Recipient)
                .Include(t => t.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: NewTransactions/Create
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractor, "Id", "Name");
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name");
            ViewData["OperationId"] = new SelectList(_context.Operation, "Id", "Name");
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Name");
            return View();
        }

        // POST: NewTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OperationId,Amount,UnitId,CurrencyId,OperationDateTime,RecipientId,ContractorId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractor, "Id", "Name", transaction.ContractorId);
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", transaction.CurrencyId);
            ViewData["OperationId"] = new SelectList(_context.Operation, "Id", "Name", transaction.OperationId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "Id", "Name", transaction.RecipientId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Name", transaction.UnitId);
            return View(transaction);
        }

        // GET: NewTransactions/Edit/5
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
            ViewData["ContractorId"] = new SelectList(_context.Contractor, "Id", "Name", transaction.ContractorId);
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", transaction.CurrencyId);
            ViewData["OperationId"] = new SelectList(_context.Operation, "Id", "Name", transaction.OperationId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "Id", "Name", transaction.RecipientId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Name", transaction.UnitId);
            return View(transaction);
        }

        // POST: NewTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OperationId,Amount,UnitId,CurrencyId,OperationDateTime,RecipientId,ContractorId")] Transaction transaction)
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
            ViewData["ContractorId"] = new SelectList(_context.Contractor, "Id", "Name", transaction.ContractorId);
            ViewData["CurrencyId"] = new SelectList(_context.Currency, "Id", "Name", transaction.CurrencyId);
            ViewData["OperationId"] = new SelectList(_context.Operation, "Id", "Name", transaction.OperationId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "Id", "Name", transaction.RecipientId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Name", transaction.UnitId);
            return View(transaction);
        }

        // GET: NewTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Contractor)
                .Include(t => t.Currency)
                .Include(t => t.Operation)
                .Include(t => t.Recipient)
                .Include(t => t.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: NewTransactions/Delete/5
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
