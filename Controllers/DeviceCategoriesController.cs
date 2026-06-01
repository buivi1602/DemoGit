using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class DeviceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================== INDEX + SEARCH ==================
        public async Task<IActionResult> Index(string searchString)
        {
            var categories = from c in _context.DeviceCategories
                             select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c =>
                    c.CategoryName.Contains(searchString) ||
                    (c.Description != null && c.Description.Contains(searchString))
                );
            }

            return View(await categories.ToListAsync());
        }

        // ================== DETAILS ==================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var deviceCategory = await _context.DeviceCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (deviceCategory == null)
                return NotFound();

            return View(deviceCategory);
        }

        // ================== CREATE ==================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCategory deviceCategory)
        {
            // ❗ Check trùng tên
            if (_context.DeviceCategories.Any(c => c.CategoryName == deviceCategory.CategoryName))
            {
                ModelState.AddModelError("", "Tên loại thiết bị đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _context.Add(deviceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(deviceCategory);
        }

        // ================== EDIT ==================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategory == null)
                return NotFound();

            return View(deviceCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceCategory deviceCategory)
        {
            if (id != deviceCategory.CategoryId)
                return NotFound();

            // ❗ Check trùng tên (trừ chính nó)
            if (_context.DeviceCategories.Any(c =>
                c.CategoryName == deviceCategory.CategoryName &&
                c.CategoryId != id))
            {
                ModelState.AddModelError("", "Tên loại thiết bị đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceCategoryExists(deviceCategory.CategoryId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(deviceCategory);
        }

        // ================== DELETE ==================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var deviceCategory = await _context.DeviceCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (deviceCategory == null)
                return NotFound();

            return View(deviceCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategory != null)
            {
                _context.DeviceCategories.Remove(deviceCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceCategoryExists(int id)
        {
            return _context.DeviceCategories.Any(e => e.CategoryId == id);
        }
    }
}