using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class ExportReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExportReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExportReceipts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExportReceipts.ToListAsync());
        }

        // GET: ExportReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipts
                .FirstOrDefaultAsync(m => m.ExportId == id);
            if (exportReceipt == null)
            {
                return NotFound();
            }

            return View(exportReceipt);
        }

        // GET: ExportReceipts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExportReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExportId,ExportCode,ExportDate,CustomerName")] ExportReceipt exportReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exportReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exportReceipt);
        }

        // GET: ExportReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipts.FindAsync(id);
            if (exportReceipt == null)
            {
                return NotFound();
            }
            return View(exportReceipt);
        }

        // POST: ExportReceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExportId,ExportCode,ExportDate,CustomerName")] ExportReceipt exportReceipt)
        {
            if (id != exportReceipt.ExportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportReceiptExists(exportReceipt.ExportId))
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
            return View(exportReceipt);
        }

        // GET: ExportReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipts
                .FirstOrDefaultAsync(m => m.ExportId == id);
            if (exportReceipt == null)
            {
                return NotFound();
            }

            return View(exportReceipt);
        }

        // POST: ExportReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exportReceipt = await _context.ExportReceipts.FindAsync(id);
            if (exportReceipt != null)
            {
                _context.ExportReceipts.Remove(exportReceipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportReceiptExists(int id)
        {
            return _context.ExportReceipts.Any(e => e.ExportId == id);
        }
    }
}
