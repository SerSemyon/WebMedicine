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
    public class PatientfeaturesController : Controller
    {
        private readonly MedicineContext _context;

        public PatientfeaturesController(MedicineContext context)
        {
            _context = context;
        }

        // GET: Patientfeatures
        public async Task<IActionResult> Index()
        {
            var medicineContext = _context.Patientfeatures.Include(p => p.Patient);
            return View(await medicineContext.ToListAsync());
        }

        // GET: Patientfeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientfeature = await _context.Patientfeatures
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientfeature == null)
            {
                return NotFound();
            }

            return View(patientfeature);
        }

        // GET: Patientfeatures/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: Patientfeatures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,FeaturesDescription")] Patientfeature patientfeature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientfeature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", patientfeature.PatientId);
            return View(patientfeature);
        }

        // GET: Patientfeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientfeature = await _context.Patientfeatures.FindAsync(id);
            if (patientfeature == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", patientfeature.PatientId);
            return View(patientfeature);
        }

        // POST: Patientfeatures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,FeaturesDescription")] Patientfeature patientfeature)
        {
            if (id != patientfeature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientfeature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientfeatureExists(patientfeature.Id))
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
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", patientfeature.PatientId);
            return View(patientfeature);
        }

        // GET: Patientfeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientfeature = await _context.Patientfeatures
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientfeature == null)
            {
                return NotFound();
            }

            return View(patientfeature);
        }

        // POST: Patientfeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientfeature = await _context.Patientfeatures.FindAsync(id);
            if (patientfeature != null)
            {
                _context.Patientfeatures.Remove(patientfeature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientfeatureExists(int id)
        {
            return _context.Patientfeatures.Any(e => e.Id == id);
        }
    }
}
