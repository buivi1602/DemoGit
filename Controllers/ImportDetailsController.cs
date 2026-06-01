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
    public class ImportDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImportDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ImportDetails.Include(i => i.Device);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ImportDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails
                .Include(i => i.Device)
                .FirstOrDefaultAsync(m => m.ImportDetailId == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // GET: ImportDetails/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceName");
            return View();
        }

        // POST: ImportDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImportDetailId,ImportId,DeviceId,ImportPrice,Quantity")] ImportDetail importDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceName", importDetail.DeviceId);
            return View(importDetail);
        }

        // GET: ImportDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails.FindAsync(id);
            if (importDetail == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceName", importDetail.DeviceId);
            return View(importDetail);
        }

        // POST: ImportDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImportDetailId,ImportId,DeviceId,ImportPrice,Quantity")] ImportDetail importDetail)
        {
            if (id != importDetail.ImportDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportDetailExists(importDetail.ImportDetailId))
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
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceName", importDetail.DeviceId);
            return View(importDetail);
        }

        // GET: ImportDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetails
                .Include(i => i.Device)
                .FirstOrDefaultAsync(m => m.ImportDetailId == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // POST: ImportDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var importDetail = await _context.ImportDetails.FindAsync(id);
            if (importDetail != null)
            {
                _context.ImportDetails.Remove(importDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportDetailExists(int id)
        {
            return _context.ImportDetails.Any(e => e.ImportDetailId == id);
        }
        
    }
}
