using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCS.Data;
using SCS.Models;

namespace SCSWeb.Areas.Admin
{
    [Area("Admin")]
    public class AppSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AppSettings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppSettings.ToListAsync());
        }

        // GET: Admin/AppSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appSettings = await _context.AppSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appSettings == null)
            {
                return NotFound();
            }

            return View(appSettings);
        }

        // GET: Admin/AppSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Key1,Key2")] AppSettings appSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appSettings);
        }

        // GET: Admin/AppSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appSettings = await _context.AppSettings.FindAsync(id);
            if (appSettings == null)
            {
                return NotFound();
            }
            return View(appSettings);
        }

        // POST: Admin/AppSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Key1,Key2")] AppSettings appSettings)
        {
            if (id != appSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppSettingsExists(appSettings.Id))
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
            return View(appSettings);
        }

        // GET: Admin/AppSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appSettings = await _context.AppSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appSettings == null)
            {
                return NotFound();
            }

            return View(appSettings);
        }

        // POST: Admin/AppSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appSettings = await _context.AppSettings.FindAsync(id);
            if (appSettings != null)
            {
                _context.AppSettings.Remove(appSettings);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppSettingsExists(int id)
        {
            return _context.AppSettings.Any(e => e.Id == id);
        }
    }
}
