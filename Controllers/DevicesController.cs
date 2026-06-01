using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================== INDEX + SEARCH ==================
        public async Task<IActionResult> Index(string searchString)
        {
            var devices = _context.Devices
                .Include(d => d.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d =>
                    d.DeviceName.Contains(searchString) ||
                    (d.Description != null && d.Description.Contains(searchString)) ||
                    d.Category!.CategoryName.Contains(searchString)
                );
            }

            return View(await devices.ToListAsync());
        }

        // ================== DETAILS ==================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            if (device == null) return NotFound();

            return View(device);
        }

        // ================== CREATE ==================
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.DeviceCategories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.DeviceCategories, "CategoryId", "CategoryName", device.CategoryId);
            return View(device);
        }

        // ================== EDIT ==================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices.FindAsync(id);
            if (device == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(_context.DeviceCategories, "CategoryId", "CategoryName", device.CategoryId);
            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Device device)
        {
            if (id != device.DeviceId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(device);
        }

        // ================== DELETE ==================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var device = await _context.Devices
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            if (device == null) return NotFound();

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}