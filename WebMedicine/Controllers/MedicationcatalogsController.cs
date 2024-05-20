using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMedicine;
using WebMedicine.Models;

namespace WebMedicine.Controllers
{
    public class MedicationcatalogsController : Controller
    {
        private readonly MedicineContext _context;

        public MedicationcatalogsController(MedicineContext context)
        {
            _context = context;
        }

        // GET: Medicationcatalogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicationcatalogs.ToListAsync());
        }

        // GET: Medicationcatalogs
        [Route("поиск/{name?}")]
        public async Task<IActionResult> Search(string? name)
        {
            return View(await _context.Medicationcatalogs
                .Where(m => m.Name == name)
                .ToListAsync());
        }

        // GET: Medicationcatalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationcatalog = await _context.Medicationcatalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationcatalog == null)
            {
                return NotFound();
            }

            return View(medicationcatalog);
        }

        // GET: Medicationcatalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicationcatalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Dosage,Manufacturer")] Medicationcatalog medicationcatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationcatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicationcatalog);
        }

        // GET: Medicationcatalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationcatalog = await _context.Medicationcatalogs.FindAsync(id);
            if (medicationcatalog == null)
            {
                return NotFound();
            }
            return View(medicationcatalog);
        }

        // POST: Medicationcatalogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Dosage,Manufacturer")] Medicationcatalog medicationcatalog)
        {
            if (id != medicationcatalog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationcatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationcatalogExists(medicationcatalog.Id))
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
            return View(medicationcatalog);
        }

        // GET: Medicationcatalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationcatalog = await _context.Medicationcatalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationcatalog == null)
            {
                return NotFound();
            }

            return View(medicationcatalog);
        }

        // POST: Medicationcatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationcatalog = await _context.Medicationcatalogs.FindAsync(id);
            if (medicationcatalog != null)
            {
                _context.Medicationcatalogs.Remove(medicationcatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationcatalogExists(int id)
        {
            return _context.Medicationcatalogs.Any(e => e.Id == id);
        }
    }
}
